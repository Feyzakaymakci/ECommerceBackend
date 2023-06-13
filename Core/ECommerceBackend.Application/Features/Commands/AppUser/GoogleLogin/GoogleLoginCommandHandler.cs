using ECommerceBackend.Application.Abstractions.Token;
using ECommerceBackend.Application.DTOs;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        readonly ITokenHandler _tokenHandler;

        public GoogleLoginCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { "68973280934-plkok7mrca4nquu45p759ravh4qr1vcm.apps.googleusercontent.com" } //Google Cloud da hangi proje üzerinden doğrulama yapacağımızı burada bildiriyoruz. 
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings); //Kullanıcıdan gelen IdToken ı doğrula
            var info = new UserLoginInfo(request.Provider, payload.Subject, request.Provider); //Dış kaynaktan gelen kullanıcı bilgilerini AspNetUserLogins tablosuna kaydetmemizi sağlayacak bir nesne.Yani eğer daha önceden kayıtlı değilse kaydını tutmak için oluşturduk.
            Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            bool result = user != null; //Eğer user null değilse true ver.
            if (user == null) //Eğer null sa yeni bir kullanıcı oluştur
            {
                user = await _userManager.FindByEmailAsync(payload.Email); 
                if (user == null) 
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = payload.Email,
                        UserName = payload.Email,
                        FullName = payload.Name
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
                await _userManager.AddLoginAsync(user, info); 
            else
                throw new Exception("Invalid external authentication.");

            Token token = _tokenHandler.CreateAccessToken(5);

            return new()
            {
                Token = token
            };
        }
    }
}
