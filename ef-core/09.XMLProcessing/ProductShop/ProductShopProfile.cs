using System.Linq;
using AutoMapper;

using ProductShop.DTOs.Category;
using ProductShop.DTOs.CategoryProduct;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.User;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ImportUserDto, User>();

            CreateMap<ImportProductDto, Product>();

            CreateMap<ImportCategoryDto, Category>();

            CreateMap<ImportCategoryProductDto, CategoryProduct>();

            CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(d => d.BuyerName,
                    mo => mo.MapFrom(
                        s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"));

            CreateMap<ExportSoldProductDto, ExportUserWithSoldProductDto>();

            CreateMap<User, ExportUserWithSoldProductDto>()
                .ForMember(d => d.SoldProducts,
                    mo => mo.MapFrom(
                        s => s.ProductsSold));

            CreateMap<Category, ExportCategoryProductCountDto>()
                .ForMember(d => d.NumberOfProducts,
                    mo => mo.MapFrom(
                        s => s.CategoryProducts.Count))
                .ForMember(d => d.AverageProductsPrice,
                    mo => mo.MapFrom(
                        s => s.CategoryProducts.Average(p => p.Product.Price)))
                .ForMember(d => d.TotalRevenue,
                    mo => mo.MapFrom(
                        s => s.CategoryProducts.Sum(p => p.Product.Price)));

            CreateMap<User, ExportUserAndProductCountDto>();
        }
    }
}
