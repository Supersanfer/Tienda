namespace Tienda;

public partial class ConsultaListas : ContentPage
{
	public ConsultaListas()
	{
		InitializeComponent();
        CollectionViewClientes.ItemsSource = App.ClienteService.ObtenerClientes();
        CargarCiudades();
	}

    private void CargarCiudades()
    {
        var ciudades = App.ClienteService.ObtenerClientes().Select(c => c.Ciudad).Distinct().ToList();
        ciudades.Insert(0, "Todas");
        PickerCiudad.ItemsSource = ciudades;
    }

    private void PickerCiudad_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void PickerVip_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}