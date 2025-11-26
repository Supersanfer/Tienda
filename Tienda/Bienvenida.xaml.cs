namespace Tienda;

public partial class Bienvenida : ContentPage
{
    private IDispatcherTimer timer;
    public Bienvenida()
	{
		InitializeComponent();
		IniciarReloj();
	}

	private void IniciarReloj()
	{
        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
		timer.Tick += (s, e) =>
		{
			lblFechaHoraActual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
		};
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        timer.Start();
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        timer.Stop();
    }
}