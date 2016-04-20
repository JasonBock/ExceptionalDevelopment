using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Exceptions.Utilities.Extensions
{
	public static class ExceptionExtensions
	{
		public static void Print(this Exception @this)
		{
			@this.Print(Console.Out);
		}

		public static void Print(this Exception @this, TextWriter writer)
		{
			writer.WriteLine("Type Name: {0}", @this.GetType().FullName);

			writer.WriteLine("\tSource: {0}", @this.Source);
			writer.WriteLine("\tTargetSite: {0}", @this.TargetSite);
			writer.WriteLine("\tMessage: {0}", @this.Message);
			writer.WriteLine("\tStackTrace: {0}", @this.StackTrace);
			writer.WriteLine("\tHelpLink: {0}", @this.HelpLink);

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
					writer.WriteLine("\t\tName: {0}, Value: {1}",
						property.Name, property.GetValue(@this, null));
				}
			}		
		}
		
		private static void PrintData(this Exception @this, 
			TextWriter writer)
		{
			writer.WriteLine("\tData:");

			foreach(DictionaryEntry dataPair in @this.Data)
			{
				writer.WriteLine("\t\tKey: {0}, Value: {1}",
					dataPair.Key.ToString(), dataPair.Value.ToString());
			}
		}

		private static void PrintStackTrace(this Exception @this, 
			TextWriter writer)
		{
			writer.WriteLine("\tStackTrace (via Diagnostics):");

			var trace = new StackTrace(@this, true);

			for(var i = 0; i < trace.FrameCount; i++)
			{
				writer.WriteLine("\t\tFrame: {0}", i);
				var frame = trace.GetFrame(i);
				writer.WriteLine("\t\t\tMethod: {0}", frame.GetMethod());
				writer.WriteLine("\t\t\tFile: {0}", frame.GetFileName());
				writer.WriteLine("\t\t\tColumn: {0}", frame.GetFileColumnNumber());
				writer.WriteLine("\t\t\tLine: {0}", frame.GetFileLineNumber());
				writer.WriteLine("\t\t\tIL Offset: {0}", frame.GetILOffset());
				writer.WriteLine("\t\t\tNative Offset: {0}", frame.GetNativeOffset());
			}
		}
	}
}
