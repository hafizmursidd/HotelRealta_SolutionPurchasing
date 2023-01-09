Imports HotelRealtaVbNetApi.Context
Imports HotelRealtaVbNetApi.Repository

Namespace Base


    Public Class RepositoryManager
        Implements IRepositoryManager

        Private _PohRepo As IPurchaseOrderHeaderRepo

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
    End Class

End Namespace