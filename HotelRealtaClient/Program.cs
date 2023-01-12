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

            //var listPohe = _HotelRealta.RepositoryManager.PurchaseOrderHeader.FindAllPohe();
            //foreach (var item in listPohe)
            //{
            //    Console.WriteLine(item);
            //}

            //------------------------------ find by id ------------------------------ 

            //var PoheId = _HotelRealta.RepositoryManager.PurchaseOrderHeader.FindPoheById(5);
            //Console.WriteLine("The Region found: " + PoheId);



            //------------------------------ update by id ------------------------------ 

            //var updateByid = _HotelRealta.RepositoryManager.PurchaseOrderHeader.UpdatePoheById(
            //                5, "123", 1, 12121, 0, DateTime.Now, "TR", 1, 2, true);
            //var updateResult = _HotelRealta.RepositoryManager.PurchaseOrderHeader.FindPoheById(5);

            //Console.WriteLine(updateResult);



            //------------------------------ update by Store Porcedure ------------------------------ 

            //var updateBySP = _HotelRealta.RepositoryManager.PurchaseOrderHeader.UpdatePoheById(
            //                1007, "1233", 1, 22222, 0, DateTime.Now, "TR", 1, 2, true);
            //var updateResultSP = _HotelRealta.RepositoryManager.PurchaseOrderHeader.FindPoheById(5);

            //Console.WriteLine(updateResultSP);


            //------------------------------ Delete ------------------------------

            //var rowEffect = _HotelRealta.RepositoryManager.PurchaseOrderHeader.DeletePohe(2002);
            //Console.WriteLine($"Row Effect : {rowEffect}");



            ////  ------------------------------Create new ------------------------------
            //var createNewPohe = _HotelRealta.RepositoryManager.PurchaseOrderHeader.CreatePohe
            //    (new HotelRealtaVbNetApi.Model.PurchaseOrderHeader
            //    {
            //        PoheNumber = "9999",
            //        PoheStatus = 1,
            //        PoheTax = 11111,
            //        PoheRefund = 0,
            //        PoheArrivalDate = DateTime.Now,
            //        PohePayType = "CA",
            //        PoheEmpId = 1,
            //        PoheVendorId = 2
            //    });

            //Console.WriteLine($"New Purchase Order Header: {createNewPohe}");



            //-----PURCHASE ORDER DETAIL---------------------------------------------------------------------------

            //  ------------------------------Find by Id ------------------------------
            //var findPodeId = _HotelRealta.RepositoryManager.PurchaseOrderDetail.FindPodeById(1);
            //Console.WriteLine(findPodeId);

            //  ------------------------------Fetch All------------------------------
            //var fetchAll = _HotelRealta.RepositoryManager.PurchaseOrderDetail.FindAllPode();

            //foreach (var item in fetchAll)
            //{
            //    Console.WriteLine(item);
            //}

            //  ------------------------------Create new------------------------------
            //var newPurchasingOrderDetail = _HotelRealta.RepositoryManager.PurchaseOrderDetail.CreatePode
            //    (new HotelRealtaVbNetApi.Model.PurchaseOrderDetail
            //    {
            //        PodePoheId = 1,
            //        PodeOrderQty = 11,
            //        PodePrice = 11111,
            //        PodeReceivedQty = 121,
            //        PodeRejectedQty = 9,
            //        PodeStockId = 5
            //    });
            //Console.WriteLine($"New Purchase Order Detail: {newPurchasingOrderDetail}");

            //  ------------------------------Update BY SP------------------------------
            //var updateBySP = _HotelRealta.RepositoryManager.PurchaseOrderDetail.
            //    UpdatePodeBySP(2002, 1, 11, 11111, 111,1,1);
            //var updateResultSP = _HotelRealta.RepositoryManager.PurchaseOrderDetail.FindPodeById(2002);

            //Console.WriteLine(updateResultSP);

            //  ----------------------------Update By Id------------------------------
            //var updateById = _HotelRealta.RepositoryManager.PurchaseOrderDetail. UpdatePodeById(2002, 2, 222, 222, 22, 2, 2);
            //var updateResultId = _HotelRealta.RepositoryManager.PurchaseOrderDetail.FindPodeById(2002);

            //Console.WriteLine(updateResultId);





            //_____PURCHASE sTOCK DETAIL---------------------------------------------------------------------------

            // ------------------------------Find by Id ------------------------------
            //var findPodeId = _HotelRealta.RepositoryManager.PurchaseStockDetail.FindStockDetailbyID(1);
            //Console.WriteLine(findPodeId);


            // --------------------------FETCH ALL____________________
            //var fetchAll = _HotelRealta.RepositoryManager.PurchaseStockDetail.FindAllStockDetail();
            //foreach (var item in fetchAll)
            //{
            //    Console.WriteLine(item);
            //}

            // --------------------------CREATE____________________
            //var newStockDetail = _HotelRealta.RepositoryManager.PurchaseStockDetail.CreateNewStode
            //    (new HotelRealtaVbNetApi.Model.PurchaseStockDetail
            //    {
            //        StodStockId = 1,
            //        StodBarcodeNumber = "TRYYYA",
            //        StodStatus = "2",
            //        StodNotes = "dadmad",
            //        StodFaciId = 1,
            //        StodPoheId = 1
            //    });
            //Console.WriteLine($"New Purchase Stock Detail: {newStockDetail}");

            //--------------------------DELETE____________________
            //var deleteStockDet = _HotelRealta.RepositoryManager.PurchaseStockDetail.DeleteStockDetail(30);
            //Console.WriteLine($"Row Effect for Delete: {deleteStockDet}");

            //  ------------------------------Update BY SP------------------------------
            //var updateBySP = _HotelRealta.RepositoryManager.PurchaseStockDetail.UpdateStockDetailBySp(31, 12, "11", "1", "11", 1, 1);
            //var updateResultSP = _HotelRealta.RepositoryManager.PurchaseStockDetail.FindStockDetailbyID(31);
            //Console.WriteLine(updateResultSP);

            //  ------------------------------Update BY ID------------------------------
            //var updateByID = _HotelRealta.RepositoryManager.PurchaseStockDetail.UpdateStockDetailByID(31, 12, "11111111111111111111111111111", "1", "333333333333333333333333333333", 1, 1);
            //var updateResultID = _HotelRealta.RepositoryManager.PurchaseStockDetail.FindStockDetailbyID(31);
            //Console.WriteLine(updateResultID);




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