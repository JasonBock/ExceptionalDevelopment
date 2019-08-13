using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace Exceptions.Utilities.Extensions
{
	public static class ExceptionExtensions
	{
		public static void Print(this Exception @this) => @this.Print(Console.Out);

		public static void Print(this Exception @this, TextWriter writer)
		{
			if(@this == null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			if(writer == null)
			{
				throw new ArgumentNullException(nameof(writer));
			}

			writer.WriteLine($"Type Name: {@this.GetType().FullName}");

			writer.WriteLine($"\tSource: {@this.Source}");
			writer.WriteLine($"\tTargetSite: {@this.TargetSite}");
			writer.WriteLine($"\tMessage: {@this.Message}");
			writer.WriteLine($"\tStackTrace: {@this.StackTrace}");
			writer.WriteLine($"\tHelpLink: {@this.HelpLink}");

			@this.PrintStackTrace(writer);
			@this.PrintData(writer);
			@this.PrintProperties(writer);

			if(@this.InnerException != null)
			{
				@this.InnerException.Print(writer);
			}
		}

		private static void PrintProperties(this Exception @this, 
			TextWriter writer)
		{
			writer.WriteLine("\tProperties:");
			var exceptionType = typeof(Exception);

			foreach(var property in @this.GetType().GetProperties())
			{
				if(exceptionType.GetProperty(property.Name) == null)
				{
					writer.WriteLine($"\t\tName: {property.Name}, Value: {property.GetValue(@this, null)}");
				}
			}		
		}
		
		private static void PrintData(this Exception @this, 
			TextWriter writer)
		{
			writer.WriteLine("\tData:");

			foreach(DictionaryEntry dataPair in @this.Data)
			{
				writer.WriteLine($"\t\tKey: {dataPair.Key.ToString()}, Value: {dataPair.Value.ToString()}");
			}
		}

		private static void PrintStackTrace(this Exception @this, 
			TextWriter writer)
		{
			writer.WriteLine("\tStackTrace (via Diagnostics):");

			var trace = new StackTrace(@this, true);

			for(var i = 0; i < trace.FrameCount; i++)
			{
				writer.WriteLine($"\t\tFrame: {i}");
				var frame = trace.GetFrame(i);
				writer.WriteLine($"\t\t\tMethod: {frame.GetMethod()}");
				writer.WriteLine($"\t\t\tFile: {frame.GetFileName()}");
				writer.WriteLine($"\t\t\tColumn: {frame.GetFileColumnNumber()}");
				writer.WriteLine($"\t\t\tLine: {frame.GetFileLineNumber()}");
				writer.WriteLine($"\t\t\tIL Offset: {frame.GetILOffset()}");
				writer.WriteLine($"\t\t\tNative Offset: {frame.GetNativeOffset()}");
			}
		}
	}
}