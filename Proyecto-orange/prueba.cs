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

    private void button1_Click(object sender, EventArgs e)
    {
        if (ola.Dock == DockStyle.Left) 
        {
            ola.Dock = DockStyle.None;
            ola.Height = 679;
            ola.Location = new Point(1, 1);
            CalculateAnimationDuration(ola.Left, ola.Top, 500, 75); // Actualiza la duración antes de cada animación
            AnimateControl(ola, new Point(500, 75), false);
            ola.Height = 500;
            ola.Width = 369;
        }
        else
        {
            CalculateAnimationDuration(ola.Left, ola.Top, 0, 0); // Actualiza la duración antes de cada animación
            AnimateControl(ola, new Point(0, 0), true); // Cambia el DockStyle después de la animación
            ola.Width = 250;
        }
    }

}