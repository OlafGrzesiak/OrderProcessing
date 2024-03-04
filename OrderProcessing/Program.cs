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

                    Console.Write("Enter quantity: ");

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
                
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown option. try again");
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
        Order order = new Order(productName, quantity);
        orders.Add(order);
        Console.WriteLine("Order added: " + order);
    }

    public void DisplayOrders()
    {
        for (int i = 0; i < orders.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {orders[i]}");
        }
    }
    public void ProcessOrder(int orderNumber)
    {
        if (orderNumber >= 1 && orderNumber <= orders.Count)
        {
            orders[orderNumber - 1].Process();
            Console.WriteLine("Order processed.");
        }
        else
        {
            Console.WriteLine("Invalid order number.");
        }
    }

    class Order
    {
        public string ProductName { get; }
        public int Quantity { get; }
        public bool IsProcessed { get; private set; }


        public Order(string productName, int quantity)
        {
            ProductName = productName;
            Quantity = quantity;
            IsProcessed = false;
        }

        public void Process()
        {
            IsProcessed = true;
        }

        public override string ToString()
        {
            return $"{Quantity} x {ProductName} {(IsProcessed ? "[Zrealizowane]" : "")}";
        }
    }
}
