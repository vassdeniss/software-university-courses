using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using ProductShop.Data;
using ProductShop.DTOs.Category;
using ProductShop.DTOs.CategoryProduct;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.User;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string usersXml = GetXmlDataset("users");
            Console.WriteLine(ImportUsers(context, usersXml));

            string productsXml = GetXmlDataset("products");
            Console.WriteLine(ImportProducts(context, productsXml));

            string categoriesXml = GetXmlDataset("categories");
            Console.WriteLine(ImportCategories(context, categoriesXml));

            string categoryProductsXml = GetXmlDataset("categories-products");
            Console.WriteLine(ImportCategoryProducts(context, categoryProductsXml));

            Console.WriteLine(GetProductsInRange(context));

            Console.WriteLine(GetSoldProducts(context));

            Console.WriteLine(GetCategoriesByProductsCount(context));

            Console.WriteLine(GetUsersWithProducts(context));
        }

        // Problem 01 - Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitialiseMapper();

            ImportUserDto[] userDtos = DeserializeXml<ImportUserDto>("Users", inputXml);

            User[] users = mapper.Map<User[]>(userDtos);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        // Problem 02 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitialiseMapper();

            ImportProductDto[] productDtos = DeserializeXml<ImportProductDto>("Products", inputXml);

            Product[] products = mapper.Map<Product[]>(productDtos);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        // Problem 03 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitialiseMapper();

            ImportCategoryDto[] categoryDtos = DeserializeXml<ImportCategoryDto>("Categories", inputXml);

            Category[] categories = mapper.Map<Category[]>(categoryDtos);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        // Problem 04 - Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitialiseMapper();

            ImportCategoryProductDto[] categoryProductDtos 
                = DeserializeXml<ImportCategoryProductDto>("CategoryProducts", inputXml);

            CategoryProduct[] categoryProducts = mapper.Map<CategoryProduct[]>(categoryProductDtos);
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        // Problem 05 - Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = InitialiseMapper();

            ExportProductInRangeDto[] productDtos = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            return SerializeXml("Products", productDtos);
        }

        // Problem 06 - Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            IMapper mapper = InitialiseMapper();

            ExportUserWithSoldProductDto[] userDtos = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ProjectTo<ExportUserWithSoldProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            return SerializeXml("Users", userDtos);
        }

        // Problem 07 - Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IMapper mapper = InitialiseMapper();

            ExportCategoryProductCountDto[] categoryDtos = context.Categories
                .ProjectTo<ExportCategoryProductCountDto>(mapper.ConfigurationProvider)
                .OrderByDescending(x => x.NumberOfProducts)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            return SerializeXml("Categories", categoryDtos);
        }

        // Problem 08 - Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            // TODO

            IMapper mapper = InitialiseMapper();

            ExportUserAndProductCountDto[] userAnon = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .OrderByDescending(x => x.ProductsSold.Count)
                .ToArray() // judge
                .Select(u => new ExportUserAndProductCountDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductCountDto()
                    {
                        ProductsCount = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ExportSoldProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(x => x.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            ExportUserAndProductCountResult result = new ExportUserAndProductCountResult
            {
                CountOfUsers = context.Users.Count(x => x.ProductsSold.Any()),
                Users = userAnon
            };

            return SerializeXml("Users", result);
        }

        private static string SerializeXml<T>(string xmlRoot, T dtoArray)
        {
            XmlRootAttribute root = new XmlRootAttribute(xmlRoot);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter();
            serializer.Serialize(writer, dtoArray, namespaces);
            return writer.ToString();
        }

        private static T[] DeserializeXml<T>(string xmlRoot, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute(xmlRoot);
            XmlSerializer serializer = new XmlSerializer(typeof(T[]), root);

            using StringReader reader = new StringReader(inputXml);
            T[] dtos = (T[])serializer.Deserialize(reader);

            return dtos;
        }

        private static IMapper InitialiseMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
                cfg.AddProfile<ProductShopProfile>());

            return config.CreateMapper();
        }

        private static string GetXmlDataset(string dataset)
        {
            return File.ReadAllText($"../../../Datasets/{dataset}.xml");
        }
    }
}
