using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Proyecto_orange;

public partial class prueba : Form

{
private Button ola;
private bool isAnimating = false;
private int finalX = 500; // Cambia estas coordenadas finales según sea necesario
private int finalY = 75;
private int animationSteps = 30; // Cantidad de pasos de la animación
private int animationDuration; // Duración de la animación en milisegundos
private Point originalLocation; // Coordenadas originales del control

    public prueba()
    {
        
        
        InitializeComponent();

        Height = 680;
        Width = 1024;

        ola = new Button();
        ola.Location = new Point(0, 0);
        originalLocation = new Point(0, 0);
        ola.Dock = DockStyle.Left;
        ola.Width = 250;
        Controls.Add(ola);
        ola.Click += button1_Click;
        CalculateAnimationDuration();
    }

    private void CalculateAnimationDuration()
    {
        // Calcula la distancia total en píxeles que debe recorrer el control
        int distanceX = finalX - ola.Left;
        int distanceY = finalY - ola.Top;
        int totalDistance = (int)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

        // Calcula la velocidad constante en píxeles por paso
        int speed = totalDistance / animationSteps;

        // Calcula la duración de la animación en milisegundos
        animationDuration = totalDistance / speed;
    }

    private void AnimateControl(Control control, Point targetLocation)
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
                }
            };

            timer.Start();
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {

        if (ola.Location == originalLocation) 
        {
            ola.Dock = DockStyle.None;
            ola.Height = 679;
            ola.Location = new Point(0, 0);
            CalculateAnimationDuration(); // Actualiza la duración antes de cada animación
            AnimateControl(ola, new Point(finalX,finalY));
            ola.Height = 500;
            ola.Width = 369;
        }
        else
        {
            CalculateAnimationDuration(); // Actualiza la duración antes de cada animación
            AnimateControl(ola, originalLocation);
            ola.Dock = DockStyle.Left;
            ola.Width = 250;
            
        }
       
    }
}