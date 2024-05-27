



using TaskCenter.Model;

namespace TaskCenter.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Tasks : ContentPage
{
	
	public Tasks()
	{
		InitializeComponent();
	}
	protected override async void OnAppearing()
	{
		try
		{
			base.OnAppearing();
			myCollectionView.ItemsSource = await App.MyDatabase.ReadTasks();
		}
		catch { }
	}

    async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new TaskDetail());
    }

    async void SwipeItem_Invoked(object sender, EventArgs e)
    {
		var item = sender as SwipeItem;
		var emp = item.CommandParameter as TaskData;
		await Navigation.PushAsync(new TaskDetail(emp));
    }
    async void SwipeItem_Invoked_1(object sender, EventArgs e)
    {
        var item = sender as SwipeItem;
        var emp = item.CommandParameter as TaskData;
		var result = await DisplayAlert("Complete", "Did you actually complete this task?", "Yes", "No");
		if (result)
		{
			await App.MyDatabase.DeleteTask(emp);
			myCollectionView.ItemsSource = await App.MyDatabase.ReadTasks();
		}
    }
}