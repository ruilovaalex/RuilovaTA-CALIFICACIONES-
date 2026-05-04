namespace RuilovaTA_CALIFICACIONES_;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Configuramos la ventana inicial para que sea nuestra página de Login
        return new Window(new LoginPage());
    }
}