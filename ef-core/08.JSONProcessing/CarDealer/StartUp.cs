using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using CarDealer.Data;
using CarDealer.DTO.Car;
using CarDealer.DTO.Customer;
using CarDealer.DTO.Part;
using CarDealer.DTO.Sale;
using CarDealer.DTO.Supplier;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static CarDealerContext context;

        public static void Main()
        {
            InitialiseDb();

            Mapper.Initialize(cfg => cfg.AddProfile(typeof(CarDealerProfile)));

            string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            Console.WriteLine(ImportSuppliers(context, suppliersJson));

            string partsJson = File.ReadAllText("../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(context, partsJson));

            string carsJson = File.ReadAllText("../../../Datasets/cars.json");
            Console.WriteLine(ImportCars(context, carsJson));

            string customersJson = File.ReadAllText("../../../Datasets/customers.json");
            Console.WriteLine(ImportCustomers(context, customersJson));

            string salesJson = File.ReadAllText("../../../Datasets/sales.json");
            Console.WriteLine(ImportSales(context, salesJson));

            Console.WriteLine(GetOrderedCustomers(context));

            Console.WriteLine(GetCarsFromMakeToyota(context));

            Console.WriteLine(GetLocalSuppliers(context));

            Console.WriteLine(GetCarsWithTheirListOfParts(context));

            Console.WriteLine(GetTotalSalesByCustomer(context));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        // Problem 09 - Import Supplies
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ImportSupplierDto[] supplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            Supplier[] suppliers = Mapper.Map<Supplier[]>(supplierDtos);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        // Problem 10 - Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            int[] supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToArray();

            ImportPartDto[] partDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            Part[] parts = Mapper.Map<Part[]>(partDtos)
                .Where(p => supplierIds.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }

        // Problem 11 - Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            Car[] cars = new Car[carDtos.Length];
            for (int i = 0; i < carDtos.Length; i++)
            {
                Car newCar = new Car
                {
                    Make = carDtos[i].Make,
                    Model = carDtos[i].Model,
                    TravelledDistance = carDtos[i].TravelledDistance,
                };

                foreach (int partId in carDtos[i].PartsId.Distinct())
                {
                    newCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                cars[i] = newCar;
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        // Problem 12 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            ImportCustomerDto[] customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            Customer[] customers = Mapper.Map<Customer[]>(customerDtos);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        // Problem 13 - Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            ImportSaleDto[] saleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            Sale[] sales = Mapper.Map<Sale[]>(saleDtos);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        // Problem 14 - Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            ExportCustomersOrderedDto[] customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver ? 1 : 0)
                .ProjectTo<ExportCustomersOrderedDto>()
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // Problem 15 - Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            ExportToyotaCarDto[] cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExportToyotaCarDto>()
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        // Problem 16 - Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportLocalSuppliesDto[] suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .ProjectTo<ExportLocalSuppliesDto>()
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        // Problem 17 - Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TravelledDistance
                    },
                    parts = x.PartCars.Select(y => new
                    {
                        y.Part.Name,
                        Price = y.Part.Price.ToString("F2")
                    })
                })
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        // Problem 18 - Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // Problem 19 - Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSalesWithDiscountDto[] sales = context.Sales
                .ProjectTo<ExportSalesWithDiscountDto>()
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        private static void InitialiseDb()
        {
            context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
