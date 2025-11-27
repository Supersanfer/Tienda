using System;
using System.Threading.Tasks;
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
        // la variable e es la encargada de obtener el Objeto que vamos a usar. Simplemente tenemos que convertirlo al tipo de objeto que queramos
        if (e.SelectedItem != null)
        {
            var clienteSeleccionado = e.SelectedItem as Cliente;
            entNombre.Text = clienteSeleccionado.Nombre;
            entApellidos.Text = clienteSeleccionado.Apellidos;
            entCiudad.Text = clienteSeleccionado.Ciudad;
            entCorreoElectronico.Text = clienteSeleccionado.Correo;
            entComentarios.Text = clienteSeleccionado.Comentarios;
            if (clienteSeleccionado.Vip)
            {
                cbEsVip.IsChecked = true;
            }
            else
            {
                cbEsVip.IsChecked = false;
            }
            ((ListView)sender).SelectedItem = null; // Deseleccionar el elemento
        }
    }


    private async void Anyadir_Clicked(object sender, EventArgs e)
    {
        var correo = entCorreoElectronico.Text;
        // TODO: Validar que no exista el cliente y que todos los campos esten rellenos
        if (CamposTienenContenido())
        {
            if (!App.ClienteService.ExisteCliente(correo))
            {
                Cliente cliente = new Cliente
                {
                    Nombre = entNombre.Text,
                    Apellidos = entApellidos.Text,
                    Ciudad = entCiudad.Text,
                    Correo = entCorreoElectronico.Text,
                    Comentarios = entComentarios.Text,
                    Vip = cbEsVip.IsChecked
                };
                App.ClienteService.AgregarCliente(cliente);
                await DisplayAlert("¡Éxito!", "El cliente se ha creado correctamente", "Ok");
                lvClientes.ItemsSource =  App.ClienteService.ObtenerClientes();

            }
            else
            {
                await DisplayAlert("Error", "Ya existe ese cliente", "Ok");
            }

        }
        else
        {
            await DisplayAlert("Error", "Se deben rellenar todos los campos", "Ok");
        }
    }

    private async void Modificar_Clicked(object sender, EventArgs e)
    {
        var correo = entCorreoElectronico.Text;
        var clienteSeleccionado = App.ClienteService.ObtenerCliente(correo);

        if (CamposTienenContenido())
        {
            if(clienteSeleccionado!=null)
            {
                clienteSeleccionado.Nombre = entNombre.Text;
                clienteSeleccionado.Apellidos = entApellidos.Text;
                clienteSeleccionado.Ciudad = entCiudad.Text;
                clienteSeleccionado.Correo = entCorreoElectronico.Text;
                clienteSeleccionado.Comentarios = entComentarios.Text;
                clienteSeleccionado.Vip = cbEsVip.IsChecked;

                lvClientes.ItemsSource = App.ClienteService.ObtenerClientes();
                await DisplayAlert("¡Éxito!", "El cliente se ha modificado correctamente", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "El cliente a modificar no existe en la lista", "Ok");
            }

        }
        else
        {
            await DisplayAlert("Error", "Se deben completar todos los campos", "Ok");
        }
    }
    private async void Borrar_Clicked(object sender, EventArgs e)
    {
        var correo = entCorreoElectronico.Text;
        var cliente = App.ClienteService.ObtenerCliente(correo);
        if (!string.IsNullOrEmpty(entCorreoElectronico.Text))
        {
            if (App.ClienteService.ExisteCliente(correo))
            {
                App.ClienteService.EliminarCliente(correo);
                await DisplayAlert("¡Éxito!", "Se ha eliminado correctamente al usuario", "Ok");
                lvClientes.ItemsSource = App.ClienteService.ObtenerClientes();
            }
            else
            {
                await DisplayAlert("Error", "No existe el cliente que desea borrar", "Ok");
            }
        }
        else
        {
            await DisplayAlert("Error", "Se debe rellenar el correo electrónico", "Ok");
        }
    }
    private void Limpiar_Clicked(object sender, EventArgs e)
    {
        entNombre.Text = "";
        entApellidos.Text = "";
        entCiudad.Text = "";
        entCorreoElectronico.Text = "";
        entComentarios.Text = "";
        cbEsVip.IsChecked = false;
    }

    private bool CamposTienenContenido()
    {
        return !string.IsNullOrEmpty(entNombre.Text)
            &&
            !string.IsNullOrEmpty(entApellidos.Text)
            &&
            !string.IsNullOrEmpty(entCiudad.Text)
            &&
            !string.IsNullOrEmpty(entCorreoElectronico.Text)
            &&
            !string.IsNullOrEmpty(entComentarios.Text);
    }
}
