using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace Exceptions.Client
{
	public partial class App 
		: Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			this.DispatcherUnhandledException += (s, dispatcherArgs) =>
			{
				MessageBox.Show($"UNHANDLED EXCEPTION:{Environment.NewLine}{dispatcherArgs.Exception.Message}");
				dispatcherArgs.Handled = true;
				this.Shutdown();
				Process.Start(Application.ResourceAssembly.Location);
			};

			TaskScheduler.UnobservedTaskException += (s, exceptionArgs) =>
			{
				MessageBox.Show($"UNOBSERVED TASK EXCEPTION:{Environment.NewLine}{exceptionArgs.Exception.Message}");
			};
		}
	}
}
