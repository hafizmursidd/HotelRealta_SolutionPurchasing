Imports System.Data.SqlTypes

Namespace Model


    Public Class PurchaseOrderHeader
        Private _poheId As Integer
        Private _poheNumber As String
        Private _poheStatus As Byte
        Private _poheOrderDate As Date
        Private _poheSubtotal As Decimal
        Private _poheTax As Decimal
        Private _poheTotalAmount As Decimal
        Private _poheRefund As Decimal
        Private _poheArrivalDate As Date
        Private _pohePayType As String
        Private _poheEmpId As Integer
        Private _poheVendorId As Integer

        Public Sub New()
        End Sub

        Public Sub New(poheId As Integer, poheNumber As String, poheStatus As Byte, poheOrderDate As Date, poheSubtotal As String, poheTax As Decimal, poheTotalAmount As Decimal, poheRefund As Decimal, poheArrivalDate As Date, pohePayType As String, poheEmpId As Integer, poheVendorId As Integer)
            _poheId = poheId
            _poheNumber = poheNumber
            _poheStatus = poheStatus
            _poheOrderDate = poheOrderDate
            _poheSubtotal = poheSubtotal
            _poheTax = poheTax
            _poheTotalAmount = poheTotalAmount
            _poheRefund = poheRefund
            _poheArrivalDate = poheArrivalDate
            _pohePayType = pohePayType
            _poheEmpId = poheEmpId
            _poheVendorId = poheVendorId
        End Sub

        Public Overrides Function ToString() As String
            Return $"            
            Pohe Id         = {PoheId}
            PoheNumber      = {PoheNumber}
            PoheStatus      = {PoheStatus}
            PoheOrderDate   = {PoheOrderDate}
            PoheSubtotal    = {PoheSubtotal}
            PoheTax         = {PoheTax}
            PoheTotalAmount = {PoheTotalAmount}
            PoheRefund      = {PoheRefund}
            ArrivalDate     = {PoheArrivalDate}
            PohePayType     = {PohePayType}
            PoheEmpId       = {PoheEmpId}
            PoheVendorId    = {PoheVendorId}"

        End Function

        Public Property PoheId As Integer
            Get
                Return _poheId
            End Get
            Set(value As Integer)
                _poheId = value
            End Set
        End Property

        Public Property PoheNumber As String
            Get
                Return _poheNumber
            End Get
            Set(value As String)
                _poheNumber = value
            End Set
        End Property

        Public Property PoheStatus As Byte
            Get
                Return _poheStatus
            End Get
            Set(value As Byte)
                _poheStatus = value
            End Set
        End Property

        Public Property PoheOrderDate As Date
            Get
                Return _poheOrderDate
            End Get
            Set(value As Date)
                _poheOrderDate = value
            End Set
        End Property

        Public Property PoheSubtotal As Decimal
            Get
                Return _poheSubtotal
            End Get
            Set(value As Decimal)
                _poheSubtotal = value
            End Set
        End Property

        Public Property PoheTax As Decimal
            Get
                Return _poheTax
            End Get
            Set(value As Decimal)
                _poheTax = value
            End Set
        End Property

        Public Property PoheTotalAmount As Decimal
            Get
                Return _poheTotalAmount
            End Get
            Set(value As Decimal)
                _poheTotalAmount = value
            End Set
        End Property

        Public Property PoheRefund As Decimal
            Get
                Return _poheRefund
            End Get
            Set(value As Decimal)
                _poheRefund = value
            End Set
        End Property

        Public Property PoheArrivalDate As Date
            Get
                Return _poheArrivalDate
            End Get
            Set(value As Date)
                _poheArrivalDate = value
            End Set
        End Property

        Public Property PohePayType As String
            Get
                Return _pohePayType
            End Get
            Set(value As String)
                _pohePayType = value
            End Set
        End Property

        Public Property PoheEmpId As Integer
            Get
                Return _poheEmpId
            End Get
            Set(value As Integer)
                _poheEmpId = value
            End Set
        End Property

        Public Property PoheVendorId As Integer
            Get
                Return _poheVendorId
            End Get
            Set(value As Integer)
                _poheVendorId = value
            End Set
        End Property



    End Class

End Namespace