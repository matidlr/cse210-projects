using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main St",
            "New York",
            "NY",
            "USA");

        Customer customer1 = new Customer(
            "John Smith",
            address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(
            new Product("Laptop", "P100", 800, 1));

        order1.AddProduct(
            new Product("Mouse", "P101", 25, 2));

        Address address2 = new Address(
            "456 Cordoba Ave",
            "Cordoba",
            "Cordoba",
            "Argentina");

        Customer customer2 = new Customer(
            "Matias de la Rosa",
            address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(
            new Product("Keyboard", "P200", 75, 1));

        order2.AddProduct(
            new Product("Monitor", "P201", 250, 2));

        order2.AddProduct(
            new Product("Webcam", "P202", 50, 1));

        Console.WriteLine("ORDER 1");
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine(
            $"Total Cost: ${order1.CalculateTotalCost():F2}");

        Console.WriteLine("\n============================\n");

        Console.WriteLine("ORDER 2");
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine(
            $"Total Cost: ${order2.CalculateTotalCost():F2}");
    }
}