Public Class FilterEmitter
	Public Function Divide(ByVal x As Integer, ByVal y As Integer) As Integer
		Try
			Return x \ y
		Catch e As DivideByZeroException When x Mod 2 = 0

		End Try
	End Function
End Class
