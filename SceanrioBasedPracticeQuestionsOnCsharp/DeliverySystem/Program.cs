// Question 19: Courier Delivery Tracking
// Scenario: A courier service needs to manage packages, deliveries, and tracking.
// Requirements:
// csharp
// // In class Package:
// // - string TrackingNumber
// // - string SenderName
// // - string ReceiverName
// // - string DestinationAddress
// // - double Weight
// // - string PackageType (Document/Parcel/Fragile)
// // - double ShippingCost

// // In class DeliveryStatus:
// // - string TrackingNumber
// // - List<string> Checkpoints
// // - string CurrentStatus (Dispatched/InTransit/Delivered)
// // - DateTime EstimatedDelivery
// // - DateTime ActualDelivery

// // In class CourierManager:
// public void AddPackage(string sender, string receiver, string address,
//                       double weight, string type, double cost)
// public bool UpdateStatus(string trackingNumber, string status, 
//                         string checkpoint)
// public Dictionary<string, List<Package>> GroupPackagesByType()
// public List<Package> GetPackagesByDestination(string city)
// public List<Package> GetDelayedPackages()
// Use Cases:
// •	Register packages for delivery
// •	Update delivery status
// •	Group packages by type
// •	Track packages by destination
// •	Identify delayed deliveries

 using System;
using System.Collections.Generic;

public class Package
{
    public string? TrackingNumber { get; set; }
    public string? SenderName { get; set; }
    public string? ReceiverName { get; set; }
    public string? DestinationAddress { get; set; }
    public double Weight { get; set; }
    public string? PackageType { get; set; }
    public double ShippingCost { get; set; }

    public Package() { }
}

public class DeliveryStatus
{
    public string? TrackingNumber { get; set; }
    public List<string> Checkpoints { get; set; }
    public string? CurrentStatus { get; set; }
    public DateTime EstimatedDelivery { get; set; }
    public DateTime ActualDelivery { get; set; }

    public DeliveryStatus()
    {
        Checkpoints = new List<string>();
    }
}

public class CourierManager
{
    public static int TrackingCounter = 1;

    public static Dictionary<string, Package> packageDetails = new Dictionary<string, Package>();
    public static Dictionary<string, DeliveryStatus> deliveryStatus = new Dictionary<string, DeliveryStatus>();

    public void AddPackage(string sender, string receiver, string address, double weight, string type, double cost)
    {
        Package package = new Package()
        {
            TrackingNumber = "TKN" + TrackingCounter++.ToString("D3"),
            SenderName = sender,
            ReceiverName = receiver,
            DestinationAddress = address,
            Weight = weight,
            PackageType = type,
            ShippingCost = cost
        };

        packageDetails.Add(package.TrackingNumber, package);

        DeliveryStatus status = new DeliveryStatus()
        {
            TrackingNumber = package.TrackingNumber,
            CurrentStatus = "Dispatched",
            EstimatedDelivery = DateTime.Now.AddDays(3)
        };

        deliveryStatus.Add(package.TrackingNumber, status);
    }

    public bool UpdateStatus(string trackingNumber, string status, string checkpoint)
    {
        if (!packageDetails.ContainsKey(trackingNumber))
        {
            Console.WriteLine("Invalid Tracking Number");
            return false;
        }

        DeliveryStatus ds = deliveryStatus[trackingNumber];
        ds.CurrentStatus = status;
        ds.Checkpoints.Add(checkpoint);

        if (status == "Delivered")
        {
            ds.ActualDelivery = DateTime.Now;
        }

        return true;
    }

    public Dictionary<string, List<Package>> GroupPackagesByType()
    {
        Dictionary<string, List<Package>> result = new Dictionary<string, List<Package>>();

        foreach (var item in packageDetails)
        {
            Package pkg = item.Value;

            if (!result.ContainsKey(pkg.PackageType))
            {
                result[pkg.PackageType] = new List<Package>();
            }

            result[pkg.PackageType].Add(pkg);
        }

        return result;
    }

    public List<Package> GetPackagesByDestination(string city)
    {
        List<Package> result = new List<Package>();

        foreach (var item in packageDetails)
        {
            Package pkg = item.Value;

            if (pkg.DestinationAddress != null && pkg.DestinationAddress.Contains(city))
            {
                result.Add(pkg);
            }
        }

        return result;
    }

    public List<Package> GetDelayedPackages()
    {
        List<Package> result = new List<Package>();

        foreach (var item in deliveryStatus)
        {
            DeliveryStatus ds = item.Value;

            if (ds.CurrentStatus != "Delivered" && ds.EstimatedDelivery < DateTime.Now)
            {
                result.Add(packageDetails[ds.TrackingNumber]);
            }
        }

        return result;
    }
}


