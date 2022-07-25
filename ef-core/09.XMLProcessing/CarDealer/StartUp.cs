using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using CarDealer.Data;
using CarDealer.DTOs;
using CarDealer.DTOs.Car;
using CarDealer.DTOs.Customer;
using CarDealer.DTOs.Part;
using CarDealer.DTOs.Sale;
using CarDealer.DTOs.Supplier;
using CarDealer.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Query;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            string suppliersXml = GetXmlDataset("suppliers");
            Console.WriteLine(ImportSuppliers(context, suppliersXml));

            string partsXml = GetXmlDataset("parts");
            Console.WriteLine(ImportParts(context, partsXml));

            string carsXml = GetXmlDataset("cars");
            Console.WriteLine(ImportCars(context, carsXml));

            string customersXml = GetXmlDataset("customers");
            Console.WriteLine(ImportCustomers(context, customersXml));

            string salesXml = GetXmlDataset("sales");
            Console.WriteLine(ImportSales(context, salesXml));

            Console.WriteLine(GetCarsWithDistance(context));

            Console.WriteLine(GetCarsFromMakeBmw(context));

            Console.WriteLine(GetLocalSuppliers(context));

            Console.WriteLine(GetCarsWithTheirListOfParts(context));

            Console.WriteLine(GetTotalSalesByCustomer(context));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        // Problem 09 - Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            ImportSupplierDto[] supplierDtos = DeserializeXml<ImportSupplierDto>("Suppliers", inputXml);

            IMapper mapper = InitialiseMapper();
            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDtos);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        // Problem 10 - Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            ImportPartDto[] partDtos = DeserializeXml<ImportPartDto>("Parts", inputXml);

            int[] supplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            IMapper mapper = InitialiseMapper();
            Part[] parts = mapper.Map<Part[]>(partDtos)
                .Where(p => supplierIds.Contains(p.SupplierId))
                .ToArray();
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        // Problem 11 - Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            int[] partIds = context.Parts
                .Select(p => p.Id)
                .ToArray();

            ImportCarDto[] carDtos = DeserializeXml<ImportCarDto>("Cars", inputXml);

            Car[] cars = carDtos.Select(c => new Car
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance,
                PartCars = c.PartsIds
                    .Select(pc => pc.Id)
                    .Intersect(partIds)
                    .Distinct()
                    .Select(pc => new PartCar
                    {
                        PartId = pc
                    })
                    .ToArray()
            })
            .ToArray();

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Length}";
        }

        // Problem 12 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            ImportCustomerDto[] customerDtos = DeserializeXml<ImportCustomerDto>("Customers", inputXml);

            IMapper mapper = InitialiseMapper();
            Customer[] customers = mapper.Map<Customer[]>(customerDtos);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        // Problem 13 - Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            int[] carIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            ImportSaleDto[] saleDtos = DeserializeXml<ImportSaleDto>("Sales", inputXml);

            IMapper mapper = InitialiseMapper();
            Sale[] sales = mapper.Map<Sale[]>(saleDtos)
                .Where(s => carIds.Contains(s.CarId))
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        // Problem 14 - Export Cars with Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = InitialiseMapper();

            ExportCarWithDistanceDto[] carDtos = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarWithDistanceDto>(mapper.ConfigurationProvider)
                .ToArray();

            return SerializeXml("cars", carDtos);
        }

        // Problem 15 - Export Cars from Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = InitialiseMapper();

            ExportCarBMWDto[] carDtos = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ProjectTo<ExportCarBMWDto>(mapper.ConfigurationProvider)
                .ToArray();

            return SerializeXml("cars", carDtos);
        }

        // Problem 16 - Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = InitialiseMapper();

            ExportSupplierDto[] supplierDtos = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportSupplierDto>(mapper.ConfigurationProvider)
                .ToArray();

            return SerializeXml("suppliers", supplierDtos);
        }

        // Problem 17 - Export Cars with their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = InitialiseMapper();

            ExportCarWithPartDto[] carDtos = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportCarWithPartDto>(mapper.ConfigurationProvider)
                .ToArray();

            return SerializeXml("cars", carDtos);
        }

        // Problem 18 - Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            IMapper mapper = InitialiseMapper();

            ExportCustomerSaleDto[] customerDtos = context.Customers
                .Where(c => c.Sales.Count > 0)
                .ProjectTo<ExportCustomerSaleDto>(mapper.ConfigurationProvider)
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            return SerializeXml("customers", customerDtos);
        }

        // Problem 19 - Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            IMapper mapper = InitialiseMapper();

            ExportSaleDiscountDto[] saleDtos = context.Sales
                .ProjectTo<ExportSaleDiscountDto>(mapper.ConfigurationProvider)
                .ToArray();

            return SerializeXml("sales", saleDtos);
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
                cfg.AddProfile<CarDealerProfile>());

            return config.CreateMapper();
        }

        private static string GetXmlDataset(string dataset)
        {
            return File.ReadAllText($"../../../Datasets/{dataset}.xml");
        }
    }
}
