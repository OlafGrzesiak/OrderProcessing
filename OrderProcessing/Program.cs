using System;
using System.Collections.Generic;

namespace OrderProcessing;

class Program
{
    static void Main()
    {
        OrderProcessor orderProcessor = new OrderProcessor();

        while (true)
        {
            Console.WriteLine("1. Add Order");
            Console.WriteLine("2. Show Orders");
            Console.WriteLine("3. Complete the order");
            Console.WriteLine("4. Exit");
            
            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the product name: ");
                    string productName = Console.ReadLine();
                    
                    Console.Write("Enter quantity: ")

                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        orderProcessor.PlaceOrder(productName, quantity);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect quantity");
                    }
                    break;
                
                case "2":
                    Console.WriteLine("Orders: ");
                    orderProcessor.DisplayOrders();
                    break;
                
                case "3":
                    Console.Write("Enter the order number to be processed: ");
                    if (int.TryParse(Console.ReadLine(), out int orderNumber))
                    {
                        orderProcessor.ProcessOrder(orderNumber);
                    }
                    else
                    {
                        Console.WriteLine("Invalid order number.");
                    }

                    break;
                
                case "0":
                    Console.WriteLine("Unknown option. Try again. ");
                    break;
            }
            
            Console.WriteLine();
        }
    }
}

class OrderProcessor
{
    private List<Order> orders;

    public OrderProcessor()
    {
        orders = new List<Order>();
    }

    public void PlaceOrder(string productName, int quantity)
    {
        
    }
}