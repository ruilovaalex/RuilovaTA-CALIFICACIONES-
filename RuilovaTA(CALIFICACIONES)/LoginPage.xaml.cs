using RuilovaTA_CALIFICACIONES;

namespace RuilovaTA_CALIFICACIONES_;

public partial class LoginPage : ContentPage
{
    // Vectores solicitados para la conexión
    string[] user = { "Carlos", "Ana", "Jose" };
    string[] pass = { "carlos123", "ana123", "jose123" };

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string usuarioIngresado = txtUser.Text;
        string passwordIngresada = txtPass.Text;
        bool autenticado = false;

        // Recorrido de vectores para validar credenciales
        for (int i = 0; i < user.Length; i++)
        {
            if (user[i] == usuarioIngresado && pass[i] == passwordIngresada)
            {
                autenticado = true;

                // Mensaje de bienvenida con el nombre del usuario conectado
                await DisplayAlert("Bienvenido", $"¡Hola {user[i]}, has ingresado correctamente!", "Aceptar");

                // Redirección a la ventana principal de calificaciones
                if (Application.Current != null)
                {
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                }
                break;
            }
        }

        if (!autenticado)
        {
            await DisplayAlert("Error de Acceso", "Usuario o contraseña no válidos.", "Reintentar");
        }
    }
}