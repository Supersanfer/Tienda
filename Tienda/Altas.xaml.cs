using System;
using Tienda;
namespace Tienda;

public partial class Altas : ContentPage
{
	public Altas()
	{
		InitializeComponent();
        lvClientes.ItemsSource = App.ClienteService.ObtenerClientes();
    }

    private void lvClientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }
}