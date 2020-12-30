using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using helper;

namespace day18
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> expressions = new List<string>();
            expressions = Library.ReadList<string>("test.txt");

            Library.PrintList<string>(expressions);

            // long result1 = SolvePart1(expressions);
            // Library.WriteResult(1,result1);

            long result2 = SolvePart2(expressions);
            Library.WriteResult(2,result2);
        }
        static long SolvePart1(List<string> expressions)
        {
            Stack<long> vals = new Stack<long>();
            Stack<char> ops = new Stack<char>();
            long sum = 0;
            foreach(string currentExp in expressions)
            {
                int group = 0;
                for(int i = 0; i<currentExp.Length;i++)
                {
                    long temp = 0;
                    if(currentExp[i] == ' ') continue;
                    else if(Int64.TryParse(currentExp[i].ToString(),out temp))
                    {
                        vals.Push(temp);
                    }
                    else if(currentExp[i]=='(')
                    { 
                        ops.Push(currentExp[i]);
                        group++;
                    }
                    else if(currentExp[i]==')')
                    { 
                        Stack<long> revVal = new Stack<long>();
                        Stack<char> revOps = new Stack<char>();

                        //ops.Push(currentExp[i]);
                        while(ops.Peek()!='(')
                        {
                            revVal.Push(vals.Pop());
                            revOps.Push(ops.Pop());
                        }
                        revVal.Push(vals.Pop());
                        while(revOps.Count>0)
                        {
                            long res = Evaluate(revOps.Pop().ToString(),revVal.Pop(),revVal.Pop());
                            revVal.Push(res);
                        }
                        vals.Push(revVal.Pop());
                        ops.Pop();
                        group--;
                    }
                    else
                    {
                        if(vals.Count > 1 && group == 0)
                        {
                            long res = Evaluate(ops.Pop().ToString(),vals.Pop(),vals.Pop());
                            vals.Push(res);
                            ops.Push(currentExp[i]);
                        }
                        else
                        {
                            ops.Push(currentExp[i]);
                        }
                    }         
                }
                while(ops.Count>0)
                {
                    long res = Evaluate(ops.Pop().ToString(),vals.Pop(),vals.Pop());
                    vals.Push(res);
                }
                sum += vals.Pop();
            }
            
            return sum;
        }
        static private bool HasPrecedence(char op1, char op2)
        {
            if(op2 == '*' && op1=='+') return false;
            else return true;
        }
        static private long Evaluate(string opt, long val1, long val2)
        {
            if (opt == "+") return val1+val2;
            else return val1 * val2;
        }
        static long SolvePart2(List<string> expressions)
        {
            Stack<long> vals = new Stack<long>();
            Stack<char> ops = new Stack<char>();
            long sum = 0;
            foreach(string currentExp in expressions)
            {
                int group = 0;
                for(int i = 0; i<currentExp.Length;i++)
                {
                    long temp = 0;
                    if(currentExp[i] == ' ') continue;
                    else if(Int64.TryParse(currentExp[i].ToString(),out temp))
                    {
                        vals.Push(temp);
                    }
                    else if(currentExp[i]=='(')
                    { 
                        ops.Push(currentExp[i]);
                        group++;
                    }
                    else if(currentExp[i]==')')
                    { 
                        Stack<long> revVal = new Stack<long>();
                        Stack<char> revOps = new Stack<char>();
                        Stack<char> tempOps = new Stack<char>();
                        Stack<long> tempVal = new Stack<long>();
                        //ops.Push(currentExp[i]);
                        while(ops.Peek()!='(')
                        {
                            tempVal.Push(vals.Pop());
                            tempOps.Push(ops.Pop());
                        }
                        tempVal.Push(vals.Pop());
                        string buff = String.Empty;
                        while(tempVal.Count>1)
                        {
                            buff += tempVal.Pop().ToString() +  tempOps.Pop().ToString(); 
                        }
                        buff +=tempVal.Pop().ToString();
                        Console.WriteLine(buff);
                        for(int d= 0; d<buff.Length;d++)
                        {
                            if(buff[d] != '*' && buff[d] !='+')
                            {
                                revVal.Push(Int32.Parse(buff[d].ToString()));
                            }
                            else
                            {
                                char op=buff[d];
                                while(revOps.Count>0 && HasPrecedence(op, revOps.Peek()))
                                {
                                    long res = Evaluate(revOps.Pop().ToString(),revVal.Pop(),revVal.Pop());
                                    revVal.Push(res);
                                }
                                revOps.Push(buff[d]);
                            }
                        }
                        // while(tempOps.Count>0)
                        // {
                        //     char op = tempOps.Pop();
                        //     if(tempOps.Count == 0)
                        //     {
                        //         long res = Evaluate(op.ToString(),revVal.Pop(),revVal.Pop());
                        //         tempVal.Push(res);
                        //     }
                        //     else
                        //     {
                        //         while(revOps.Count>0 && HasPrecedence(op,revOps.Peek()))
                        //         {
                        //             long res = Evaluate(revOps.Pop().ToString(),revVal.Pop(),revVal.Pop());
                        //             revVal.Push(res);
                        //         }
                        //         revOps.Push(op); 
                        //     }
                               
                        // }
                        vals.Push(revVal.Pop());
                        ops.Pop();
                        group--;
                    }
                    else
                    {
                        if(ops.Count > 0 && group == 0)
                        {
                            //'if(HasPrecedence(ops.Pop(), ops.Peek()))
                            char op=currentExp[i];
                            while(ops.Count>0 && HasPrecedence(op, ops.Peek()))
                            {
                                long res = Evaluate(ops.Pop().ToString(),vals.Pop(),vals.Pop());
                                vals.Push(res);
                            }
                            ops.Push(currentExp[i]);
                            //Console.WriteLine("..");
                        }
                        else
                        {
                            ops.Push(currentExp[i]);
                        }
                    }         
                }
                while(ops.Count>0)
                {
                    long res = Evaluate(ops.Pop().ToString(),vals.Pop(),vals.Pop());
                    vals.Push(res);
                }
                sum += vals.Pop();
            }
            
            return sum;
        }
        
    }
}
