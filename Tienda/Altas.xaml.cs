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

    private void Anyadir_Clicked(object sender, EventArgs e)
    {

    }
    private void Modificar_Clicked(object sender, EventArgs e)
    {

    }
    private void Borrar_Clicked(object sender, EventArgs e)
    {

    }
    private void Limpiar_Clicked(object sender, EventArgs e)
    {

    }
}