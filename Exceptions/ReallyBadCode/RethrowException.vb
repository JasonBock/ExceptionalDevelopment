Public Module RethrowException
	Public Sub Rethrow()
		Try
			CreateExceptions.ThrowIt("2")
		Catch ex As ArgumentException
			Throw ex
		End Try
	End Sub
End Module
