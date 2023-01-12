Imports System.Data.SqlClient
Imports HotelRealtaVbNetApi.Context
Imports HotelRealtaVbNetApi.Model
Imports HotelRealtaVbNetApi.Repository

Namespace Repository



    Public Class PurchaseOrderDetailRepo
        Implements IPurchaseOrderDetailRepo

        'dependence injection

        Private ReadOnly _context As IRepositoryContext
        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function FindAllPode() As List(Of PurchaseOrderDetail) Implements IPurchaseOrderDetailRepo.FindAllPode
            Dim podeList As New List(Of PurchaseOrderDetail)

            Dim sqlStatement As String = "SELECT * FROM purchasing.purchase_order_detail;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlStatement}

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            podeList.Add(New PurchaseOrderDetail() With {
                                .PodeId = reader.GetInt32(0),
                                .PodePoheId = reader.GetInt32(1),
                                .PodeOrderQty = reader.GetInt16(2),
                                .PodePrice = reader.GetDecimal(3),
                                .PodeLineTotal = If(reader.IsDBNull(4), 0, reader.GetDecimal(4)),
                                .PodeReceivedQty = reader.GetDecimal(5),
                                .PodeRejectedQty = reader.GetDecimal(6),
                                .PodeStockedQty = If(reader.IsDBNull(7), 0, reader.GetDecimal(7)),
                                .PodeModifiedDate = reader.GetDateTime(8),
                                .PodeStockId = reader.GetInt32(9)
                            })
                        End While

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                End Using
            End Using
            Return podeList
        End Function

        Public Function FindPodeById(id As Integer) As PurchaseOrderDetail Implements IPurchaseOrderDetailRepo.FindPodeById
            Dim pode As New PurchaseOrderDetail With {.PodeId = id}

            Dim stmtSQL As String = "SELECT * FROM Purchasing.Purchase_order_detail
                                     WHERE pode_id = @podeId"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmtSQL}

                    cmd.Parameters.AddWithValue("@podeId", id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        If reader.HasRows Then
                            reader.Read()
                            pode.PodePoheId = reader.GetInt32(1)
                            pode.PodeOrderQty = reader.GetInt16(2)
                            pode.PodePrice = reader.GetDecimal(3)
                            pode.PodeLineTotal = If(reader.IsDBNull(4), "0", reader.GetDecimal(4))
                            pode.PodeReceivedQty = reader.GetDecimal(5)
                            pode.PodeRejectedQty = reader.GetDecimal(6)
                            pode.PodeStockedQty = If(reader.IsDBNull(7), "0", reader.GetDecimal(7))
                            pode.PodeModifiedDate = reader.GetDateTime(8)
                            pode.PodeStockId = reader.GetInt32(9)
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return pode
        End Function

        Public Function DeletePode(id As Integer) As Integer Implements IPurchaseOrderDetailRepo.DeletePode
            Dim rowEffect As Int32 = 0

            Dim sqlStatement As String = "DELETE FROM Purchasing.purchase_order_detail
                                         WHERE pode_id = @podeId"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlStatement}

                    cmd.Parameters.AddWithValue("@podeId", id)
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

        Public Function CreatePode(ByVal pode As PurchaseOrderDetail) As PurchaseOrderDetail Implements IPurchaseOrderDetailRepo.CreatePode
            Dim newPode As New PurchaseOrderDetail()

            Dim sqlStatement As String = "INSERT INTO purchasing.purchase_stock_detail
                                (pode_pohe_id, pode_order_qty, pode_price,
                                 pode_received_qty, pode_rejected_qty, pode_stock_id) " &
                                 "VALUES " &
                                 "(@podePoheId, @podeOrderQty, @podePrice,
                                   @podeReceivedQty, @podeRejectedQty, @podeStockId) " &
                                 "SELECT CAST(scope_identity() as int)"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlStatement}

                    cmd.Parameters.AddWithValue("@podePoheId", pode.PodePoheId)
                    cmd.Parameters.AddWithValue("@podeOrderQty", pode.PodeOrderQty)
                    cmd.Parameters.AddWithValue("@podePrice", pode.PodePrice)
                    cmd.Parameters.AddWithValue("@podeReceivedQty", pode.PodeReceivedQty)
                    cmd.Parameters.AddWithValue("@podeRejectedQty", pode.PodeRejectedQty)
                    cmd.Parameters.AddWithValue("@podeStockId", pode.PodeStockId)

                    Try
                        conn.Open()

                        Dim newId = cmd.ExecuteScalar()
                        newPode = FindPodeById(newId)

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                End Using
            End Using

            Return newPode
        End Function

        Public Function UpdatePodeBySP(id As Integer, podePoheId As Integer, podeOrderQty As Short,
                                       podePrice As Decimal, podeReceivedQty As Decimal, podeRejectedQty As Decimal,
                                       podeStockId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IPurchaseOrderDetailRepo.UpdatePodeBySP

            Dim updatePode As New PurchaseOrderDetail()
            Dim sqlStatement As String = "[Purchasing].[spUpdatePode]"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlStatement, .CommandType = Data.CommandType.StoredProcedure}

                    cmd.Parameters.AddWithValue("@PodeId", id)
                    cmd.Parameters.AddWithValue("@PodePoheId", podePoheId)
                    cmd.Parameters.AddWithValue("@PodeOrderQty", podeOrderQty)
                    cmd.Parameters.AddWithValue("@PodePrice", podePrice)
                    cmd.Parameters.AddWithValue("@PodeReceivedQty", podeReceivedQty)
                    cmd.Parameters.AddWithValue("@PodeRejectedQty", podeRejectedQty)
                    cmd.Parameters.AddWithValue("@PodeStockId", podeStockId)

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

        Public Function UpdatePodeById(id As Integer, podePoheId As Integer, podeOrderQty As Short, podePrice As Decimal, podeReceivedQty As Decimal, podeRejectedQty As Decimal, podeStockId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IPurchaseOrderDetailRepo.UpdatePodeById
            Dim updatePode As New PurchaseOrderDetail()
            Dim sqlStatement As String = "UPDATE Purchasing.purchase_order_detail " &
                                        "SET " &
                                        "pode_pohe_id = @podePoheId, 
		                                 pode_order_qty = @PodeOrderQty, 
		                                 pode_price = @PodePrice, 
		                                 pode_received_qty = @PodeReceivedQty,
		                                 pode_rejected_qty = @PodeRejectedQty,
		                                 pode_stock_id = @PodeStockId " &
                                        "WHERE pode_id = @PodeId"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlStatement}

                    cmd.Parameters.AddWithValue("@PodeId", id)
                    cmd.Parameters.AddWithValue("@PodePoheId", podePoheId)
                    cmd.Parameters.AddWithValue("@PodeOrderQty", podeOrderQty)
                    cmd.Parameters.AddWithValue("@PodePrice", podePrice)
                    cmd.Parameters.AddWithValue("@PodeReceivedQty", podeReceivedQty)
                    cmd.Parameters.AddWithValue("@PodeRejectedQty", podeRejectedQty)
                    cmd.Parameters.AddWithValue("@PodeStockId", podeStockId)

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



    End Class

End Namespace