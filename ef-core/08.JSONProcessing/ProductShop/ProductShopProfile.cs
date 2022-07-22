using System.Linq;
using AutoMapper;

using ProductShop.DTO.Category;
using ProductShop.DTO.CategoryProduct;
using ProductShop.DTO.Product;
using ProductShop.DTO.User;
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

            CreateMap<Product, ExportProductRangeDto>()
                .ForMember(d => d.SellerFullName, mo => mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            CreateMap<Product, ExportUserSoldProductsDto>()
                .ForMember(d => d.BuyerFirstName, mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName, mo => mo.MapFrom(s => s.Buyer.LastName));

            CreateMap<User, ExportUserWithSoldProducts>()
                .ForMember(d => d.SoldProducts, mo => mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));

            CreateMap<Category, ExportCategoryWithProductCountDto>()
                .ForMember(d => d.ProductsCount, mo => mo.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(d => d.AveragePrice, mo => mo.MapFrom(s => s.CategoryProducts.Average(c => c.Product.Price)))
                .ForMember(d => d.TotalRevenue, mo => mo.MapFrom(s => s.CategoryProducts.Sum(c => c.Product.Price)));
        }
    }
}
