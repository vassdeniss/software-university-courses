using System.Linq;

using AutoMapper;

using CarDealer.DTO.Car;
using CarDealer.DTO.Customer;
using CarDealer.DTO.Part;
using CarDealer.DTO.Sale;
using CarDealer.DTO.Supplier;
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

            CreateMap<Customer, ExportCustomersOrderedDto>()
                .ForMember(
                    d => d.BirthDate,
                    mo => mo.MapFrom(
                        s => $"{s.BirthDate:dd/MM/yyyy}"));
            
            CreateMap<Car, ExportToyotaCarDto>();

            CreateMap<Supplier, ExportLocalSuppliesDto>();

            CreateMap<Car, ExportToyotaCarDto>();

            CreateMap<Sale, ExportSalesWithDiscountDto>()
                .ForMember(d => d.Discount,
                    mo => mo.MapFrom(
                        s => s.Discount.ToString("f2")))
                .ForMember(
                    d => d.Price,
                    mo => mo.MapFrom(
                        s => s.Car.PartCars.Sum(p => p.Part.Price).ToString("f2")));

            CreateMap<ExportToyotaCarDto, ExportSalesWithDiscountDto>();
        }
    }
}
