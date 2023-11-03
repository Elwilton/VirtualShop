using System;
using VShop.Models;

namespace VShop.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();

    Task<Product> GetById(int id);

    Task<Product> Create(Product product);

    Task<Product> Update(IProductRepository product);

    Task<Product> Delete(int id);
}

