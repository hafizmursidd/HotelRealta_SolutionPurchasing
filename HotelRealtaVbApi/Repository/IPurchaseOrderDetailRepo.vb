Imports HotelRealtaVbNetApi.Model

Namespace Repository

    Public Interface IPurchaseOrderDetailRepo
        Function FindAllPode() As List(Of PurchaseOrderDetail)

        Function FindPodeById(ByVal id As Integer) As PurchaseOrderDetail

        Function DeletePode(ByVal id As Integer) As Integer

        Function CreatePode(ByVal pode As PurchaseOrderDetail) As PurchaseOrderDetail

        Function UpdatePodeBySP(id As Integer, podePoheId As Integer, podeOrderQty As Int16,
                                podePrice As Decimal, podeReceivedQty As Decimal, podeRejectedQty As Decimal,
                                podeStockId As Integer, Optional showCommand As Boolean = False) As Boolean
        Function UpdatePodeById(id As Integer, podePoheId As Integer, podeOrderQty As Int16,
                        podePrice As Decimal, podeReceivedQty As Decimal, podeRejectedQty As Decimal,
                        podeStockId As Integer, Optional showCommand As Boolean = False) As Boolean
    End Interface

End Namespace