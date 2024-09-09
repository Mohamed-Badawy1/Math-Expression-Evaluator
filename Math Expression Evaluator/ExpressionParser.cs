using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Expression_Evaluator
{
    public static class ExpressionParser
    {
        private const string Mathsymbols = "+/*%^";
        public static MathExpression Parse(string input)
        {
            input = input.Trim();
            var exp=new MathExpression();
            string token = "";
            bool LeftSideflag=false;
            for(int i = 0; i < input.Length; i++)
            {
                var CurrentChar=input[i];
                if (char.IsDigit(CurrentChar))
                {
                    token += CurrentChar;
                    if (i == input.Length - 1 && LeftSideflag)
                    {
                        exp.RightNum=double.Parse(token);
                        break;
                    }
                }
                else if (Mathsymbols.Contains(CurrentChar))
                {
                    if (!LeftSideflag)
                    {
                        exp.LeftNum = double.Parse(token);
                        LeftSideflag = true;
                    }
                    exp.Operation = ParseMathOperation(CurrentChar.ToString());
                    token = "";

                }
                else if (CurrentChar == '-')
                {

                    if (token == "" && !LeftSideflag)
                    {
                        token += CurrentChar;
                    }
                    else if (exp.Operation != Mathoperation.none && token == "")
                    {
                        token += CurrentChar;
                    }
                    else
                    {
                        if (!LeftSideflag)
                        {
                            exp.LeftNum = double.Parse(token);
                            LeftSideflag = true;
                        }
                        exp.Operation = Mathoperation.Subtraction;
                        token = "";
                    }
                }

                else if (char.IsLetter(CurrentChar))
                {
                    token+= CurrentChar;
                    LeftSideflag=true;
                }

                else if(CurrentChar==' ')
                {
                    if (!LeftSideflag)
                    {
                        exp.LeftNum=double.Parse(token);
                        LeftSideflag = true;
                        token = "";
                    }
                    else if (exp.Operation == Mathoperation.none)
                    {
                          exp.Operation=ParseMathOperation(token);
                        token = "";
                    }
                }
                else token += CurrentChar; 
            }

            return exp;
        }

        private static Mathoperation ParseMathOperation(string operation)
        {
            switch (operation.ToLower())
            {
                case "+":
                    return Mathoperation.Addition;
                case "*":
                    return Mathoperation.Multiplication;
                case "/":
                    return Mathoperation.Division;
                case "%":
                case"mod":
                    return Mathoperation.modules;
                case "^":
                case "pow":
                    return Mathoperation.Power;
                case "sin":
                    return Mathoperation.Sin;
                case "cos":
                    return Mathoperation.Cos;
                case "Tan":
                    return Mathoperation.Tan;

                    default:
                    return Mathoperation.none;
            }
        }
    }
}
