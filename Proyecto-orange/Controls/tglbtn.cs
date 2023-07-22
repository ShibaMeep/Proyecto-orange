using System.Windows.Forms;

namespace Proyecto_orange.Controls;

public partial class tglbtn : UserControl
{
    private bool isOn;

    public bool IsOn
    {
        get { return isOn; }
        set
        {
            isOn = value;
            UpdateAppearance();
        }
    }
    public tglbtn()
    {

        InitializeComponent();

        // Configuración inicial
        isOn = false;
        UpdateAppearance();
    }
    private void UpdateAppearance()
    {
        // Personaliza la apariencia del botón en función del estado
        if (isOn)
        {
            BackColor = Color.OrangeRed; // Color cuando está activado
            Text = "ON";
        }
        else
        {
            BackColor = Color.Green; // Color cuando está desactivado
            Text = "OFF";
        }
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);

        // Cambia el estado cuando se hace clic en el botón
        IsOn = !IsOn;
    }
}
