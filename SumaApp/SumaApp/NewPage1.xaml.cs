    namespace SumaApp;

public partial class NewPage1 : ContentPage
{
    double m_origen, m_destino, m_resultado;
    public NewPage1()
    {
        InitializeComponent();
    }

    private void convertir_btn_Clicked(object sender, EventArgs e)
    {
        // 1. Validar que el campo no esté vacío y que se haya seleccionado un ítem del Picker
        if (string.IsNullOrEmpty(moneda_origen_entry.Text) || picker_monedas.SelectedIndex == -1)
        {
            moneda_destino_entry.Text = "Error: Por favor ingresa un monto y selecciona una moneda";
          moneda_destino_entry.TextColor = Colors.Red; // Cambiar el color del texto a rojo para indicar error
            return;
        }
        if (m_origen<0)
        {
            moneda_destino_entry.Text = "Error: Por favor ingresa un monto valido";
            moneda_destino_entry.TextColor = Colors.Red; // Cambiar el color del texto a rojo para indicar error
            return;
        }

        // 2. Intento de conversión segura reemplazando coma por punto si es necesario
        string textoLimpio = moneda_origen_entry.Text.Replace(',', '.');

        if (double.TryParse(textoLimpio, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double monto))
        {
            // Validación de números negativos:
            if (monto < 0)
            {
                moneda_destino_entry.Text="Error: El monto no puede ser negativo";
                moneda_destino_entry.TextColor = Colors.Red;
                return;
            }

            double resultado = 0;
            string monedaSeleccionada = picker_monedas.SelectedItem.ToString();

            switch (monedaSeleccionada)
            {
                case "Pesos mexicanos":
                    resultado = monto * 17.04; // Ajusta según la tasa deseada
                    break;
                case "Euros":
                    resultado = monto * 0.86;
                    break;
                case "Soles":
                    resultado = monto * 3.37;
                    break;
            }

            // 3. Mostrar el resultado formateado a 2 decimales
            moneda_destino_entry.Text = resultado.ToString("0.00");
            moneda_destino_entry.TextColor = Colors.Green; // Cambiar el color del texto a negro para
        }
        else
        {
            moneda_destino_entry.Text= "Ingresa un monto numérico válido";
            moneda_destino_entry.TextColor = Colors.Red; // Cambiar el color del texto a rojo para indicar error
        }

    }
}
