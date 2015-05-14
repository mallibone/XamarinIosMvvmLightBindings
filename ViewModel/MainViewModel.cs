using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace MVVMLightBinding.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		private string _theInput;
		private string _theResponse;
		private RelayCommand _submitTextCommand;

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel ()
		{
			SubmitTextCommand = new RelayCommand (HandleSubmitTextCommand, () => CanExecuteSubmitText);
			CanExecuteSubmitText = true;

			TheResponse = "Awaiting your input";
		}

		public string TheInput {
			get {
				return _theInput;
			}
			set {
				_theInput = value;
				RaisePropertyChanged (() => TheInput);
			}
		}

		public string TheResponse {
			get {
				return _theResponse;
			}
			set {
				if (value == _theResponse) return;
				_theResponse = value;
				RaisePropertyChanged (() => TheResponse);
			}
		}

		public RelayCommand SubmitTextCommand {
			get {
				return _submitTextCommand;
			}
			private set {
				_submitTextCommand = value;
			}
		}

		public bool CanExecuteSubmitText {
			get;
			set;
		}

		private void HandleSubmitTextCommand ()
		{
			CanExecuteSubmitText = false;

			TheResponse = "You just entered: " + TheInput;

			CanExecuteSubmitText = true;
		}
	}
}