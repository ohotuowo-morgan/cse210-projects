using System;

class Program
{
    static void Main(string[] args)
    {
        Address addr1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer cust1 = new Customer("John Doe", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "L101", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "M202", 25.50, 2));

        Address addr2 = new Address("456 Maple Ave", "Lagos", "Lagos", "Nigeria");
        Customer cust2 = new Customer("Morgan Zero", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Phone Case", "P303", 15.00, 3));
        order2.AddProduct(new Product("Screen Protector", "S404", 10.00, 1));

        DisplayOrderInfo(order1);
        DisplayOrderInfo(order2);
    }

    static void DisplayOrderInfo(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.CalculateTotalCost():0.00}");
        Console.WriteLine("------------------------------------------\n");
    }
}