using ProductManagementApp.Models;

namespace ProductManagementApp.Services;

public interface IProductService
{
    List<Product> GetProducts();
    Product GetProductById(int id);
    void CreateProduct(Product newProduct);
    void UpdateProduct(int id, Product updateProduct);
    void DeleteProduct(int id);
    List<Product> GetProductsByName(string name);
    List<Product> GetProductsByNameAndSort(string name, string sort);
}