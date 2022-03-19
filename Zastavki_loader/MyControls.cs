using System.Drawing;
using System.Windows.Forms;

namespace Zastavki_loader
{
    public class MyListView : ListView
    {
        public MyListView()
        {
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            //this.BackColor = Color.FromArgb(27, 40, 56);
            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new System.Drawing.Pen(Color.Red, 2), new Rectangle(1, 1, this.Width - 1, this.Height - 1));

        }
    }
}
