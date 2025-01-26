Class LockTimeFormatHelpPage
    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        textBox1.Text = My.Resources.TimeFormat
        textBox1.IsReadOnly = True
    End Sub
End Class
