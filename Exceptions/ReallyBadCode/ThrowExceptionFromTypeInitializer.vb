Public Class ThrowExceptionFromTypeInitializer
	Private _Id As Guid

	Shared Sub New()
		Throw New NotSupportedException("Don't use me.")
	End Sub

	Public Property Id() As Guid
		Get
			Return Me._Id
		End Get
		Set(ByVal value As Guid)
			Me._Id = value
		End Set
	End Property
End Class
