Public Class ThrowExceptionFromToString
	Public Overrides Function ToString() As String
		Throw New NotImplementedException()
	End Function
End Class
