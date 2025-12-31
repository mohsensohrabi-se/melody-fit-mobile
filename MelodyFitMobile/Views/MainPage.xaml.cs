namespace MelodyFitMobile.Views
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void  OnSignUpClicked(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void OnLoginClicked(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

    }
}
