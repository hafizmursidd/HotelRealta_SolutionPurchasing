Imports HotelRealtaVbNetApi.Context
Imports HotelRealtaVbNetApi.Repository

Namespace Base


    Public Class RepositoryManager
        Implements IRepositoryManager

        Private _PohRepo As IPurchaseOrderHeaderRepo
        Private _PodeRepo As IPurchaseOrderDetailRepo
        Private _StockDetail As IPurchaseStockDetailRepo

        Private ReadOnly _repositoryContext As IRepositoryContext

        Public Sub New(repositoryContext As IRepositoryContext)
            _repositoryContext = repositoryContext
        End Sub

        Private ReadOnly Property PurchaseOrderHeader As IPurchaseOrderHeaderRepo Implements IRepositoryManager.PurchaseOrderHeader
            Get
                If _PohRepo Is Nothing Then
                    _PohRepo = New PurchaseOrderHeaderRepo(_repositoryContext)
                End If

                Return _PohRepo
            End Get
        End Property

        Public ReadOnly Property PurchaseOrderDetail As IPurchaseOrderDetailRepo Implements IRepositoryManager.PurchaseOrderDetail
            Get
                If _PodeRepo Is Nothing Then
                    _PodeRepo = New PurchaseOrderDetailRepo(_repositoryContext)

                End If

                Return _PodeRepo
            End Get
        End Property

        Public ReadOnly Property PurchaseStockDetail As IPurchaseStockDetailRepo Implements IRepositoryManager.PurchaseStockDetail
            Get
                If _StockDetail Is Nothing Then
                    _StockDetail = New PurchaseStockDetailRepo(_repositoryContext)
                End If

                Return _StockDetail
            End Get
        End Property
    End Class

End Namespace