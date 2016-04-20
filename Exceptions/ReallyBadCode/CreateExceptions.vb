Public Module CreateExceptions
	Public Sub ThrowIt(ByVal switch As String)
		If switch = "2" Then
			Throw New ArgumentException("Nothing works.", "switch")
		End If
	End Sub

	Public Sub ThrowNonpublicException()
		Throw New NonPublicCustomException()
	End Sub

	Public Sub CreateArgumentExceptionWithWrongArgumentName( _
		ByVal index As Integer)
		If index = 0 Then
			Throw New ArgumentException("index", "This is a bad index value.")
		End If
	End Sub

	Public Sub CreateArgumentExceptionWithNoParameters(ByVal index As Integer)
		If index = 0 Then
			Throw New ArgumentException()
		End If
	End Sub
End Module
