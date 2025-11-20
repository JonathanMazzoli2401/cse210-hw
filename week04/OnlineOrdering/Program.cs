using System;

public class Program
{
    public static void Main(string[] args)
    {
        Address a1 = new Address("742 Evergreen Terrace", "Springfield", "Oregon", "USA");
        Customer c1 = new Customer("Keith Dunford", a1);

        Order o1 = new Order(c1);
        o1.AddProduct(new Product("Coke Pack", "CK123", 4.48, 6));
        o1.AddProduct(new Product("Donut Box", "DN777", 4.97, 2));


        Address a2 = new Address("Av Artigas 1234", "Las Piedras", "Canelones", "Uruguay");
        Customer c2 = new Customer("Jonathan Mazzoli", a2);

        Order o2 = new Order(c2);
        o2.AddProduct(new Product("Yerba Mate Canarias", "YM001", 7.99, 4));
        o2.AddProduct(new Product("Mate Imperial", "MT500", 85.00, 1));


        Console.WriteLine("ORDER 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(o1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(o1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${o1.GetTotalCost()}");

        Console.WriteLine("\n--------------------------\n");

        Console.WriteLine("ORDER 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(o2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(o2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${o2.GetTotalCost()}");
    }
}