using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Core.UnitTests;
using NUnit.Framework;

namespace Microsoft.Maui.Controls.Xaml.UnitTests
{
	public class Bz44216Behavior : Behavior<ContentPage>
	{
		static readonly BindableProperty MinLenghProperty = BindableProperty.Create("MinLengh", typeof(int), typeof(Bz44216Behavior), 1);

		public int MinLengh
		{
			get { return (int)base.GetValue(MinLenghProperty); }
			private set { base.SetValue(MinLenghProperty, value > 0 ? value : 1); }
		}
	}

	[XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class Bz44216 : ContentPage
	{
		public Bz44216()
		{
			InitializeComponent();
		}

		public Bz44216(bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}

		[TestFixture]
		class Tests
		{
			[TestCase(true)]
			[TestCase(false)]
			public void DonSetValueOnPrivateBP(bool useCompiledXaml)
			{
				if (useCompiledXaml)
					Assert.Throws(new BuildExceptionConstraint(7, 26, s => s.Contains("No property,")), () => MockCompiler.Compile(typeof(Bz44216)));
				else
					Assert.Throws(new XamlParseExceptionConstraint(7, 26, s => s.StartsWith("Cannot assign property", StringComparison.Ordinal)), () => new Bz44216(useCompiledXaml));
			}
		}
	}
}
