using Proyecto_orange.Controls;
using Timer = System.Windows.Forms.Timer;

namespace Proyecto_orange;

public partial class Login : Form
{//==================================================================================================================
/*Aquí se definen todas las entidades, se hace así para que en caso de necesitar editar alguna
o cambiar algun valor se hace facil desde aquí, en vez de tener que buscar en el codigo
*/
    private Panel panelder;
    private Panel panelfull;
    private TextBox textUsu;
    private TextBox textPass;
    private PictureBox btnacc;
    public int l2y = 180;
    public int l1y = 80;
    private PictureBox btnclose;
    private int btnbar = 15;
    private PictureBox btnmin;
    private PictureBox logoor;
    private Label usutextbg;
    private Label usutextTitleLabel; 
    private Label passtextbg;
    private Label passtextTitleLabel;
    private Label introtxt;
    private bool colorbtn;
    private CheckBox cbshow;
    private bool isAnimating = false;
    private int finalX = 500; // Cambia estas coordenadas finales según sea necesario
    private int finalY = 75;
    private int animationSteps = 30; // Cantidad de pasos de la animación
    private int animationDuration; // Duración de la animación en milisegundos
    private txtbx usu;
    private txtbx txtbxPassword;


//==================================================================================================================
    public Login()
    {
//==================================================================================================================        
/*Aquí se inician todos los componentes del form (ventana), hay que tener en cuenta
 que se pueden poner cosas antes de esta linea pero almenos lo que afecta directamente al form no va a funcionar
*/
        
        InitializeComponent();

//==================================================================================================================        
//Aquí se agregan las características que va a tener el form

        FormBorderStyle = FormBorderStyle.None;
        Width = 1024;
        Height = 650;
        CenterToScreen();
        
//==================================================================================================================        
//Aquí defino y le doy características a cada item que va dentro del form, incluyendo paneles, botones, etc.

        panelfull = new Panel();
        panelfull.Dock = DockStyle.Fill;
        Controls.Add(panelfull);
        Image lbg = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/loginbg.jpg");
        panelfull.BackgroundImage = new Bitmap(lbg, 715, 650);
        
        
        panelder = new Panel();
        panelder.BackColor = Color.White;
        panelder.Dock = DockStyle.Left;
        panelder.Width = 310;

        Controls.Add(panelder);
        
       introtxt = new Label();
       introtxt.Text = "Inicia sesión con tu \ncuenta de Orange";
       introtxt.Font = new Font("Arial", 20, FontStyle.Bold);
       introtxt.Location = new Point(24, 159);
       introtxt.AutoSize = true;
       panelder.Controls.Add(introtxt);
      /*
       usutextbg = new Label();
       usutextbg.BackColor = Color.FromArgb(186,186,186);
       usutextbg.BorderStyle = BorderStyle.None;
       usutextbg.Location = new Point(43, 250);
       usutextbg.AutoSize = false;
       
       usutextTitleLabel = new Label();
       usutextTitleLabel.Text = "C.I:";
       usutextTitleLabel.ForeColor = Color.Gray;
       usutextTitleLabel.BackColor = usutextbg.BackColor;
       usutextTitleLabel.Font = new Font("Arial", 9, FontStyle.Regular);
       usutextTitleLabel.Location = new Point(0, 0);
       usutextTitleLabel.AutoSize = true;
       usutextbg.Controls.Add(usutextTitleLabel);

       textUsu = new TextBox();
       textUsu.Multiline = true;
       textUsu.BackColor = usutextbg.BackColor;
       textUsu.Font = new Font("Arial", 12, FontStyle.Regular);
       textUsu.Location = new Point(0, usutextTitleLabel.Height);
       textUsu.Height = textUsu.PreferredHeight;
       textUsu.BorderStyle = BorderStyle.None;
       textUsu.MaxLength = 8;
       usutextbg.Controls.Add(textUsu);

       usutextbg.Height = usutextTitleLabel.Height + textUsu.Height;
       usutextbg.Width = 234;
       textUsu.Width = usutextbg.Width;
       panelder.Controls.Add(usutextbg);
*/

      usu = new txtbx(usutextbg,usutextTitleLabel,"C.I",textUsu,panelder,234,new Point(43,250),"ci");
      
       cbshow = new CheckBox();
       cbshow.Location = new Point(45, 375);
       cbshow.Text = "Mostrar contraseña";
       cbshow.Font = new Font("Arial", 9, FontStyle.Bold);
       cbshow.AutoSize = true;
       cbshow.ForeColor = Color.DimGray;
       panelder.Controls.Add(cbshow);
       
       
       txtbxPassword = new txtbx(passtextbg,passtextTitleLabel,"Contraseña",textPass,panelder,234,new Point(43,309),"pass",cbshow);
       
       
       /*  passtextbg = new Label();
       passtextbg.BackColor = Color.FromArgb(186,186,186);
       passtextbg.BorderStyle = BorderStyle.None;
       passtextbg.Location = new Point(43, 309);
       passtextbg.AutoSize = false;
            
       passtextTitleLabel = new Label();
       passtextTitleLabel.Text = "Contraseña:";
       passtextTitleLabel.ForeColor = Color.Gray;
       passtextTitleLabel.BackColor = passtextbg.BackColor;
       passtextTitleLabel.Font = new Font("Arial", 9, FontStyle.Regular);
       passtextTitleLabel.Location = new Point(0, 0);
       passtextTitleLabel.AutoSize = true;
       passtextbg.Controls.Add(passtextTitleLabel);

       textPass = new TextBox();
       textPass.Multiline = true;
       textPass.PasswordChar = '\u25CF';
       textPass.BackColor = passtextbg.BackColor;
       textPass.Font = new Font("Arial", 12, FontStyle.Regular);
       textPass.Location = new Point(0, passtextTitleLabel.Height);
       textPass.Height = textPass.PreferredHeight;
       textPass.BorderStyle = BorderStyle.None;
       textPass.MaxLength = 32;
       passtextbg.Controls.Add(textPass);

       passtextbg.Height = passtextTitleLabel.Height + textPass.Height;
       passtextbg.Width = 234;
       textPass.Width = passtextbg.Width;
       panelder.Controls.Add(passtextbg);
*/

        btnacc = new PictureBox();
        btnacc.Location = new Point(125, 442);
        btnacc.Size = new Size(49,56);
        btnacc.BackColor = Color.Transparent;
        btnacc.BackgroundImage = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/boton_no.png");
        panelder.Controls.Add(btnacc);
     
        btnclose = new PictureBox();
        btnclose.Location = new Point(panelfull.Height + 40, 5);
        Image btnc = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/btnclose.png");
        btnclose.BackgroundImage = new Bitmap(btnc, btnbar, btnbar);
        btnclose.Size = new Size(btnbar , btnbar);
        btnclose.BackColor = Color.Transparent;
        panelfull.Controls.Add(btnclose);

        btnmin = new PictureBox();
        btnmin.Location = new Point(panelfull.Height + 10, 10);
        Image btnm = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/btnmin.png");
        btnmin.BackgroundImage = new Bitmap(btnm, 20, 20/2-6);
        btnmin.Size = new Size(20, 20 / 2-7);
        panelfull.Controls.Add(btnmin);

        logoor = new PictureBox();
        logoor.Location = new Point(33,28 );
        Image logo = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/logo.png");
        logoor.BackgroundImage = new Bitmap(logo, 78, 78);
        logoor.Size = new Size(78, 78);
        panelder.Controls.Add(logoor);
        
//==================================================================================================================        
//Aquí termina la parte del login e inicia la del sign in, la cual vamos a hacer en la misma ventana.


//==================================================================================================================           
//Aquí se enlazan los eventos de cada item que tenga el form
        btnmin.Click += minimize;
        btnclose.Click += exit;
        btnacc.Click += btnacc_click;
        cbshow.CheckedChanged += cbShow_CheckedChanged;

        
//==================================================================================================================

    }

    
        private void CalculateAnimationDuration(int startX, int startY, int targetX, int targetY)
{
    // Calcula la distancia total en píxeles que debe recorrer el control
    int distanceX = targetX - startX;
    int distanceY = targetY - startY;
    int totalDistance = (int)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

    // Calcula la velocidad constante en píxeles por paso
    int speed = totalDistance / animationSteps;

    // Calcula la duración de la animación en milisegundos
    if (speed == 0)
    {
        animationDuration = 0;
    }
    else
    {
        animationDuration = totalDistance / speed;
    }
}

    private void AnimateControl(Control control, Point targetLocation, bool changeDockStyle)
    {
        if (!isAnimating)
        {
            isAnimating = true;
            Point originalLocation = control.Location;
            int stepX = (targetLocation.X - originalLocation.X) / animationSteps;
            int stepY = (targetLocation.Y - originalLocation.Y) / animationSteps;
            int stepCount = 0;

            Timer timer = new Timer();
            timer.Interval = animationDuration / animationSteps;
            timer.Tick += (sender, e) =>
            {
                stepCount++;
                control.Left = originalLocation.X + stepX * stepCount;
                control.Top = originalLocation.Y + stepY * stepCount;

                if (stepCount >= animationSteps)
                {
                    control.Location = targetLocation; // Establece la posición final
                    timer.Stop();
                    isAnimating = false;

                    if (changeDockStyle)
                    {
                        // Cambia el DockStyle después de la animación
                        if (targetLocation.X == 0 && targetLocation.Y == 0)
                            control.Dock = DockStyle.Left;
                        else
                            control.Dock = DockStyle.None;
                    }
                }
            };

            timer.Start();
        }
    }

    private void transition(object sender, EventArgs e)
    {
        if (panelder.Dock == DockStyle.Left) 
        {
            panelder.Dock = DockStyle.None;
            panelder.Height = 679;
            panelder.Location = new Point(1, 1);
            CalculateAnimationDuration(panelder.Left, panelder.Top, 500, 75); // Actualiza la duración antes de cada animación
            AnimateControl(panelder, new Point(500, 75), false);
            panelder.Height = 500;
            panelder.Width = 369;
        }
        else
        {
            CalculateAnimationDuration(panelder.Left, panelder.Top, 0, 0); // Actualiza la duración antes de cada animación
            AnimateControl(panelder, new Point(0, 0), true); // Cambia el DockStyle después de la animación
            panelder.Width = 310;
            
            introtxt.Text = "Inicia sesión con tu \ncuenta de Orange";
            introtxt.Location = new Point(24, 159);
            usutextbg.Location = new Point(43, 250);
            usutextbg.Width = 234;
            cbshow.Location = new Point(45, 375);
            passtextbg.Location = new Point(43, 309);
            passtextbg.Width = 234;
            btnacc.Location = new Point(125, 442);
            btnacc.Size = new Size(49,56);
            btnacc.BackgroundImage = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/boton_no.png");
            Image logo = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/logo.png");
            logoor.BackgroundImage = new Bitmap(logo, 78, 78);
            logoor.Size = new Size(78, 78);


            
        }
    }
    
    
    private void cbShow_CheckedChanged(object sender, EventArgs e)
    {
        if (txtbxPassword != null && txtbxPassword.CheckBoxPass != null)
        {
            txtbxPassword.IsPasswordVisible = txtbxPassword.CheckBoxPass.Checked;
        }
    }
    private void btnacc_click(object sender, EventArgs e)
    {
        if (colorbtn == false)
        {
            MessageBox.Show("Primero tienes que llenar los campos de arriba");
        }
        else
        {
            MessageBox.Show("Bienvenido");
        }
    }
    
    /*
    private void textusu_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true; // Cancela el evento para evitar que se agregue el carácter
        }
    }
    */
    
    
    private void btnbgc()
    {
        if (usu.txtleave() != "" && textPass.Text != "")
        {
            btnacc.BackgroundImage = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/boton_si.png");
        }
        else 
        {
            btnacc.BackgroundImage = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/boton_no.png"); 
        }
    }
    
    private void minimize(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void exit(object sender, EventArgs e)
    {
        this.Close();
    }


}