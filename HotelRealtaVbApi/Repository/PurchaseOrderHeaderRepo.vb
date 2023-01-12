Imports System.Data.SqlClient
Imports HotelRealtaVbNetApi.Context
Imports HotelRealtaVbNetApi.Model
Imports HotelRealtaVbNetApi.Repository

Public Class PurchaseOrderHeaderRepo
    Implements IPurchaseOrderHeaderRepo

    'dependecy injection
    Private ReadOnly _context As IRepositoryContext

    Public Sub New(context As IRepositoryContext)
        _context = context
    End Sub



    Public Function FindAllPohe() As List(Of PurchaseOrderHeader) Implements IPurchaseOrderHeaderRepo.FindAllPohe
        Dim poheList As New List(Of PurchaseOrderHeader)

        'statement
        Dim stmt As String = "SELECT pohe_id, pohe_number, pohe_status,
                              pohe_order_date, pohe_subtotal, pohe_tax,
                              pohe_total_amount, pohe_refund, pohe_arrival_date,
                              pohe_pay_type, pohe_emp_id, pohe_vendor_id
                              FROM purchasing.purchase_order_header;"

        Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
            Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                Try
                    conn.Open()
                    Dim reader = cmd.ExecuteReader()

                    While reader.Read()
                        poheList.Add(New PurchaseOrderHeader() With {
                            .PoheId = reader.GetInt32(0),
                            .PoheNumber = reader.GetString(1),
                            .PoheStatus = reader.GetByte(2),
                            .PoheOrderDate = reader.GetDateTime(3),
                            .PoheSubtotal = If(reader.IsDBNull(4), 0, reader.GetDecimal(4)),
                            .PoheTax = reader.GetDecimal(5),
                            .PoheTotalAmount = If(reader.IsDBNull(6), 0, reader.GetDecimal(6)),
                            .PoheRefund = reader.GetDecimal(7),
                            .PoheArrivalDate = reader.GetDateTime(8),
                            .PohePayType = reader.GetString(9),
                            .PoheEmpId = reader.GetInt32(10),
                            .PoheVendorId = reader.GetInt32(11)
                        })
                    End While

                    reader.Close()
                    conn.Close()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try

            End Using
        End Using

        Return poheList
    End Function

    Public Function FindPoheById(id As Integer) As PurchaseOrderHeader Implements IPurchaseOrderHeaderRepo.FindPoheById
        Dim poh As New PurchaseOrderHeader With {.PoheId = id}

        Dim stmt As String = "SELECT * FROM Purchasing.purchase_order_header
                              WHERE pohe_id = @poheId"

        Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
            Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}

                cmd.Parameters.AddWithValue("@poheId", id)

                Try
                    conn.Open()
                    Dim reader = cmd.ExecuteReader()

                    If reader.HasRows Then
                        reader.Read()
                        poh.PoheNumber = reader.GetString(1)
                        poh.PoheStatus = reader.GetByte(2)
                        poh.PoheOrderDate = reader.GetDateTime(3)
                        poh.PoheSubtotal = If(reader.IsDBNull(4), "0", reader.GetDecimal(4))
                        poh.PoheTax = reader.GetDecimal(5)
                        poh.PoheTotalAmount = If(reader.IsDBNull(6), "0", reader.GetDecimal(6))
                        poh.PoheRefund = reader.GetDecimal(7)
                        poh.PoheArrivalDate = reader.GetDateTime(8)
                        poh.PohePayType = reader.GetString(9)
                        poh.PoheEmpId = reader.GetInt32(10)
                        poh.PoheVendorId = reader.GetInt32(11)
                    End If
                    reader.Close()
                    conn.Close()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            End Using
        End Using

        Return poh
    End Function
    Public Function DeletePohe(id As Integer) As Integer Implements IPurchaseOrderHeaderRepo.DeletePohe
        Dim rowEffect As Int32 = 0

        Dim stmt As String = "DELETE FROM Purchasing.purchase_order_header
                              WHERE pohe_id = @poheId"

        Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
            Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}

                cmd.Parameters.AddWithValue("@poheId", id)
                Try
                    conn.Open()
                    rowEffect = cmd.ExecuteNonQuery()
                    conn.Close()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try

            End Using
        End Using

        Return rowEffect

    End Function

    Public Function UpdatePoheBySP(id As Integer, poheNumber As String, poheStatus As Byte,
                                   poheTax As Decimal, poherefund As Decimal, poheArrival As Date,
                                   pohePayType As String, pohEmpId As Integer, poheVendorID As Integer,
                                   Optional showCommand As Boolean = False) As Boolean Implements IPurchaseOrderHeaderRepo.UpdatePoheBySP
        Dim updatePohe As New PurchaseOrderHeader()

        Dim stmt As String = "Purchasing.SpUpdatePOHE"


        Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
            Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt, .CommandType = Data.CommandType.StoredProcedure}

                cmd.Parameters.AddWithValue("@ID", id)
                cmd.Parameters.AddWithValue("@Number", poheNumber)
                cmd.Parameters.AddWithValue("@PoheStatus", poheStatus)
                cmd.Parameters.AddWithValue("@PoheTax", poheTax)
                cmd.Parameters.AddWithValue("@PoheRefund", poherefund)
                cmd.Parameters.AddWithValue("@PoheArrivalDate", poheArrival)
                cmd.Parameters.AddWithValue("@PohePayType", pohePayType)
                cmd.Parameters.AddWithValue("@PoheEmpId", pohEmpId)
                cmd.Parameters.AddWithValue("@PoheVendorId", poheVendorID)

                If showCommand Then
                    Console.WriteLine(cmd.CommandText)
                End If

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    conn.Close()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try

            End Using
        End Using
        Return True

    End Function
    Public Function UpdatePoheById(id As Integer, poheNumber As String, poheStatus As Byte, poheTax As Decimal, poherefund As Decimal, poheArrival As Date, pohePayType As String, pohEmpId As Integer, poheVendorID As Integer, Optional showCommand As Boolean = False) As Boolean Implements IPurchaseOrderHeaderRepo.UpdatePoheById
        Dim updatePohe As New PurchaseOrderHeader()

        Dim stmt As String = "UPDATE purchasing.purchase_order_header " &
                             "SET " &
                             "pohe_number = @Number, pohe_status = @PoheStatus, " &
                             "pohe_tax = @PoheTax, pohe_refund=@PoheRefund, " &
                             "pohe_arrival_date = @PoheArrivalDate, pohe_pay_type=@PohePayType, " &
                             "pohe_emp_id=@PoheEmpId, pohe_vendor_id=@PoheVendorId " &
                             "WHERE pohe_id = @ID;"


        Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
            Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}

                cmd.Parameters.AddWithValue("@ID", id)
                cmd.Parameters.AddWithValue("@Number", poheNumber)
                cmd.Parameters.AddWithValue("@PoheStatus", poheStatus)
                cmd.Parameters.AddWithValue("@PoheTax", poheTax)
                cmd.Parameters.AddWithValue("@PoheRefund", poherefund)
                cmd.Parameters.AddWithValue("@PoheArrivalDate", poheArrival)
                cmd.Parameters.AddWithValue("@PohePayType", pohePayType)
                cmd.Parameters.AddWithValue("@PoheEmpId", pohEmpId)
                cmd.Parameters.AddWithValue("@PoheVendorId", poheVendorID)

                If showCommand Then
                    Console.WriteLine(cmd.CommandText)
                End If

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    conn.Close()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try

            End Using
        End Using

        Return True
    End Function

    Public Function CreatePohe(pohe As PurchaseOrderHeader) As PurchaseOrderHeader Implements IPurchaseOrderHeaderRepo.CreatePohe
        Dim newPohe As New PurchaseOrderHeader()

        Dim stmt As String = "INSERT INTO purchasing.purchase_order_header 
                             (pohe_number, pohe_status, pohe_tax, 
                              pohe_refund, pohe_arrival_date, pohe_pay_type, 
                              pohe_emp_id, pohe_vendor_id) " &
                              "VALUES " &
                              "(@Number, @PoheStatus, @PoheTax, " &
                              "@PoheRefund, @PoheArrivalDate, @PohePayType, " &
                              "@PoheEmpId, @PoheVendorId) " &
                              "SELECT CAST(scope_identity() as int)"

        Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
            Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}

                cmd.Parameters.AddWithValue("@Number", pohe.PoheNumber)
                cmd.Parameters.AddWithValue("@PoheStatus", pohe.PoheStatus)
                cmd.Parameters.AddWithValue("@PoheTax", pohe.PoheTax)
                cmd.Parameters.AddWithValue("@PoheRefund", pohe.PoheRefund)
                cmd.Parameters.AddWithValue("@PoheArrivalDate", pohe.PoheArrivalDate)
                cmd.Parameters.AddWithValue("@PohePayType", pohe.PohePayType)
                cmd.Parameters.AddWithValue("@PoheEmpId", pohe.PoheEmpId)
                cmd.Parameters.AddWithValue("@PoheVendorId", pohe.PoheVendorId)


                Try
                    conn.Open()

                    Dim newId = cmd.ExecuteScalar()
                    newPohe = FindPoheById(newId)

                    conn.Close()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try

            End Using
        End Using
        Return newPohe

    End Function

    Public Function FindAllPoheAsync() As Task(Of List(Of PurchaseOrderHeader)) Implements IPurchaseOrderHeaderRepo.FindAllPoheAsync
        Throw New NotImplementedException()
    End Function

End Class
