using System.Linq;

using AutoMapper;

using CarDealer.DTOs;
using CarDealer.DTOs.Car;
using CarDealer.DTOs.Customer;
using CarDealer.DTOs.Part;
using CarDealer.DTOs.Sale;
using CarDealer.DTOs.Supplier;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSupplierDto, Supplier>();

            CreateMap<ImportPartDto, Part>();

            CreateMap<ImportCustomerDto, Customer>();

            CreateMap<ImportSaleDto, Sale>();

            CreateMap<Car, ExportCarWithDistanceDto>();

            CreateMap<Car, ExportCarBMWDto>();

            CreateMap<Supplier, ExportSupplierDto>();

            CreateMap<Part, ExportCarPartDto>();

            CreateMap<Car, ExportCarWithPartDto>()
                .ForMember(d => d.CarParts,
                    mo => mo.MapFrom(
                        s => s.PartCars
                            .Select(pt => pt.Part)
                            .OrderByDescending(p => p.Price)));

            CreateMap<Customer, ExportCustomerSaleDto>()
                .ForMember(d => d.BoughtCars,
                    mo => mo.MapFrom(
                        s => s.Sales.Count))
                .ForMember(d => d.SpentMoney,
                    mo => mo.MapFrom(
                        s => s.Sales
                            .Select(s => s.Car)
                            .SelectMany(c => c.PartCars)
                            .Sum(pt => pt.Part.Price)));

            CreateMap<Car, ExportCarDto>();

            CreateMap<Sale, ExportSaleDiscountDto>()
                .ForMember(d => d.SoldCar,
                    mo => mo.MapFrom(
                        s => s.Car))
                .ForMember(d => d.Price,
                    mo => mo.MapFrom(
                        s => s.Car.PartCars.Sum(pc => pc.Part.Price)))
                .ForMember(d => d.PriceWithDiscount,
                    mo => mo.MapFrom(
                        s => s.Car.PartCars.Sum(pc => pc.Part.Price)
                             - s.Car.PartCars.Sum(pc => pc.Part.Price) 
                             * (s.Discount / 100)));
        }
    }
}
