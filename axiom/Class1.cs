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
    class Class1
    {
        public static bool Variable(char temp)
        {
            return (temp >= 'A' && temp <= 'Z');
        }

        public static bool Operation(char temp)
        {
            return (temp == '¬' || temp == '→');
        }

        private static int Priority(char temp)
        {
            switch (temp)
            {
                case '¬':
                    return 3;
                case '→':
                    return 2;
                case '(':
                    return 1;
                default:
                    return 0;
            }
        }

        private static string Converting(string line)
        {
            string result = "";

            Stack<char> sign = new Stack<char>();

            for (int i = 0; i < line.Length; i++)
            {
                if (Variable(line[i]))
                {
                    result += line[i].ToString();
                    continue;
                }
                if (Operation(line[i]))
                {
                    if (sign.Count != 0 && Priority(line[i]) > Priority(sign.Peek()))
                    {
                        sign.Push(line[i]);
                        continue;
                    }
                    else
                    {
                        while (sign.Count != 0 && Priority(sign.Peek()) > Priority(line[i]))
                        {
                            result += sign.Pop().ToString();
                        }
                        sign.Push(line[i]);
                        continue;
                    }
                }
                if (line[i] == '(')
                {
                    sign.Push(line[i]);
                    continue;
                }
                if (line[i] == ')')
                {
                    while (sign.Count > 0)
                    {
                        if (sign.Peek() == '(')
                            break;
                        else
                            result += sign.Pop().ToString();
                    }
                    if(sign.Count == 0)
                    {
                        result = null;
                        return result;
                    }
                    else
                        sign.Pop();
                }
            }

            while (sign.Count != 0)
            {
                result += sign.Pop().ToString();
            }

            return result;
        }

        public static string Convert(string line)
        {
            return Converting(line);
        }
    }
}
