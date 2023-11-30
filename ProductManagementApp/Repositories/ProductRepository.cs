using ProductManagementApp.Models;

namespace DefaultNamespace;

public class ProductRepository : IProductRepository
{
    
    private static List<Product> _products = new List<Product>()
    {
        new Product(1, "Product 1", 123),
        new Product(2, "Product 2", 456)
    };

    public List<Product> GetProducts()
    {
        return _products;
    }

    public Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public void CreateProduct(Product newProduct)
    {
        if (newProduct == null)
        {
            throw new ArgumentNullException(nameof(newProduct));
        }

        if (string.IsNullOrWhiteSpace(newProduct.Name) || newProduct.Price < 0)
        {
            throw new ArgumentException("Name and Price are required and should be valid.");
        }

        newProduct.Id = GetProductNextId();
        _products.Add(newProduct);
    }

    public void UpdateProduct(int id, Product updateProduct)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);

        if (existingProduct != null)
        {
            existingProduct.Name = updateProduct.Name;
            existingProduct.Price = updateProduct.Price;
        }
    }

    public void DeleteProduct(int id)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);
        if (existingProduct != null)
        {
            _products.Remove(existingProduct);
        }
    }

    public List<Product> GetProductsByName(string name)
    {
        return _products
            .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Product> GetProductsByNameAndSort(string name, string sort)
    {
        var filteredProducts = _products
            .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (sort.Equals("asc", StringComparison.OrdinalIgnoreCase))
        {
            filteredProducts = filteredProducts.OrderBy(p => p.Name).ToList();
        }
        else if (sort.Equals("desc", StringComparison.OrdinalIgnoreCase))
        {
            filteredProducts = filteredProducts.OrderByDescending(p => p.Name).ToList();
        }

        return filteredProducts;
    }

    private int GetProductNextId()
    {
        return _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
    }
}
