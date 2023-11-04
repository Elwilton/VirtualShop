using System;
using VShop.DTOs;

namespace VShop.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();

    Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();

    Task<CategoryDTO> GetCategoriesById(int id);

    Task AddCategory(CategoryDTO categoryDTO);

    Task UpdateCategory(CategoryDTO categoryDto);

    Task RemoveCategory(int id);
}

