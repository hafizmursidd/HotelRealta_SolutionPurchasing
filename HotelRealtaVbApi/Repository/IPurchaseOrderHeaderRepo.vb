Imports HotelRealtaVbNetApi.Model

Namespace Repository



    Public Interface IPurchaseOrderHeaderRepo

        Function CreatePohe(ByVal pohe As PurchaseOrderHeader) As PurchaseOrderHeader

        Function DeletePohe(ByVal id As Integer) As Integer
        Function FindAllPohe() As List(Of PurchaseOrderHeader)
        Function FindAllPoheAsync() As Task(Of List(Of PurchaseOrderHeader))
        Function FindPoheById(ByVal id As Integer) As PurchaseOrderHeader
        Function UpdatePoheBySP(id As Integer, poheNumber As String, poheStatus As Byte,
                                 poheTax As Decimal, poherefund As Decimal, poheArrival As Date,
                                pohePayId As String, pohEmpId As Integer, poheVendorID As Integer,
                                 Optional showCommand As Boolean = False) As Boolean
        Function UpdatePoheById(id As Integer, poheNumber As String, poheStatus As Byte,
                         poheTax As Decimal, poherefund As Decimal, poheArrival As Date,
                        pohePayType As String, pohEmpId As Integer, poheVendorID As Integer,
                         Optional showCommand As Boolean = False) As Boolean
    End Interface

End Namespace