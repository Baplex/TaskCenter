namespace TaskCenter.Views;

public partial class MainMenu : ContentPage
{
	public MainMenu()
	{
		InitializeComponent();
	}

    private async void btnTasks_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Tasks());
    }
}