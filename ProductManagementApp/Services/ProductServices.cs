using DefaultNamespace;
using ProductManagementApp.Models;

namespace ProductManagementApp.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> GetProducts()
    {
        return _productRepository.GetProducts();
    }

    public Product GetProductById(int id)
    {
        var productById = _productRepository.GetProductById(id);

        if (productById == null)
        {
            throw new Exception($"Product with ID {id} not found.");
        }

        return productById;
    }

    public void CreateProduct(Product newProduct)
    {
        _productRepository.CreateProduct(newProduct);
    }

    public void UpdateProduct(int id, Product updateProduct)
    {
        var existingProduct = _productRepository.GetProductById(id);

        if (existingProduct == null)
        {
            throw new Exception($"Product with ID {id} not found.");
        }

        _productRepository.UpdateProduct(id, updateProduct);
    }

    public void DeleteProduct(int id)
    {
        var existingProduct = _productRepository.GetProductById(id);

        if (existingProduct == null)
        {
            throw new Exception($"Product with ID {id} not found.");
        }

        _productRepository.DeleteProduct(id);
    }

    public List<Product> GetProductsByName(string name)
    {
        return _productRepository.GetProductsByName(name);
    }

    public List<Product> GetProductsByNameAndSort(string name, string sort)
    {
        return _productRepository.GetProductsByNameAndSort(name, sort);
    }
}
