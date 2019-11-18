using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyToDoApp.Services;
using MyToDoApp.Views;

namespace MyToDoApp
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			DependencyService.Register<BackendDataStore>();
			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
