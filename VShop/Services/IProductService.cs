using System;
using VShop.DTOs;

namespace VShop.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();

    Task<ProductDTO> GetProductById(int id);

    Task AddProduct(ProductDTO productDTO);

    Task UpdateProduct(ProductDTO productDTO);

    Task RemovProduct(int id);
}

