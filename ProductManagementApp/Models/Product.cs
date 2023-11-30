namespace ProductManagementApp.Models;

public class Product
{
    private int _id;
    private string _name;
    private decimal _price;

    public Product(int id, string name, decimal price)
    {
        _id = id;
        _name = name;
        _price = price;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public decimal Price
    {
        get => _price;
        set => _price = value;
    }
}