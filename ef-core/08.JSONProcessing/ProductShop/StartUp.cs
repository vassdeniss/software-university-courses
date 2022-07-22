using System;
using System.IO;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;

using ProductShop.Data;
using ProductShop.DTO.Category;
using ProductShop.DTO.CategoryProduct;
using ProductShop.DTO.Product;
using ProductShop.DTO.User;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static ProductShopContext context;

        public static void Main()
        {
            InitialiseDb();

            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));

            string usersJson = File.ReadAllText("../../../Datasets/users.json");
            Console.WriteLine(ImportUsers(context, usersJson));

            string productsJson = File.ReadAllText("../../../Datasets/products.json");
            Console.WriteLine(ImportProducts(context, productsJson));

            string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            Console.WriteLine(ImportCategories(context, categoriesJson));

            string categoriesProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");
            Console.WriteLine(ImportCategoryProducts(context, categoriesProductsJson));

            //Console.WriteLine(GetProductsInRange(context));

            Console.WriteLine(GetSoldProducts(context));

            //Console.WriteLine(GetCategoriesByProductsCount(context));

            //Console.WriteLine(GetUsersWithProducts(context));
        }

        // Problem 01 - Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDto[] usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            User[] users = Mapper.Map<User[]>(usersDto);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        // Problem 02 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductDto[] productsDto = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            Product[] products = Mapper.Map<Product[]>(productsDto);
            context.Products.AddRange(products);
            context.SaveChanges();
            
            return $"Successfully imported {products.Length}";
        }

        // Problem 03 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ImportCategoryDto[] categoriesDto = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson)
                    .Where(c => c.Name != null)
                    .ToArray();

            Category[] categories = Mapper.Map<Category[]>(categoriesDto);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        // Problem 04 - Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ImportCategoryProductDto[] categoryProductDtos =
                JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            CategoryProduct[] categoryProducts = Mapper.Map<CategoryProduct[]>(categoryProductDtos);
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        // Problem 05 - Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductRangeDto[] products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductRangeDto>()
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        // Problem 06 - Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUserWithSoldProducts[] users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportUserWithSoldProducts>()
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        // Problem 07 - Export Categories By Products Length
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoryWithProductCountDto[] categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ProjectTo<ExportCategoryWithProductCountDto>()
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        // Problem 08 - Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(user => user.ProductsSold.Any(soldProduct => soldProduct.Buyer != null))
                .ToArray() // for judge
                .Select(user => new
                {
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    age = user.Age,
                    soldProducts = new
                    {
                        Lenght = user.ProductsSold.Count(product => product.Buyer != null),
                        products = user.ProductsSold.Where(product => product.Buyer != null)
                            .Select(product => new
                            {
                                name = product.Name,
                                price = product.Price
                            })
                    }
                })
                .OrderByDescending(user => user.soldProducts.Lenght)
                .ToArray();

            var toSerialize = new
            {
                usersLenght = users.Length,
                users
            };

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            };

            return JsonConvert.SerializeObject(toSerialize, serializerSettings);
        }

        private static void InitialiseDb()
        {
            context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
