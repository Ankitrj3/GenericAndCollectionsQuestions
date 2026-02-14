using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

public class Shipment
{
    public string? ShipmentCode{get; set;}
    public string? TransportMode{get; set;}
    public double Weight{get; set;}
    public int StorageDays{get; set;}

    public Shipment(){}
}
public class ShipmentDetails : Shipment
{
    public ShipmentDetails(string shipmentCode, string transportMode, double weight, int storageDays)
    {
        ShipmentCode = shipmentCode;
        TransportMode = transportMode;
        Weight = weight;
        StorageDays = storageDays;
    }
    public bool ValidateShipmentCode()
    {
        string pattern = @"^GC#[0-9]{4}$";
        bool match = Regex.IsMatch(ShipmentCode, pattern);

        if (match)
        {
            return true;
        }
        return false;
    }
    public double CalculateTotalCost()
    {
        double price = 0;
        if(TransportMode == "Sea")
        {
            price = 15;
        }else if(TransportMode == "Air")
        {
            price = 50;
        }else if(TransportMode == "Land")
        {
            price = 15;
        }
        double res = (Weight * price) + Math.Sqrt(StorageDays);
        return res;
    }
}
public class Program
{
    public static void Main()
    {
        string value = Console.ReadLine();
        string[] arr = value.Split(" ");

        string id = arr[0];
        string mode = arr[1];
        double weight = double.Parse(arr[2]);
        int storageDays = int.Parse(arr[3]);

        ShipmentDetails shipment = new ShipmentDetails(id,mode,weight,storageDays);

        if (shipment.ValidateShipmentCode())
        {
            Console.WriteLine($"The total shipping cost is {shipment.CalculateTotalCost():F2}");
        }
        else
        {
            Console.WriteLine("Invalid shipment code");
    }
}
}