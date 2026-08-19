namespace SumaApp
{
    public partial class MainPage : ContentPage
    {
        double n1, n2, total;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(primer_numero_entry.Text) || string.IsNullOrEmpty(segundo_numero_entry.Text))
            {
                resultado_entry.Text = "Por favor, ingrese ambos números.";
                resultado_entry.TextColor = Colors.Red;
                return;
            }

            bool esNumero1Valido = double.TryParse(primer_numero_entry.Text, out n1);
            bool esNumero2Valido = double.TryParse(segundo_numero_entry.Text, out n2);

            if (esNumero1Valido && esNumero2Valido)
            {
                total = n1 + n2;
                resultado_entry.Text = total.ToString();
                resultado_entry.TextColor = Colors.Green;
            }
            else
            {
                // Si ingresó letras o caracteres no numéricos
                resultado_entry.Text ="Error Por favor, ingresa únicamente valores numéricos válidos";
                resultado_entry.TextColor = Colors.Red;
            }
        }
    }
}
