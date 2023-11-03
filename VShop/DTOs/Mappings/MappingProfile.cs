using System;
using AutoMapper;
using VShop.Models;

namespace VShop.DTOs.Mappings
{
	public class MappingProfile : Profile 
	{
		public MappingProfile()
		{
			CreateMap<Category, CategoryDTO>().ReverseMap();
			CreateMap<Product, ProductDTO>().ReverseMap();
		}
	}
}

