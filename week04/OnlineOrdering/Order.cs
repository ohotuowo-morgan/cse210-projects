using System;
using System.Collections.Generic;
public class Order 
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    public Order(Customer customer)
    {
        _customer  = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double  total = 0;
        foreach(var product in _products)
        {
            total += product.GetTotalCost();
        }

        double shipping = _customer.IsUSA() ? 5 : 35;
        return total +  shipping;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:";
        foreach (var product in _products)
        {
            label += $"\n- {product.GetName()} (ID: {product.GetId()})";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label: {_customer.GetName()}\n{_customer.GetAddressString()}";
    }


}