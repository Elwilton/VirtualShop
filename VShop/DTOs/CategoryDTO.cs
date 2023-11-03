using System;
using System.ComponentModel.DataAnnotations;
using VShop.Models;

namespace VShop.DTOs
{
	public class CategoryDTO
	{
		public int CatogoryId { get; set; }

		[Required(ErrorMessage = "The Name is Required")]
		[MinLength(3)]
		[MaxLength]
		public string?  Name { get; set; }

		public ICollection<Product>? Products { get; set; }
	}
}

