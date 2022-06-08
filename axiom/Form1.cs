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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string text;
        private int bracket_left = 0, bracket_right = 0;
        private int size = 0;

        void Adding_Variables(string copyrightUnicode)
        {
            var selectionIndex = Expression.SelectionStart;

            int value = int.Parse(copyrightUnicode, System.Globalization.NumberStyles.HexNumber);
            string symbol = char.ConvertFromUtf32(value).ToString();

            Expression.Text = Expression.Text.Insert(selectionIndex, symbol);
            Expression.SelectionStart = selectionIndex + symbol.Length;
            Expression.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adding_Variables("0028");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Adding_Variables("0029");    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Adding_Variables("0046");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Adding_Variables("0047");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Adding_Variables("0048");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Adding_Variables("2192");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Adding_Variables("00AC");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Expression.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bracket_left = 0;
            bracket_right = 0;
            text = Expression.Text;
            string temp = Class1.Convert(text);
            int choice = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= 'A' && text[i] <= 'Z')
                    size++;
                else if (text[i] == '(')
                    bracket_left++;
                else if (text[i] == ')')
                    bracket_right++;

            }

            if (text.Length == 0)
            {
                MessageBox.Show("Пустая строка!", "Ошибка!", MessageBoxButtons.OK);
            }
            else if (bracket_left != bracket_right)
            {
                MessageBox.Show("Неверное количество скобок!", "Ошибка!", MessageBoxButtons.OK);
            }
            else if (temp == null)
            {
                MessageBox.Show("Некорректное выражение!", "Ошибка!", MessageBoxButtons.OK);
            }
            else if (size <= 2)
            {
                MessageBox.Show("Количество пропозициональных переменных должно быть больше двух!", "Ошибка!", MessageBoxButtons.OK);
            }
            else if (text[0] == '→')
            {
                MessageBox.Show("Формула не может начинаться с импликации!", "Ошибка!", MessageBoxButtons.OK);
            }
            else if (text[text.Length - 1] == '→')
            {
                MessageBox.Show("Формула не может заканчиваться импликацией!", "Ошибка!", MessageBoxButtons.OK);
            }
            else
            {
                for (int i = 0; i < text.Length - 1; i++)
                {
                    if ((text[i] >= 'A' && text[i] <= 'Z') && (text[i + 1] >= 'A' && text[i + 1] <= 'Z'))
                    {
                        MessageBox.Show("Две переменные подряд!", "Ошибка!", MessageBoxButtons.OK);
                        choice = -1;
                        break;
                    }
                    if (text[i] == '→' && text[i + 1] == '→')
                    {
                        MessageBox.Show("Две операции подряд!", "Ошибка!", MessageBoxButtons.OK);
                        choice = -1;
                        break;
                    }
                    if (text[i] == ')' && text[i + 1] == '(')
                    {
                        MessageBox.Show("Отсутствует импликация между скобками!", "Ошибка!", MessageBoxButtons.OK);
                        choice = -1;
                        break;
                    }
                    if ((text[i] >= 'A' && text[i] <= 'Z') && text[i + 1] == '(')
                    {
                        MessageBox.Show("Отсутствует импликация между переменной и скобкой!", "Ошибка!", MessageBoxButtons.OK);
                        choice = -1;
                        break;
                    }
                    if (text[i] == ')' && (text[i+1] >= 'A' && text[i+1] <= 'Z'))
                    {
                        MessageBox.Show("Отсутствует импликация между скобкой и переменной!", "Ошибка!", MessageBoxButtons.OK);
                        choice = -1;
                        break;
                    }
                    if (text[i] == '¬' && text[i + 1] == '→')
                    {
                        MessageBox.Show("Нельзя ставить отрицание на импликацию!", "Ошибка!", MessageBoxButtons.OK);
                        choice = -1;
                        break;
                    }
                    if (text[i] == '(' && text[i + 1] == ')')
                    {
                        MessageBox.Show("Пустые скобки!", "Ошибка!", MessageBoxButtons.OK);
                        choice = -1;
                        break;
                    }
                    if ((text[i] == '(' && text[i + 1] == '→' || (text[i] == '→' || text[i] == '¬') && text[i + 1] == ')'))
                    {
                        MessageBox.Show("Некорректное выражение!", "Ошибка!", MessageBoxButtons.OK);
                        choice = -1;
                        break;
                    }
                    if ((text[i] >= 'A' && text[i] <= 'Z') && text[i + 1] == '¬')
                    {
                        MessageBox.Show("Две переменные подряд!", "Ошибка!", MessageBoxButtons.OK);
                        choice = -1;
                        break;
                    }
                }
                if(choice == 0)
                {
                    outputtext newForm = new outputtext(text);
                    newForm.Show();
                }
            }
        }

        private void Variable_Q_Click(object sender, EventArgs e)
        {
            Adding_Variables("0051");
        }

        private void Variable_W_Click(object sender, EventArgs e)
        {
            Adding_Variables("0057");
        }

        private void Variable_E_Click(object sender, EventArgs e)
        {
            Adding_Variables("0045");
        }

        private void Variable_R_Click(object sender, EventArgs e)
        {
            Adding_Variables("0052");
        }

        private void Variable_T_Click(object sender, EventArgs e)
        {
            Adding_Variables("0054");
        }

        private void Variable_Y_Click(object sender, EventArgs e)
        {
            Adding_Variables("0059");
        }

        private void Variable_U_Click(object sender, EventArgs e)
        {
            Adding_Variables("0055");
        }

        private void Variable_I_Click(object sender, EventArgs e)
        {
            Adding_Variables("0049");
        }

        private void Variable_O_Click(object sender, EventArgs e)
        {
            Adding_Variables("004F");
        }

        private void Variable_P_Click(object sender, EventArgs e)
        {
            Adding_Variables("0050");
        }

        private void Variable_A_Click(object sender, EventArgs e)
        {
            Adding_Variables("0041");
        }

        private void Variable_S_Click(object sender, EventArgs e)
        {
            Adding_Variables("0053");
        }

        private void Variable_D_Click(object sender, EventArgs e)
        {
            Adding_Variables("0044");
        }

        private void Variable_F_Click(object sender, EventArgs e)
        {
            Adding_Variables("0046");
        }

        private void Variable_G_Click(object sender, EventArgs e)
        {
            Adding_Variables("0047");
        }

        private void Variable_H_Click(object sender, EventArgs e)
        {
            Adding_Variables("0048");
        }

        private void Variable_K_Click(object sender, EventArgs e)
        {
            Adding_Variables("004B");
        }

        private void Variable_J_Click(object sender, EventArgs e)
        {
            Adding_Variables("004A");
        }

        private void Variable_L_Click(object sender, EventArgs e)
        {
            Adding_Variables("004C");
        }

        private void Variable_Z_Click(object sender, EventArgs e)
        {
            Adding_Variables("005A");
        }

        private void Variable_X_Click(object sender, EventArgs e)
        {
            Adding_Variables("0058");
        }

        private void Variable_B_Click(object sender, EventArgs e)
        {
            Adding_Variables("0042");
        }

        private void Variable_C_Click(object sender, EventArgs e)
        {
            Adding_Variables("0043");
        }

        private void Variable_M_Click(object sender, EventArgs e)
        {
            Adding_Variables("004D");
        }

        private void Variable_N_Click(object sender, EventArgs e)
        {
            Adding_Variables("004E");
        }

        private void Variable_V_Click(object sender, EventArgs e)
        {
            Adding_Variables("0056");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = listBox1.SelectedIndex;

            if(choice == 0)
            {
                Expression.Text = "F→(G→F)";
            }
            if (choice == 1)
            {
                Expression.Text = "(F→(G→H))→((F→G)→(F→H))";
            }
            if (choice == 2)
            {
                Expression.Text = "(¬G→¬F)→((¬G→F)→G)";
            }
        }

        private void To_Left_Click(object sender, EventArgs e)
        {
            var selectionIndex = Expression.SelectionStart;
            if (selectionIndex != 0)
            {
                Expression.SelectionStart = selectionIndex - 1;
            }
            Expression.Focus();
        }

        private void To_Right_Click(object sender, EventArgs e)
        {
            var selectionIndex = Expression.SelectionStart;
            if (selectionIndex != Expression.MaxLength)
            {
                Expression.SelectionStart = selectionIndex + 1;
            }
            Expression.Focus();
        }

        private void Expression_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var selectionIndex = Expression.SelectionStart;

            if (selectionIndex != 0)
            {
                if (Expression.Text[Expression.Text.Length - 1] == '(')
                    bracket_left--;
                if (Expression.Text[Expression.Text.Length - 1] == ')')
                    bracket_right--;
                Expression.Text = Expression.Text.Remove(selectionIndex - 1, 1);
                Expression.SelectionStart = selectionIndex - 1;
            }
           
        }

        private void Expression_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                return;
            else if(e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.KeyChar =Char.ToUpper(e.KeyChar);
                return;
            }
            else if (e.KeyChar == '(' || e.KeyChar == ')')
                return;
            else if (e.KeyChar == '-')
            {
                e.KeyChar = '→';
                return;
            }
            else if (e.KeyChar == '!')
            {
                e.KeyChar = '¬';
                return;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            else
                e.Handled = true;
        }

    }
}
