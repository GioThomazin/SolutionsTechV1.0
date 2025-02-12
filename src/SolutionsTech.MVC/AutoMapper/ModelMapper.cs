using AutoMapper;
using SolutionsTech.Business.Entity;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.AutoMapper
{
	public class ModelMapper : Profile
	{
		public ModelMapper()
		{
			CreateMap<Brand, BrandDto>();
			CreateMap<BrandDto, Brand>();
			
			CreateMap<FormPayment, FormPaymentDto>();
			CreateMap<FormPaymentDto, FormPayment>();

			CreateMap<Product, ProductDto>();
			CreateMap<ProductDto, Product>();
			
			CreateMap<Scheduling, SchedulingDto>();
			CreateMap<SchedulingDto, Scheduling>();
			
			CreateMap<SchedulingProcedure, SchedulingProcedureDto>();
			CreateMap<SchedulingProcedureDto, SchedulingProcedure>();
			
			CreateMap<SchedulingProduct, SchedulingProductDto>();
			CreateMap<SchedulingProductDto, SchedulingProduct>();

            CreateMap<TypeProcedure, TypeProcedureDto>();
            CreateMap<TypeProcedureDto, TypeProcedure>();
            
			CreateMap<User, UserDto>();
			CreateMap<UserDto, User>();
            
			CreateMap<UserType, UserTypeDto>();
            CreateMap<UserTypeDto, UserType>();
        }
	}
}
