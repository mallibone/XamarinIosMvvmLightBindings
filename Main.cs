using UIKit;
using MVVMLightBinding.ViewModel;

namespace MVVMLightBinding
{
	public class Application
	{
		private static ViewModelLocator _locator;

		public static ViewModelLocator Locator
		{
			get
			{
				return _locator ?? (_locator = new ViewModelLocator());
			}
		}

		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}

		public static class Colors
		{
			public static readonly UIColor HighlightColor = UIColor.FromRGB(250, 40, 212);
			public static readonly UIColor MainBackgroundColor = UIColor.White;
			public static readonly UIColor TextInputBackgroundColor = UIColor.FromRGB(200, 200, 200);
		}
	}
}
