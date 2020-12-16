using System;
using System.Drawing;
using System.Windows.Forms;

namespace IetsGrafisch
{
    class Program
    {
        static void Main(string[] args)
        {
            Form f1 = new Form();
            f1.Text = "Hallo";

            Button b1 = new Button { Text = "OK", Location = new Point(50, 50) };
            b1.Click += MijnClick;
            
            f1.Controls.Add(b1);

            f1.ShowDialog();
        }

        private static void MijnClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.Parent.BackColor = Color.Red;
        }
    }
}
