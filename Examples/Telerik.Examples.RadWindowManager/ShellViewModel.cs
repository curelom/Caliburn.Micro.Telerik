using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Telerik.Examples.RadWindowManager
{
	[Export(typeof (IShell))]
	public class ShellViewModel : IShell
	{
		private readonly IWindowManager windowManager;

		[ImportingConstructor]
		public ShellViewModel(IWindowManager windowManager)
		{
			this.windowManager = windowManager;
		}

		public void Show()
		{
			var dialog = new DialogViewModel();
			windowManager.Show(dialog);
		}

		public void ShowDialog()
		{
			var dialog = new DialogViewModel();
			windowManager.ShowDialog(dialog);
		}

		public void ShowPopup()
		{
			var popup = new PopupViewModel();
			windowManager.ShowPopup(popup);
		}

		public void ShowNotification()
		{
			windowManager.ShowNotification(new NotificationViewModel {Message = "Hi there!"}, 2000);
		}

		public void ShowAlert()
		{
			windowManager.Alert("This is the title", "And here comes the content...");
		}

		public void ShowConfirmation()
		{
			windowManager.Confirm(
				"This is the title", 
				"What should be confirmed, text...", 
				() => windowManager.Alert("result", "is: confirmed"),
				() => windowManager.Alert("result", "is: cancelled"));
		}

		public void ShowPrompt()
		{
			windowManager.Prompt("Give me", "A value (default is 'something'):", "something", s => windowManager.Alert("Prompt value", "Is: " + s));
		}

		public void DialogWithResponceButtons()
		{
			windowManager.ShowDialog(new DialogWithResponceButtonsViewModel());
		}
	}
}