
using TaskCenter.Model;

namespace TaskCenter.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TaskDetail : ContentPage
{
	public TaskDetail()
	{
		InitializeComponent();
	}
	Model.TaskData _task;
    public TaskDetail(Model.TaskData task)
    {
        InitializeComponent();
		Title = "Edit";
		_task = task;
		nameEntry.Text = task.ToDo;
		nameEntry.Focus();
    }

    async void Button_Clicked(object sender, EventArgs e)
    {
		if (string.IsNullOrWhiteSpace(nameEntry.Text))
		{
			await DisplayAlert("Invalid", "Invalid value, please add text", "OK");
		}
		else if (_task != null)
		{
			UpdateTask();
		}
		else 
		
            AddNewTask();
    }

    async void AddNewTask()
    {
		await App.MyDatabase.CreateTask(new Model.TaskData
		{
			ToDo = nameEntry.Text
		});
		await Navigation.PopAsync();
    }

	async void UpdateTask()
	{
		_task.ToDo = nameEntry.Text;
		await App.MyDatabase.UpdateTask(_task);
		await Navigation.PopAsync();
	}
}