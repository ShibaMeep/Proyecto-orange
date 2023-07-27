using System.Windows.Forms;

namespace Proyecto_orange.Controls;

public partial class RoundedPanel : UserControl
{
    public int CornerRadius { get; set; } = 10;

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        using (var path = new System.Drawing.Drawing2D.GraphicsPath())
        {
            path.AddArc(0, 0, CornerRadius * 2, CornerRadius * 2, 180, 90);
            path.AddArc(Width - CornerRadius * 2, 0, CornerRadius * 2, CornerRadius * 2, 270, 90);
            path.AddArc(Width - CornerRadius * 2, Height - CornerRadius * 2, CornerRadius * 2, CornerRadius * 2, 0, 90);
            path.AddArc(0, Height - CornerRadius * 2, CornerRadius * 2, CornerRadius * 2, 90, 90);
            path.CloseFigure();

            Region = new Region(path);
        }
    }
}