using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace axiom
{
    public partial class outputtext : Form
    {
        public outputtext(string text)
        {
            InitializeComponent();

            textBox1.ReadOnly = true;

            text = Class1.Convert(text);

            Stack<string> newst = new Stack<string>();
            newst = Class2.function(text, 0);

            string[] derivation = new string[3];

            derivation = Class2.Axiom1(text);

            if(derivation[0] == derivation[2] && derivation[1] != null)
            {
                textBox1.Text = "Формула " + newst.Peek() + " является схемой аксиом A1:" + Environment.NewLine;
                textBox1.Text += "F ≡ " + derivation[0] + Environment.NewLine;
                textBox1.Text += "G ≡ " + derivation[1] + Environment.NewLine;
            }
            else
            {
                derivation = Class2.Axiom2(text);

                if (derivation[0] != null && derivation[1] != null && derivation[2] != null)
                {
                    textBox1.Text += "Формула " + newst.Peek() + " является схемой аксиом A2:" + Environment.NewLine;
                    textBox1.Text += "F ≡ " + derivation[0] + Environment.NewLine;
                    textBox1.Text += "G ≡ " + derivation[1] + Environment.NewLine;
                    textBox1.Text += "H ≡ " + derivation[2] + Environment.NewLine;
                }
                else
                {
                    derivation = Class2.Axiom3(text);

                    if (derivation[0] != null && derivation[1] != null)
                    {
                        textBox1.Text += "Формула " + newst.Peek() + " является схемой аксиом A3:" + Environment.NewLine;
                        textBox1.Text += "F ≡ " + derivation[0] + Environment.NewLine;
                        textBox1.Text += "G ≡ " + derivation[1] + Environment.NewLine;
                    }
                    else
                    {
                        textBox1.Text += "Формула " + newst.Peek() + " не является аксиомой:" + Environment.NewLine;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void outputtext_Load(object sender, EventArgs e)
        {

        }
    }
}
