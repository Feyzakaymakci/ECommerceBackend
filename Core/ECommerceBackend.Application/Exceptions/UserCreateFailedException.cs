using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Application.Exceptions
{
    public class UserCreateFailedException : Exception
    {
        public UserCreateFailedException():base("Unexpected Error Occurred") //Default olarak yönetebilirsin
        {
        }

        public UserCreateFailedException(string? message) : base(message) //parametre ve mesajı  vererek yönetebilirsin
        {
        }

        public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException) //hem mesajı hem de almış olduğun exception ı verip base class a gönderip yönetebilirsin.
        {
        }

    }
}
