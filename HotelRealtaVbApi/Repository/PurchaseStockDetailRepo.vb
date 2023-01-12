Imports System.Data.SqlClient
Imports HotelRealtaVbNetApi.Context
Imports HotelRealtaVbNetApi.Model

Namespace Repository


    Public Class PurchaseStockDetailRepo
        Implements IPurchaseStockDetailRepo

        'dependecy injection
        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function FindStockDetailbyID(id As Integer) As PurchaseStockDetail Implements IPurchaseStockDetailRepo.FindStockDetailbyID
            Dim std As New PurchaseStockDetail With {.StodId = id}

            Dim sqlStatement = "SELECT * FROM Purchasing.Stock_Detail
                                 WHERE stod_id = @id"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlStatement}

                    cmd.Parameters.AddWithValue("@id", id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        If reader.HasRows Then
                            reader.Read()
                            std.StodStockId = reader.GetInt32(1)
                            std.StodBarcodeNumber = reader.GetString(2)
                            std.StodStatus = reader.GetString(3)
                            std.StodNotes = reader.GetString(4)     'If(reader.IsDBNull(4), "0", reader.GetDecimal(4))
                            std.StodFaciId = reader.GetInt32(5)
                            std.StodPoheId = reader.GetInt32(6) 'If(reader.IsDBNull(6), "0", reader.GetDecimal(6))

                        End If
                        reader.Close()
                        conn.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return std
        End Function

        Public Function FindAllStockDetail() As List(Of PurchaseStockDetail) Implements IPurchaseStockDetailRepo.FindAllStockDetail
            Dim stodeList As New List(Of PurchaseStockDetail)
            Dim sqlStatement As String = "SELECT * FROM Purchasing.stock_detail"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using command As New SqlCommand With {.Connection = conn, .CommandText = sqlStatement}

                    Try
                        conn.Open()
                        Dim reader = command.ExecuteReader()
                        While reader.Read()
                            stodeList.Add(New PurchaseStockDetail() With {
                            .StodId = reader.GetInt32(0),
                            .StodPoheId = reader.GetInt32(1),
                            .StodBarcodeNumber = reader.GetString(2),
                            .StodStatus = reader.GetString(3),
                            .StodNotes = reader.GetString(4),
                            .StodFaciId = reader.GetInt32(5),
                            .StodStockId = reader.GetInt32(6)
                            })
                        End While
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return stodeList
        End Function

        Public Function CreateNewStode(stode As PurchaseStockDetail) As PurchaseStockDetail Implements IPurchaseStockDetailRepo.CreateNewStode
            Dim newStode As New PurchaseStockDetail()

            Dim sqlStatement As String = "INSERT INTO purchasing.stock_detail 
                                          (stod_stock_id, stod_barcode_number, stod_status, 
                                           stod_notes, stod_faci_id, stod_pohe_id) 
                                           VALUES " &
                                           "(@stod_stock_id, @stod_barcode_number, @stod_status, 
                                           @stod_notes, @stod_faci_id, @stod_pohe_id) " &
                                           "SELECT CAST(scope_identity() as int)"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using command As New SqlCommand With {.Connection = conn, .CommandText = sqlStatement}

                    command.Parameters.AddWithValue("@stod_stock_id", stode.StodPoheId)
                    command.Parameters.AddWithValue("@stod_barcode_number", stode.StodBarcodeNumber)
                    command.Parameters.AddWithValue("@stod_status", stode.StodStatus)
                    command.Parameters.AddWithValue("@stod_notes", stode.StodNotes)
                    command.Parameters.AddWithValue("@stod_faci_id", stode.StodFaciId)
                    command.Parameters.AddWithValue("@stod_pohe_id", stode.StodPoheId)

                    Try
                        conn.Open()

                        Dim newId = command.ExecuteScalar()
                        newStode = FindStockDetailbyID(newId)

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                End Using
            End Using

            Return newStode
        End Function

        Public Function DeleteStockDetail(id As Integer) As Integer Implements IPurchaseStockDetailRepo.DeleteStockDetail
            Dim rowEffect As Integer = 0

            Dim sqlStatement As String = "DELETE FROM purchasing.stock_detail WHERE stod_id = @stockDetId"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlStatement}

                    cmd.Parameters.AddWithValue("@stockDetId", id)
                    Try
                        conn.Open()
                        rowEffect = cmd.ExecuteNonQuery()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                End Using
            End Using

            Console.WriteLine("dadajd: " & rowEffect)
            Return rowEffect
        End Function

        Public Function UpdateStockDetailBySp(id As Integer, StodStock_id As Integer, StodBarcode_number As String, StodStatus As String, StodNotes As String, StodFaci_id As Integer, StodPohe_id As Integer, Optional showCommand As Boolean = False) As Boolean Implements IPurchaseStockDetailRepo.UpdateStockDetailBySp

            Dim updateStode As New PurchaseOrderDetail()
            Dim sqlStatement As String = "[Purchasing].[spUpdateStockDetail]"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlStatement, .CommandType = Data.CommandType.StoredProcedure}

                    cmd.Parameters.AddWithValue("@StodId ", id)
                    cmd.Parameters.AddWithValue("@StodStockId", StodPohe_id)
                    cmd.Parameters.AddWithValue("@StodBarcodeNumber", StodBarcode_number)
                    cmd.Parameters.AddWithValue("@StodStatus", StodStatus)
                    cmd.Parameters.AddWithValue("@StodNotes", StodNotes)
                    cmd.Parameters.AddWithValue("@StodFaciId", StodFaci_id)
                    cmd.Parameters.AddWithValue("@StodPoheId", StodPohe_id)

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

        Public Function UpdateStockDetailByID(id As Integer, StodStock_id As Integer, StodBarcode_number As String, StodStatus As String, StodNotes As String, StodFaci_id As Integer, StodPohe_id As Integer, Optional showCommand As Boolean = False) As Boolean Implements IPurchaseStockDetailRepo.UpdateStockDetailByID
            Dim updateStode As New PurchaseOrderDetail()
            Dim sqlStatement As String = "UPDATE [Purchasing].[stock_detail] " &
                                         "SET " &
                                         "stod_stock_id = @StodStockId,
                                          stod_barcode_number = @StodBarcodeNumber,
                                          stod_status = @StodStatus,
                                          stod_notes = @StodNotes,
                                          stod_faci_id = @StodFaciId,
                                          stod_pohe_id = @StodPoheId " &
                                          "WHERE stod_id = @StodId"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlStatement}

                    cmd.Parameters.AddWithValue("@StodId ", id)
                    cmd.Parameters.AddWithValue("@StodStockId", StodPohe_id)
                    cmd.Parameters.AddWithValue("@StodBarcodeNumber", StodBarcode_number)
                    cmd.Parameters.AddWithValue("@StodStatus", StodStatus)
                    cmd.Parameters.AddWithValue("@StodNotes", StodNotes)
                    cmd.Parameters.AddWithValue("@StodFaciId", StodFaci_id)
                    cmd.Parameters.AddWithValue("@StodPoheId", StodPohe_id)


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
    End Class

End Namespace