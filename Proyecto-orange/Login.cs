using System.Data;
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
    private RoundedPanel tglbtnpanel;
    private tglbtn themeswitch;
    private txtbx mailtxtbx;
    private Label reg_pass_contextbg;
    private Label reg_pass_contextTitleLabel;
    private txtbx reg_pass_con;
    private TextBox reg_pass_con_txt;
    private Label mailLabel;
    private Label mailtitle;
    private TextBox mailtext;
    private Label cuenta;
    private bool mailcheck;
    private bool passcheck;
    private bool passconcheck;
    private bool cicheck;
    private bool logcheck;
    
    

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
        panelfull.BackgroundImage = new Bitmap(lbg, 1024, 650);
        
        
        panelder = new Panel();
        panelder.BackColor = Color.White;
        panelder.Dock = DockStyle.Left;
        panelder.Width = 310;

        panelfull.Controls.Add(panelder);
        
        tglbtnpanel = new RoundedPanel();
        tglbtnpanel.BackColor = Color.DarkGray;
        tglbtnpanel.Location = new Point(320,600);
        tglbtnpanel. Size = new Size(90,40); 
        panelfull.Controls.Add(tglbtnpanel);

       
        
        themeswitch = new tglbtn();
        themeswitch.Location = new Point(0,0 );
        themeswitch.Dock = DockStyle.Left;
        themeswitch.Width = tglbtnpanel.Width / 2;
        tglbtnpanel.Controls.Add(themeswitch);
        
       introtxt = new Label();
       introtxt.Text = "Inicia sesión con tu \ncuenta de \nRemates de campo";
       introtxt.Font = new Font("Arial", 20, FontStyle.Bold);
       introtxt.BackColor = Color.Transparent;
       introtxt.Location = new Point(24, 135);
       introtxt.AutoSize = true;
       panelder.Controls.Add(introtxt);

      usu = new txtbx(usutextbg,usutextTitleLabel,"C.I",textUsu,panelder,234,new Point(43,250),"ci",cicheck);
      
       cbshow = new CheckBox();
       cbshow.Location = new Point(45, 375);
       cbshow.Text = "Mostrar contraseña";
       cbshow.Font = new Font("Arial", 9, FontStyle.Bold);
       cbshow.AutoSize = true;
       cbshow.ForeColor = Color.DimGray;
       panelder.Controls.Add(cbshow);
       
       
       txtbxPassword = new txtbx(passtextbg,passtextTitleLabel,"Contraseña",textPass,panelder,234,new Point(43,309),"pass",passcheck,cbshow);
      
        btnacc = new PictureBox();
        btnacc.Location = new Point(125, 442);
        btnacc.Size = new Size(49,56);
        btnacc.BackColor = Color.Transparent;
        btnacc.BackgroundImage = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/boton_no.png");
        panelder.Controls.Add(btnacc);
     
        btnclose = new PictureBox();
        btnclose.Location = new Point(panelfull.Right - 30,10);
        Image btnc = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/btnclose.png");
        btnclose.BackgroundImage = new Bitmap(btnc, btnbar, btnbar);
        btnclose.Size = new Size(btnbar , btnbar);
        btnclose.BackColor = Color.Transparent;
        panelfull.Controls.Add(btnclose);

        btnmin = new PictureBox();
        btnmin.Location = new Point(btnclose.Left -30, 15);
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
        
        
        mailtxtbx = new txtbx(mailLabel, mailtitle, "Correo electrónico", mailtext, panelder, 312,
            new Point(212 - panelder.Width / 2, 150), "text",mailcheck);
        mailtxtbx.remove_txtbx();
        
        
        
        cuenta = new Label();
        cuenta.Location = new Point(20, 450);
        cuenta.Text = "Crea tu\nCuenta";
        cuenta.BackColor = Color.Transparent;
        cuenta.Font = new Font("Arial", 60, FontStyle.Bold);
        cuenta.ForeColor = Color.White;
        cuenta.AutoSize = true;


        reg_pass_con = new txtbx(reg_pass_contextbg, reg_pass_contextTitleLabel, "Confirme su contraseña",
            reg_pass_con_txt, panelder, 312, new Point(212 - panelder.Width / 2, 180),"pass",passconcheck, cbshow);
        reg_pass_con.remove_txtbx();
        
        
        
//==================================================================================================================        
//Aquí termina la parte del login e inicia la del sign in, la cual vamos a hacer en la misma ventana.
    

//==================================================================================================================           
//Aquí se enlazan los eventos de cada item que tenga el form
        btnmin.Click += Minimize;
        btnclose.Click += Exit;
        btnacc.Click += BtnaccClick;
        cbshow.CheckedChanged += cbShow_CheckedChanged;
        themeswitch.Click += Tglevent;
        usu.NoNullChanged += Txtbx_NotNullChanged;
        txtbxPassword.NoNullChanged += Txtbx_NotNullChanged;

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

   
    
    
    private void cbShow_CheckedChanged(object sender, EventArgs e)
    {
        if (txtbxPassword != null && txtbxPassword.CheckBoxPass != null)
        {
            txtbxPassword.IsPasswordVisible = txtbxPassword.CheckBoxPass.Checked;
        }
        if (reg_pass_con != null && reg_pass_con.CheckBoxPass != null)
        {
            reg_pass_con.IsPasswordVisible = reg_pass_con.CheckBoxPass.Checked;
        }
        
    }
    private void BtnaccClick(object sender, EventArgs e)
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
    
    
    
    private void Minimize(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void Exit(object sender, EventArgs e)
    {
        this.Close();
    }

    
    private void Tglevent(object sender, EventArgs e)
    {
        if (panelder.Dock == DockStyle.Left)
        {
            panelder.Dock = DockStyle.None;
            panelder.Height = 679;
            panelder.Location = new Point(1, 1);
            CalculateAnimationDuration(panelder.Left, panelder.Top, 500,
                75); // Actualiza la duración antes de cada animación
            AnimateControl(panelder, new Point(500, 75), false);
            panelder.Height = 500;
            panelder.Width = 369;

            introtxt.Text = "¿Cuál es\n      tu Correo electrónico?";
            introtxt.Location = new Point(5, 50);
            panelder.Controls.Remove(logoor);

            
            panelfull.Controls.Add(cuenta);
            
            usu.remove_txtbx();
            txtbxPassword.remove_txtbx();

            mailtxtbx.re_add(new Point(212 - panelder.Width / 2, 150),panelder);
            
            
            usu.cambio_tamaño(312);
            usu.re_add(new Point(212 - panelder.Width / 2, mailtxtbx.Bottom + 60),panelder);
            
            txtbxPassword.cambio_tamaño(312);
            txtbxPassword.re_add(new Point(212 - panelder.Width / 2, mailtxtbx.Bottom + 120),panelder);
            
            reg_pass_con.re_add(new Point(212 - panelder.Width / 2, mailtxtbx.Bottom + 180),panelder);

            cbshow.Location = new Point(212 - panelder.Width / 2, mailtxtbx.Bottom + 240);
            Image lbg = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/signinbg.jpg");
            panelfull.BackgroundImage = new Bitmap(lbg, 1024, 650);

            btnacc.Size = new Size(131, 51);
            btnacc.Location = new Point(112, 430);
            btnacc.BackgroundImage = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/Siguiente_0.png");
        }
        
        else
        {
            CalculateAnimationDuration(panelder.Left, panelder.Top, 0, 0); // Actualiza la duración antes de cada animación
            AnimateControl(panelder, new Point(0, 0), true); // Cambia el DockStyle después de la animación
            panelder.Width = 310;
            Image lbg = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/loginbg.jpg");
            panelfull.BackgroundImage = new Bitmap(lbg, 1024, 650);
            btnacc.Location = new Point(125, 442);
            btnacc.Size = new Size(49,56);
            btnacc.BackColor = Color.Transparent;
            introtxt.Text = "Inicia sesión con tu \ncuenta de \nRemates de campo";
            introtxt.Font = new Font("Arial", 20, FontStyle.Bold);
            introtxt.BackColor = Color.Transparent;
            introtxt.Location = new Point(24, 135);
            panelder.Controls.Add(logoor);
            mailtxtbx.remove_txtbx();
            reg_pass_con.remove_txtbx();
            usu.cambio_tamaño(234);
            usu.re_add(new Point(43,250),panelder );
            txtbxPassword.cambio_tamaño(234);
            txtbxPassword.re_add(new Point(43,309),panelder);
           panelfull.Controls.Remove(cuenta);
            btnacc.BackgroundImage =
                Image.FromFile(
                    $"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/boton_no.png");
        }

        if (themeswitch.Dock == DockStyle.Left)
        {
            themeswitch.Dock = DockStyle.Right;
        }
        else
        {
            themeswitch.Dock = DockStyle.Left;
        }
    }
    
    private void Txtbx_NotNullChanged(object sender, bool newValue)
    {
        // Se llama cuando cambia el valor de notnull en cualquier txtbx
        UpdateButtonAppearance();
    }

    private void UpdateButtonAppearance()
    {
        // Lógica para cambiar la apariencia del botón según los valores de notnull

        if (panelder.Dock == DockStyle.Left)
        {
            
        logcheck = usu.nonull && txtbxPassword.nonull;
        if (logcheck)
        {
            // Cambiar el aspecto del botón cuando todos los txtbx tienen un valor
            // Puedes cambiar el color de fondo o cualquier otra propiedad aquí
            // Por ejemplo, si el botón se llama "btnEnviar":
            btnacc.BackgroundImage = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/boton_si.png");
        }
        else
        {
            // Cambiar el aspecto del botón cuando no todos los txtbx tienen un valor
            // Puedes cambiar el color de fondo o cualquier otra propiedad aquí
            // Por ejemplo, si el botón se llama "btnEnviar":
            btnacc.BackgroundImage = Image.FromFile($"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/boton_no.png"); 
        }
        }
        else
        {
            logcheck = usu.nonull && txtbxPassword.nonull && reg_pass_con.nonull && mailtxtbx.nonull;
            if (logcheck)
            {
                // Cambiar el aspecto del botón cuando todos los txtbx tienen un valor
                // Puedes cambiar el color de fondo o cualquier otra propiedad aquí
                // Por ejemplo, si el botón se llama "btnEnviar":
                Image.FromFile(
                    $"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/Siguiente_A.png");
            }
            else
            {
                // Cambiar el aspecto del botón cuando no todos los txtbx tienen un valor
                // Puedes cambiar el color de fondo o cualquier otra propiedad aquí
                // Por ejemplo, si el botón se llama "btnEnviar":
                btnacc.BackgroundImage =
                    Image.FromFile(
                        $"{Path.GetFullPath(".").Split("Proyecto-orange")[0]}Proyecto-orange/Proyecto-orange/Resources/Siguiente_0.png");
            }  
        }
    }

    
}