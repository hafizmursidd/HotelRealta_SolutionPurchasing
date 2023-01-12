Imports HotelRealtaVbNetApi.Repository

Namespace Base


    Public Interface IRepositoryManager

        ReadOnly Property PurchaseOrderHeader As IPurchaseOrderHeaderRepo
        ReadOnly Property PurchaseOrderDetail As IPurchaseOrderDetailRepo

        ReadOnly Property PurchaseStockDetail As IPurchaseStockDetailRepo


    End Interface

End Namespace