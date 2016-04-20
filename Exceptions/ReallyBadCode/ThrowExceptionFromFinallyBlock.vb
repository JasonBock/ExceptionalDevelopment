Public Module ThrowExceptionFromFinallyBlock
	Public Sub ThrowIt()
		Try
			CreateExceptions.ThrowIt("2")
		Finally
			Throw New NotSupportedException()
		End Try
	End Sub
End Module
