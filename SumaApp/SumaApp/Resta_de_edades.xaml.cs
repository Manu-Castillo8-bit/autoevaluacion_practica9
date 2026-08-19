namespace SumaApp;

public partial class Resta_de_edades : ContentPage
{
    double edad1, edad2, resultado;
    public Resta_de_edades()
    {
        InitializeComponent();
    }

    private void Resta_btn_Clicked(object sender, EventArgs e)
    {
    

        // 1. Validar que los campos no estén vacíos
        if (string.IsNullOrEmpty(edad1_entry.Text) || string.IsNullOrEmpty(edad2_entry.Text))
        {
            resultado_entry.Text="Error: Introduce ambas edades";
            resultado_entry.TextColor=Colors.Red;
            return;
        }

        // 2. Intentar la conversión numérica
        bool esEdad1Valida = double.TryParse(edad1_entry.Text, out edad1);
        bool esEdad2Valida = double.TryParse(edad2_entry.Text, out edad2);

        if (!esEdad1Valida || !esEdad2Valida)
        {
            resultado_entry.Text = "Error: Ingresa números válidos ";
            resultado_entry.TextColor=Colors.Red;
            return;
        }

        // 3. Validar que no se ingrese 0 o edades negativas
        if (edad1 <= 0 || edad2 <= 0)
        {
            resultado_entry.Text = "Error: Las edades deben ser números mayores a cero";
            resultado_entry.TextColor=Colors.Red;
            return;
        }

        // 4. Calcular la diferencia absoluta (evita números negativos)
        resultado = Math.Abs(edad1 - edad2);
        resultado_entry.Text = "La diferencia de edades es: " + resultado.ToString();
        resultado_entry.TextColor = Colors.Green;
        resultado_entry.FontAttributes = FontAttributes.Bold;
    }
}
