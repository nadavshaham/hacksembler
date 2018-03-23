using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hacksembler
{
    enum Day { Sat, Sun, Mon, Tue, Wed, Thu, Fri };
    enum commandType { A_COMMAND, C_COMMAND, L_COMMAND};
    

    class Program
    {
        public class Parser
        {

            private System.IO.StreamReader sourceFile;
            private Boolean bHasMoreCommands;
            private string currentCommand;
 
            private int symbol_counter;


            public Parser(string sourcePath)
            {
                sourceFile = new System.IO.StreamReaderM(sourcePath);
                Advance();
            }

            // Are there more commands in the input?
            public Boolean HasMoreCommands()
            {
                return bHasMoreCommands;
            }

            // Reads the next command from the input and makes it current command
            // Should be called only if HasMoreCommands is true.
            public void Advance()
            {
                string line="";
                bHasMoreCommands = false;

                
                while ((line = sourceFile.ReadLine()) != null)
                {                    
                    line = line.Trim();
                    
                    // if line STARTS with "//" - next
                    if (line.StartsWith("/"))
                    {

                        continue;
                    }                    
                    // if line is empty - next
                    if (String.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    //line = line.TrimEnd('/');
                        if (line.Contains("//"))
                        {
                            int foundS1 = line.IndexOf('\u002f');

                            line = line.Remove(foundS1);
                        }
                    // hweaRRYYYY!!! I found a command!!!
                    // damm we still need to trim end // to get a clean command
                    
                    if (sourceFile.Peek() != -1)
                    {
                        bHasMoreCommands = true;
                    }
                    //Console.WriteLine(sourceFile.Peek());
                    currentCommand = line;
                    Console.WriteLine(line);
                    break; 
                }
                

            }

            // returns the type of the current command 
            //A_COMMAND for @xxx wehre xxx is either a symbol or a decimal number
            //C_COMMAND for dest=comp;jump
            //L_COMMAND(pseudo command for xxx where xxx is a symbol
            public commandType CommandType()
            {
                
               
                
                if (currentCommand.Contains("=") || currentCommand.Contains(";"))
                {
                    return commandType.C_COMMAND;
                    
                }
                if (currentCommand.Contains("@"))
                {
                    return commandType.A_COMMAND;
                }

                Debug.Assert(false);
                return commandType.L_COMMAND;
            }

            //Returns the symbol or decimal xxx of the current command @xxx or(xxx)
            //Should be called only when commandType() is A_COMMAND or L_COMMAND
            public string Symbol()
            {
                return "";
            }

            //Return the dest mnemonic in the current C command (8 possibilities)
            //Should  be called only when commandType() is C_COMMAND
            public string Dest()
            {
                return "";
            }

            //Returns the comp mnemonic in the current C command(28 possibilities)
            //Should be called only when commandType() is C_COMMAND
            public string Comp()
            {
                return "";
            }

            //returns the jump mnemonic im the current C command (8 possibilities)
            //Should be called only when commandType() is C_COMMAND
            public string Jump()
            {
                return "";
            }

            /*
            public string Parse()
            {
                int counter = 0;
                string line;
                //string exmpale = "just to compare";
                int symbol_counter=0;

                //Read the file and display it line by line.  
                while ((line = sourceFile.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                    counter++;
                    if ((line.Contains('@')== true) || (line.Contains('=')== true) || (line.Contains('/')== true) ||(line.Contains(" ")==false))
                    {
                        symbol_counter++;
                    }
                }

                sourceFile.Close();
                Console.ReadLine();
                return symbol_counter.ToString();
            }
            */
        }
        static void Main(string[] args)
        {
            commandType x;

            Parser Parser = new Parser("D:\\Nadav\\HDL\\asm\\mult.asm");
            
            //Console.WriteLine(Parser.bHasMoreCommands);
            while (Parser.HasMoreCommands())
            {
                x = Parser.CommandType();
                Console.WriteLine(x);
                Parser.Advance();
            }
            
            
            //Console.WriteLine(Parser.Parse());

            Console.ReadLine();
        }
    }
}
