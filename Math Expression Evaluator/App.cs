using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Expression_Evaluator
{
    internal class App
    {
        public static void Run(string[] args)
        {
            while (true)
            {
                
                Console.WriteLine("Please Enter Math Expression: ");
                var input = Console.ReadLine();
                var exp = ExpressionParser.Parse(input);
                Console.WriteLine($"Left Side = {exp.LeftNum}, Operation = {exp.Operation}, Right Side = {exp.RightNum}");
                Console.WriteLine($"{input} = {EvaluateExpression(exp)}");
             }
        }

        private static object EvaluateExpression(MathExpression exp)
        {
            if (exp.Operation == Mathoperation.Addition)
            {
                return exp.LeftNum+exp.RightNum;
            }
            else if(exp.Operation == Mathoperation.Subtraction)
            {
                return exp.LeftNum-exp.RightNum;
            }
            else if (exp.Operation == Mathoperation.Division)
            {
                return exp.LeftNum / exp.RightNum;
            }
            else if (exp.Operation == Mathoperation.Multiplication)
            {
                return exp.LeftNum * exp.RightNum;
            }
            else if (exp.Operation == Mathoperation.modules)
            {
                return exp.LeftNum % exp.RightNum;
            }
            else if (exp.Operation == Mathoperation.Power)
            {
                return Math.Pow(exp.LeftNum,  exp.RightNum);
            }
            else if (exp.Operation == Mathoperation.Cos)
            {
                return Math.Cos(exp.RightNum);
            }
            else if (exp.Operation == Mathoperation.Sin)
            {
                return Math.Sin(exp.RightNum);
            }
            else if (exp.Operation == Mathoperation.Tan)
            {
                return Math.Tan(exp.RightNum);
            }
            return 0;

        }
    }
}
