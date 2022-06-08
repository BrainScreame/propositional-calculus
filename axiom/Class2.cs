using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axiom
{
    class Class2
    {
        public static Stack<string> function(string str, int x)
        {
            Stack<string> result = new Stack<string>();

            for (int i = 0; i < str.Length - x; i++)
            {
                if (Class1.Variable(str[i]))
                {
                    result.Push(str[i].ToString());
                    continue;
                }
                if (str[i] == '¬')
                {
                    string temp = '¬' + result.Pop();
                    result.Push(temp);
                    continue;
                }
                if (str[i] == '→')
                {
                    string last = result.Pop();
                    string first = result.Pop();
                    string temp = '(' + first + '→' + last + ')';

                    result.Push(temp);
                }
            }

            return result;
        }

        public static string[] Axiom1(string str)
        {
            string[] output = new string[3];

            if (str[str.Length - 2] == '→' && str[str.Length - 1] == '→')
            {
                Stack<string> result = new Stack<string>();

                result = function(str, 2);

                for (int i = 2; i >= 0; i--)
                {
                    output[i] = result.Pop();
                }
            }
            return output;
        }

        public static string[] Axiom2(string str)
        {
            string[] output = new string[3];

            if (str[str.Length - 3] == '→' && str[str.Length - 2] == '→' && str[str.Length - 1] == '→')
            {
                Stack<string> result = new Stack<string>();

                result = function(str, 3);

                string H2 = result.Pop();
                string F3 = result.Pop();

                str = "";

                string temp = result.Pop();

                str = result.Pop() + temp;

                str = Class1.Convert(str);

                if(str[str.Length - 1] == '→')
                {
                    result = function(str, 1);
                }

                string G2;
                string F2;

                if (result.Count != 0)
                {
                    G2 = result.Pop();
                    F2 = result.Pop();
                }
                else
                {
                    return output;
                }
                str = result.Pop();

                str = Class1.Convert(str);

                if (str[str.Length - 2] == '→' && str[str.Length - 1] == '→')
                {
                    result = function(str, 2);
                }

                string H1 = null;
                string G1 = null;
                string F1 = null;

                if (result.Count != 0)
                {
                    H1 = result.Pop();
                    G1 = result.Pop();
                    F1 = result.Pop();
                }


                if(F1 == F2 && F1 == F3)
                {
                    output[0] = F1;
                }
                if(G1 == G2)
                {
                    output[1] = G1;
                }
                if(H1 == H2)
                {
                    output[2] = H1;
                }
            }
            return output;
        }

        public static string[] Axiom3(string str)
        {
            string[] output = new string[2];

            if (str[str.Length - 2] == '→' && str[str.Length - 1] == '→')
            {
                Stack<string> result = new Stack<string>();

                result = function(str, 2);

                string G = result.Pop();

                string temp2 = result.Pop();
                string temp1 = result.Pop();

                str = temp1 + temp2;

                str = Class1.Convert(str);

                if (str[str.Length - 1] == '→')
                {
                    result = function(str, 1);
                }

                string F = "";
                string notG2 = "";

                if (result.Count > 1)
                {
                    F = result.Pop();
                    notG2 = result.Pop();
                }
                else
                {
                    return output;
                }

                notG2 = notG2.Remove(0, 1);

                str = result.Pop();

                str = Class1.Convert(str);

                if (str[str.Length - 1] == '→')
                {
                    result = function(str, 1);
                }

                string notF = result.Pop();
                notF = notF.Remove(0, 1);

                string notG1 = result.Pop();
                notG1 = notG1.Remove(0, 1);

                if (F == notF)
                {
                    output[0] = F;
                }
                if (G == notG1 && G == notG2)
                {
                    output[1] = notG1;  
                }


            }
            return output;
        }
    }
}
