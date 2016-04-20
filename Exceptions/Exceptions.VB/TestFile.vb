Imports System.Collections.Generic
Imports System.Linq

Namespace Medtox.RMS
	Public NotInheritable Class TestFile
		Private _items As List(Of Integer)

		Public Sub New(items As List(Of Integer))
			Me.Items = items
		End Sub

		Public Function Total() As Integer
			Return Me.Items.Sum()
		End Function

		Public Property Items As List(Of Integer)
			Get
				RaiseEvent ItemsRetrieved(
					Me, EventArgs.Empty)
				Return Me._items
			End Get
			Private Set(value As List(Of Integer))
				Me._items = value
			End Set
		End Property

		Public Event ItemsRetrieved As EventHandler
	End Class
End Namespace
