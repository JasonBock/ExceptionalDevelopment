Imports System.Collections.Generic

Public Module Enumerations
	Public Sub Enumerate(ByVal randoms As IList(Of Random))
		For Each random In randoms
			Console.Out.WriteLine(random.Next())
		Next
	End Sub
End Module
