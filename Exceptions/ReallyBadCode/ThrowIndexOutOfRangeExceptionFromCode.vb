Public Module ThrowIndexOutOfRangeExceptionFromCode
	Public Function AccessArray(ByVal values As Integer(), ByVal index As Integer) As Integer
		If index < values.GetLowerBound(0) OrElse index > values.GetUpperBound(0) Then
			Throw New IndexOutOfRangeException("Bad index value.")
		End If

		Return values(index)
	End Function
End Module
