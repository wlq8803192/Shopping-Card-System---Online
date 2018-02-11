Partial Class dsDailyRep3
    Partial Class tbRepDataTable

        Private Sub tbRepDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DailyAMTColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
