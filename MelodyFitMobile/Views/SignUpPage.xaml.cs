using MelodyFitMobile.ViewModels;

namespace MelodyFitMobile.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
		BindingContext = new SignUpViewModel();
	}
}