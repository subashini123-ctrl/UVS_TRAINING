using CommunityToolkit.Maui.Views;

public partial class StudentPopup : Popup
{
    public StudentPopup()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    public object NameEntry { get; private set; }

    private void OnAddClicked(object sender, EventArgs e)
    {
        Close(NameEntry.Text);
    }

    
}