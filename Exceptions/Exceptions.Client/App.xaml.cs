using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace Exceptions.Client
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			this.DispatcherUnhandledException +=
				new DispatcherUnhandledExceptionEventHandler(
					this.OnAppDispatcherUnhandledException);
		}

		private void OnAppDispatcherUnhandledException(
			object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			MessageBox.Show("UNHANDLED EXCEPTION: " +
				Environment.NewLine + e.Exception.Message);
			e.Handled = true;
			this.Shutdown();
			Process.Start(Application.ResourceAssembly.Location);
		}
	}
}
