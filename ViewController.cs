using System;
using Foundation;
using UIKit;
using MVVMLightBinding.ViewModel;
using GalaSoft.MvvmLight.Helpers;

namespace MVVMLightBinding
{
	public partial class ViewController : UIViewController
	{
		private Binding<string, string> _textLabelBinding;
		private Binding _textFieldBinding;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		private MainViewModel Vm {
			get {
				return Application.Locator.Main;
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			HideKeyboardHandling ();

			_textLabelBinding = this.SetBinding (
				() => Vm.TheResponse,
				() => TextLabel.Text);

			_textFieldBinding = this.SetBinding (
                () => EntryTextField.Text)
                .ObserveSourceEvent ("EditingDidEnd")
				.WhenSourceChanges (() => Vm.TheInput = EntryTextField.Text);

			SubmitTextButton.SetCommand("TouchUpInside", Vm.SubmitTextCommand);
		}


		void HideKeyboardHandling ()
		{
			EntryTextField.ShouldReturn = textField => {
				textField.ResignFirstResponder ();
				return true;
			};
			var g = new UITapGestureRecognizer (() => View.EndEditing (true));
			g.CancelsTouchesInView = false;
			//for iOS5
			View.AddGestureRecognizer (g);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.

		}
	}
}

