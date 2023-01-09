// See https://aka.ms/new-console-template for more information
using HotelRealtaVbNetApi;
using Microsoft.Extensions.Configuration;
using System;

namespace HotelRealtaClient // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static IConfigurationRoot Configuration;
        static void Main(string[] args)
        {
           // Console.WriteLine("Hello World!");

            BuildConfig();

            IHotelRealtaVbApi _HotelRealta = new HotelRealtaVbApi(Configuration.GetConnectionString("HotelRealtaDS"));
            //iHR.SayHello();


            //------------------------------ Fetchall ------------------------------ 

            var listPohe = _HotelRealta.RepositoryManager.PurchaseOrderHeader.FindAllPohe();
            foreach (var item in listPohe)
            {
                Console.WriteLine(item);
            }

            //------------------------------ find by id ------------------------------ 

            //var PoheId = _HotelRealta.RepositoryManager.PurchaseOrderHeader.FindPoheById(5);
            //Console.WriteLine("The Region found: " + PoheId);



            //------------------------------ update by id ------------------------------ 

            //var updateByid = _HotelRealta.RepositoryManager.PurchaseOrderHeader.UpdatePoheById(
            //                5, "123", 1, 12121, 0, DateTime.Now, "TR", 1, 2, true);
            //var updateResult = _HotelRealta.RepositoryManager.PurchaseOrderHeader.FindPoheById(5);

            //Console.WriteLine(updateResult);



            //------------------------------ updata by Store Porcedure ------------------------------ 

            var updateBySP = _HotelRealta.RepositoryManager.PurchaseOrderHeader.UpdatePoheById(
                            1007, "1233", 1, 22222, 0, DateTime.Now, "TR", 1, 2, true);
            var updateResultSP = _HotelRealta.RepositoryManager.PurchaseOrderHeader.FindPoheById(5);

            Console.WriteLine(updateResultSP);

            //------------------------------ Create new ------------------------------
            //var createNewPohe = _HotelRealta.RepositoryManager.PurchaseOrderHeader.CreatePohe
            //    (new HotelRealtaVbNetApi.Model.PurchaseOrderHeader
            //    {
            //    PoheNumber = "1121",
            //    PoheStatus = 1,
            //    PoheTax = 11111,
            //    PoheRefund = 0,
            //    PoheArrivalDate = DateTime.Now,
            //    PohePayType = "CA",
            //    PoheEmpId = 1, 
            //    PoheVendorId = 2
            //    });

            //Console.WriteLine($"New Purchase Order Header: {createNewPohe}");

            //------------------------------ Create new ------------------------------




        }
        static void BuildConfig()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            Console.WriteLine(Configuration.GetConnectionString("HotelRealtaDS"));
    }
    }
}