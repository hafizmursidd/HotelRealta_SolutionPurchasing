Imports HotelRealtaVbNetApi.Model

Namespace Repository



    Public Interface IPurchaseStockDetailRepo

        Function FindStockDetailbyID(ByVal id As Integer) As PurchaseStockDetail

        Function FindAllStockDetail() As List(Of PurchaseStockDetail)

        Function CreateNewStode(ByVal stode As PurchaseStockDetail) As PurchaseStockDetail

        Function DeleteStockDetail(ByVal id As Integer) As Integer

        Function UpdateStockDetailBySp(id As Integer, StodStock_id As Integer, StodBarcode_number As String,
                                       StodStatus As String, StodNotes As String, StodFaci_id As Integer,
                                       StodPohe_id As Integer, Optional showCommand As Boolean = False) As Boolean

        Function UpdateStockDetailByID(id As Integer, StodStock_id As Integer, StodBarcode_number As String,
                               StodStatus As String, StodNotes As String, StodFaci_id As Integer,
                               StodPohe_id As Integer, Optional showCommand As Boolean = False) As Boolean


    End Interface

End Namespace