namespace RuilovaTA_CALIFICACIONES;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (pkEstudiante.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Seleccione estudiante", "OK");
                return;
            }

            double seg1 = Convert.ToDouble(txtSeg1.Text);
            double exa1 = Convert.ToDouble(txtExa1.Text);

            double seg2 = Convert.ToDouble(txtSeg2.Text);
            double exa2 = Convert.ToDouble(txtExa2.Text);

            // VALIDAR NOTAS

            if (seg1 < 0 || seg1 > 10 ||
                exa1 < 0 || exa1 > 10 ||
                seg2 < 0 || seg2 > 10 ||
                exa2 < 0 || exa2 > 10)
            {
                await DisplayAlert("Error", "Notas entre 0 y 10", "OK");
                return;
            }

            // CÁLCULOS

            double parcial1 = (seg1 * 0.3) + (exa1 * 0.2);

            double parcial2 = (seg2 * 0.3) + (exa2 * 0.2);

            double final = parcial1 + parcial2;

            // MOSTRAR RESULTADOS

            lblParcial1.Text = parcial1.ToString("0.00");

            lblParcial2.Text = parcial2.ToString("0.00");

            lblFinal.Text = final.ToString("0.00");

            // ESTADO

            string estado = "";

            Color colorEstado = Colors.Gray;

            if (final >= 7)
            {
                estado = "✓ APROBADO";
                colorEstado = Colors.Green;
            }
            else if (final >= 5)
            {
                estado = "⚠ COMPLEMENTARIO";
                colorEstado = Colors.Orange;
            }
            else
            {
                estado = "✗ REPROBADO";
                colorEstado = Colors.Red;
            }

            lblEstado.Text = estado;
            lblEstado.TextColor = colorEstado;

            // ALERTA FINAL

            await DisplayAlert(
                "RESULTADOS",

                "Nombre: " + pkEstudiante.SelectedItem.ToString() + "\n" +
                "Fecha: " + dpFecha.Date.ToString() + "\n" +
                "Parcial 1: " + parcial1.ToString("0.00") + "\n" +
                "Parcial 2: " + parcial2.ToString("0.00") + "\n" +
                "Final: " + final.ToString("0.00") + "\n" +
                "Estado: " + estado,

                "OK");
        }
        catch
        {
            await DisplayAlert("Error", "Ingrese números válidos", "OK");
        }
    }
}