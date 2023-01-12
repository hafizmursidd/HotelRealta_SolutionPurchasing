Namespace Model

    Public Class PurchaseStockDetail
        Private _stodId As Integer
        Private _stodStockId As Integer
        Private _stodBarcodeNumber As String
        Private _stodStatus As String
        Private _stodNotes As String
        Private _stodFaciId As Integer
        Private _stodPoheId As Integer

        Public Sub New()
        End Sub

        Public Sub New(stodId As Integer, stodStockId As Integer, stodBarcodeNumber As String, stodStatus As String, stodNotes As String, stodFaciId As Integer, stodPoheId As Integer)
            _stodId = stodId
            _stodStockId = stodStockId
            _stodBarcodeNumber = stodBarcodeNumber
            _stodStatus = stodStatus
            _stodNotes = stodNotes
            _stodFaciId = stodFaciId
            _stodPoheId = stodPoheId
        End Sub

        Public Overrides Function ToString() As String
            Return $"            
            Stod Id               = {StodId}
            Stod Stock ID         = {StodStockId}
            Stod Barcode Number   = {StodBarcodeNumber}
            Stod Status           = {StodStatus}
            Stod Notes            = {StodNotes}
            Stod Faci Id          = {StodFaciId}
            Stod Pohe Id          = {StodPoheId}"
        End Function
        Public Property StodId As Integer
            Get
                Return _stodId
            End Get
            Set(value As Integer)
                _stodId = value
            End Set
        End Property

        Public Property StodStockId As Integer
            Get
                Return _stodStockId
            End Get
            Set(value As Integer)
                _stodStockId = value
            End Set
        End Property

        Public Property StodBarcodeNumber As String
            Get
                Return _stodBarcodeNumber
            End Get
            Set(value As String)
                _stodBarcodeNumber = value
            End Set
        End Property

        Public Property StodStatus As String
            Get
                Return _stodStatus
            End Get
            Set(value As String)
                _stodStatus = value
            End Set
        End Property

        Public Property StodNotes As String
            Get
                Return _stodNotes
            End Get
            Set(value As String)
                _stodNotes = value
            End Set
        End Property

        Public Property StodFaciId As Integer
            Get
                Return _stodFaciId
            End Get
            Set(value As Integer)
                _stodFaciId = value
            End Set
        End Property

        Public Property StodPoheId As Integer
            Get
                Return _stodPoheId
            End Get
            Set(value As Integer)
                _stodPoheId = value
            End Set
        End Property




    End Class

End Namespace