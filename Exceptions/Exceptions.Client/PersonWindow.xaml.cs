using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Exceptions.Client
{
	public partial class PersonWindow : Window
	{
		private const int WaitTime = 3000;

		public PersonWindow()
		{
			InitializeComponent();
		}

		private string FormatPerson(UIInformation information)
		{
			string formattedPerson = string.Empty;

			int age = 0;

			if (int.TryParse(information.Age, out age))
			{
				var person = new Person(
					new Name(information.FirstName, information.LastName),
					age);
				formattedPerson = $"{person.Name.FirstName} {person.Name.LastName}, {person.Age}";
			}

			return formattedPerson;
		}

		private void OnCreateClick(object sender, RoutedEventArgs e) => this.nameResults.Content = this.FormatPerson(
				new UIInformation
				{
					Age = this.ageValue.Text,
					FirstName = this.firstNameValue.Text,
					LastName = this.lastNameValue.Text
				});

		private void OnCreateViaBackgroundWorkerClick(object sender, RoutedEventArgs e)
		{
			this.SetButtonEnabled(false);

			var worker = new BackgroundWorker();

			worker.DoWork += (doSender, doEventArgs) =>
			{
				Thread.Sleep(PersonWindow.WaitTime);
				doEventArgs.Result = this.FormatPerson(doEventArgs.Argument as UIInformation);
			};

			worker.RunWorkerCompleted += (runSender, runEventArgs) =>
			{
				this.SetButtonEnabled(true);
				this.nameResults.Content = runEventArgs.Result as string;
			};

			worker.RunWorkerAsync(new UIInformation
			{
				Age = this.ageValue.Text,
				FirstName = this.firstNameValue.Text,
				LastName = this.lastNameValue.Text
			});
		}

		private void SetButtonEnabled(bool isEnabled)
		{
			this.create.IsEnabled = isEnabled;
			this.createViaBackgroundWorker.IsEnabled = isEnabled;
			this.createViaThread.IsEnabled = isEnabled;
			this.createViaTask.IsEnabled = isEnabled;
			this.createViaNonAwaitedTask.IsEnabled = isEnabled;
		}

		private void OnCreateViaThreadClick(object sender, RoutedEventArgs e)
		{
			this.SetButtonEnabled(false);

			ThreadPool.QueueUserWorkItem((state) =>
			{
				Thread.Sleep(PersonWindow.WaitTime);
				var information = state as UIInformation;
				var result = this.FormatPerson(information);
				Dispatcher.Invoke(new Action(() =>
				{
					this.nameResults.Content = result;
					this.SetButtonEnabled(true);
				}));
			},
			new UIInformation
			{
				Age = this.ageValue.Text,
				FirstName = this.firstNameValue.Text,
				LastName = this.lastNameValue.Text
			});
		}

		private async void OnCreateViaTask(object sender, RoutedEventArgs e)
		{
			this.SetButtonEnabled(false);

			var information = new UIInformation
			{
				Age = this.ageValue.Text,
				FirstName = this.firstNameValue.Text,
				LastName = this.lastNameValue.Text
			};

			var result = await Task.Factory.StartNew(async () =>
			{
				await Task.Delay(PersonWindow.WaitTime);
				return this.FormatPerson(information);
			}).Result;

			this.nameResults.Content = result;
			this.SetButtonEnabled(true);
		}

		private void OnCreateViaNonAwaitedTask(object sender, RoutedEventArgs e)
		{
			this.SetButtonEnabled(false);

			var information = new UIInformation
			{
				Age = this.ageValue.Text,
				FirstName = this.firstNameValue.Text,
				LastName = this.lastNameValue.Text
			};

			var result = Task.Factory.StartNew(() =>
			{
				return this.FormatPerson(information);
			});

			this.SetButtonEnabled(true);
		}
	}
}
