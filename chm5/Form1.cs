using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chm5
{
    public partial class Form1 : Form
    {
        private double a;
        private double b;
        private double epsilon;
        private double x0;
        private double x;
        private int k;
        public Form1()
        {
            InitializeComponent();
        }

        delegate double Function(double x);

        //[0.8; 1.2] x0=0.85 epsilon = 0.00002 root = 0.978
        double phi(double x)
        {
            return (Math.Log(x * 6.0976d) + 2.0d) / 3.872d;
            //return (Math.Log(x * 6.0976d) + 1.0d) / 6.872d;
        }

        void calculate(double a, double b, double epsilon, double x0, Function phi, out double x, out int k)
        {
   
            k = 0;
            do
            {
                x = x0;
                x0 = phi(x0);
                k++;
                Console.WriteLine($"x = {x} x0 = {x0} k = {k}");
            }
            while (Math.Abs(x - x0) > epsilon);
        }

        void onClick_CalculateButton(object sender, EventArgs eventArgs)
        {
            try
            {
                if(!(Double.TryParse(aTextBox.Text, out a) &&
                    Double.TryParse(bTextBox.Text, out b) &&
                    Double.TryParse(epsilonTextBox.Text, out epsilon) &&
                    Double.TryParse(x0TextBox.Text, out x0)))
                {
                    throw new Exception("Input error");
                }
                if(x0 < a || x0 > b)
                {
                    throw new Exception($"x0 isn`t in range [{a};{b}]");
                }
                calculate(a, b, epsilon, x0, phi, out x, out k);

                xTextBox.Text = $"{x}";
                kTextBox.Text = $"{k}";

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
