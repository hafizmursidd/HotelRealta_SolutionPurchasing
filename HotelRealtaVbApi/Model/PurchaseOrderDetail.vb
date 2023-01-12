Namespace Model


    Public Class PurchaseOrderDetail
        Private _podeId As Integer
        Private _podePoheId As Integer
        Private _podeOrderQty As Int16
        Private _podePrice As Decimal
        Private _podeLineTotal As Decimal
        Private _podeReceivedQty As Decimal
        Private _podeRejectedQty As Decimal
        Private _podeStockedQty As Decimal
        Private _podeModifiedDate As Date
        Private _podeStockId As Integer

        Public Sub New()
        End Sub
        Public Sub New(podeId As Integer, podePoheId As Integer, podeOrderQty As Short, podePrice As Decimal, podeLineTotal As Decimal, podeReceivedQty As Decimal, podeRejectedQty As Decimal, podeStockedQty As Decimal, podeModifiedDate As Date, podeStockId As Integer)
            _podeId = podeId
            _podePoheId = podePoheId
            _podeOrderQty = podeOrderQty
            _podePrice = podePrice
            _podeLineTotal = podeLineTotal
            _podeReceivedQty = podeReceivedQty
            _podeRejectedQty = podeRejectedQty
            _podeStockedQty = podeStockedQty
            _podeModifiedDate = podeModifiedDate
            _podeStockId = podeStockId
        End Sub

        Public Overrides Function ToString() As String
            Return $"            
            Pode Id         = {PodeId}
            Pode Pohe ID    = {PodePoheId}
            Pode OrderQTY   = {PodeOrderQty}
            Pode Price      = {PodePrice}
            Pode Line Total = {PodeLineTotal}
            Pode ReceivQty  = {PodeReceivedQty}
            Pode RejectQty  = {PodeRejectedQty}
            Pode StockQty   = {PodeStockedQty}
            Pode ModifiedDate = {PodeModifiedDate}
            Pode StockId    = {PodeStockId}"
        End Function
        Public Property PodeId As Integer
            Get
                Return _podeId
            End Get
            Set(value As Integer)
                _podeId = value
            End Set
        End Property

        Public Property PodePoheId As Integer
            Get
                Return _podePoheId
            End Get
            Set(value As Integer)
                _podePoheId = value
            End Set
        End Property

        Public Property PodeOrderQty As Short
            Get
                Return _podeOrderQty
            End Get
            Set(value As Short)
                _podeOrderQty = value
            End Set
        End Property

        Public Property PodePrice As Decimal
            Get
                Return _podePrice
            End Get
            Set(value As Decimal)
                _podePrice = value
            End Set
        End Property

        Public Property PodeLineTotal As Decimal
            Get
                Return _podeLineTotal
            End Get
            Set(value As Decimal)
                _podeLineTotal = value
            End Set
        End Property

        Public Property PodeReceivedQty As Decimal
            Get
                Return _podeReceivedQty
            End Get
            Set(value As Decimal)
                _podeReceivedQty = value
            End Set
        End Property

        Public Property PodeRejectedQty As Decimal
            Get
                Return _podeRejectedQty
            End Get
            Set(value As Decimal)
                _podeRejectedQty = value
            End Set
        End Property

        Public Property PodeStockedQty As Decimal
            Get
                Return _podeStockedQty
            End Get
            Set(value As Decimal)
                _podeStockedQty = value
            End Set
        End Property

        Public Property PodeModifiedDate As Date
            Get
                Return _podeModifiedDate
            End Get
            Set(value As Date)
                _podeModifiedDate = value
            End Set
        End Property

        Public Property PodeStockId As Integer
            Get
                Return _podeStockId
            End Get
            Set(value As Integer)
                _podeStockId = value
            End Set
        End Property


    End Class


End Namespace