using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtA.Text, out int a)) return;
            if (!int.TryParse(txtB.Text, out int b)) return;

            //var ctx = SynchronizationContext.Current;
            //AddAsync(a, b).ContinueWith(pt => {
            //    ctx.Post(UpdateAnswer, pt.Result);
            //});

            int result = await AddAsync(a, b);//.ConfigureAwait(false);
            UpdateAnswer(result);

            //int result = Add(a, b);
            //UpdateAnswer(result);
        }

        private void UpdateAnswer(object result)
        {
            lblAnswer.Text = result.ToString();
        }

        private int Add(int a, int b)
        {
            Task.Delay(10000).Wait();
            return a + b;
        }
        private Task<int> AddAsync(int a, int b)
        {
            return Task.Run(() => Add(a, b));              
        }
    }
}
