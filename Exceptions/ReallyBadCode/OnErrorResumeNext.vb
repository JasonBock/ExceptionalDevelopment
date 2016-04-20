Public Module OnErrorResumeNext
	Public Function ReliableCode(ByVal data As String, _
		ByVal divisor As Integer) As Integer
		On Error Resume Next
		Dim dividend = data.Length
		Dim result = dividend \ divisor
		Return result
	End Function
End Module
