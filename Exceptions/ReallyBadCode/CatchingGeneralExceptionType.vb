Public Module CatchingGeneralExceptionType
	Public Sub CatchIt()
		Try
			CreateExceptions.ThrowIt("2")
		Catch ex As Exception
		End Try
	End Sub
End Module
