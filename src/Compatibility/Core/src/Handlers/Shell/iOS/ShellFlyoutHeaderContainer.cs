using System;
namespace Microsoft.Maui.Controls.Platform.Compatibility
{
	internal class ShellFlyoutHeaderContainer : UIContainerView
	{
		public ShellFlyoutHeaderContainer(View view) : base(view)
		{
		}

		public override Thickness Margin
		{
			get
			{
				if (!View.IsSet(View.MarginProperty))
				{
					var newMargin = new Thickness(0, (float)Controls.Compatibility.Platform.iOS.Platform.SafeAreaInsetsForWindow.Top, 0, 0);

					if (newMargin != View.Margin)
					{
						View.Margin = newMargin;
					}
				}

				return View.Margin;
			}
		}
	}
}
