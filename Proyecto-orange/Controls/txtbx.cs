namespace Proyecto_orange.Controls;

public partial class txtbx : UserControl
{
    private Label usutextbg;
    private Label usutextTitleLabel;
    private TextBox txtusu;
    private Panel panel;
    private bool isPasswordVisible;
    public event EventHandler<bool> NoNullChanged;

    private bool _nonull;

    public bool nonull
    {
        get { return _nonull; }
        set
        {
            if (_nonull != value)
            {
                _nonull = value;
                OnNotNullChanged(_nonull);
            }
        }
    }

    protected virtual void OnNotNullChanged(bool newValue)
    {
        NoNullChanged?.Invoke(this, newValue);
    }

    public bool IsPasswordVisible
    {
        get { return isPasswordVisible; }
        set
        {
            isPasswordVisible = value;
            // Actualizar la visibilidad del texto en el TextBox
            txtusu.PasswordChar = value ? '\0' : '\u25CF';
        }
    }

    // Agregar una propiedad para el tipo del txtbx
    public string Tipo { get; private set; }
        
    public CheckBox CheckBoxPass { get; set; }

    public txtbx(Label p_usutextbg, Label p_usutextTitleLabel, string title, TextBox textUsu, Panel p_panel, int ancho,
        Point p, string tipo, bool check, CheckBox cbShow = null)
    {
        nonull = check;
        panel = p_panel;
        Tipo = tipo; // Establecemos el tipo del txtbx

        InitializeComponent();

        usutextbg = new Label();
        usutextbg.BackColor = Color.FromArgb(186, 186, 186);
        usutextbg.BorderStyle = BorderStyle.None;
        usutextbg.Location = p;
        usutextbg.AutoSize = false;

        usutextTitleLabel = new Label();
        usutextTitleLabel.Text = title;
        usutextTitleLabel.ForeColor = Color.Gray;
        usutextTitleLabel.BackColor = usutextbg.BackColor;
        usutextTitleLabel.Font = new Font("Arial", 9, FontStyle.Regular);
        usutextTitleLabel.Location = new Point(0, 0);
        usutextTitleLabel.AutoSize = true;
        usutextbg.Controls.Add(usutextTitleLabel);

        txtusu = new TextBox();
        txtusu.Multiline = true;
        txtusu.BackColor = usutextbg.BackColor;
        txtusu.Font = new Font("Arial", 12, FontStyle.Regular);
        txtusu.Location = new Point(0, usutextTitleLabel.Height);
        txtusu.Height = txtusu.PreferredHeight;
        txtusu.BorderStyle = BorderStyle.None;
        usutextbg.Controls.Add(txtusu);

        usutextbg.Height = usutextTitleLabel.Height + txtusu.Height;
        usutextbg.Width = ancho;
        txtusu.Width = usutextbg.Width;
        panel.Controls.Add(usutextbg);

        txtusu.Enter += usuFoc;
        txtusu.Leave += usuLost;
        txtusu.TextChanged += Nonulltext;
        if (tipo == "ci")
        {
            txtusu.MaxLength = 8;
            txtusu.KeyPress += textusu_KeyPress;
        }
        else
        {
            if (tipo == "pass")
            {
                txtusu.MaxLength = 32;    
                txtusu.PasswordChar = '\u25CF';
                if (cbShow != null)
                {
                    this.CheckBoxPass = cbShow; // Asigna el cbShow recibido como parámetro a la propiedad CheckBoxPass
                }
                else
                {
                    Console.WriteLine("ADVERTENCIA: Se esperaba una referencia a la CheckBox cbShow para el control txtbx de tipo \"pass\", pero no se proporcionó.");
                }
            }
            else
            {
                if (tipo == "text")
                {
                    txtusu.MaxLength = 32;
                    
                }
            }
        }
    }

    private void textusu_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true; // Cancela el evento para evitar que se agregue el carácter
        }
    }

    private void usuFoc(object sender, EventArgs e)
    {
        // Código a ejecutar cuando el TextBox recibe el foco
        // Por ejemplo, cambiar el color de fondo del TextBox
        usutextbg.BackColor = Color.White;
        txtusu.BackColor = usutextbg.BackColor;
        usutextTitleLabel.BackColor = usutextbg.BackColor;
        usutextbg.BorderStyle = BorderStyle.FixedSingle;
    }

    private void usuLost(object sender, EventArgs e)
    {
        usutextbg.BackColor = Color.FromArgb(186, 186, 186);
        txtusu.BackColor = usutextbg.BackColor;
        usutextTitleLabel.BackColor = usutextbg.BackColor;
        usutextbg.BorderStyle = BorderStyle.None;
    }

    public string txtleave()
    {
        return txtusu.Text;
    }



    public void cambio_tamaño(int ancho)
    {
        usutextbg.Width = ancho;
    }


    public void remove_txtbx()
    {
        panel.Controls.Remove(usutextbg);
    }

    public void re_add(Point p, Panel nuevo_panel)
    {
        usutextbg.Location = p;
        nuevo_panel.Controls.Add(usutextbg);
    }

    public void Nonulltext(object sender, EventArgs e)
    {
        if ((!string.IsNullOrEmpty(txtusu.Text)))
        {
            nonull = true;
        }
        else
        {
            nonull = false;
        }
    }
}