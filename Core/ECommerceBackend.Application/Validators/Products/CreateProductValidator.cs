﻿using ECommerceBackend.Application.Features.Commands.Product.CreateProduct;
using ECommerceBackend.Application.ViewModels.Products;
using FluentValidation;


namespace ECommerceBackend.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz");


            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen stok bilgisini boş geçmeyiniz.")
                .Must(s => s >= 0)
                .WithMessage("Lütfen stok bilgisini boş geçmeyiniz.");


            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz.")
                .Must(s => s >= 0)
                .WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz.");
        }
    }
}
