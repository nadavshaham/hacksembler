﻿using System;
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
            private string currentCommand;
            private string full_C_Command;
            public string newcommand_symbol;

            public Parser(string sourcePath)
            {
                sourceFile = new System.IO.StreamReaderM(sourcePath);
            }

            public string DestMatrix(string currentCommand2)
            {
                if (currentCommand2 == "0")
                    return "000";
                int coll = 0;
                string[,] matrix = new string[8, 2];
                matrix[0, 0] = "null";
                matrix[0, 1] = "000";
                matrix[1, 0] = "M";
                matrix[1, 1] = "001";
                matrix[2, 0] = "D";
                matrix[2, 1] = "010";
                matrix[3, 0] = "MD";
                matrix[3, 1] = "011";
                matrix[4, 0] = "A";
                matrix[4, 1] = "100";
                matrix[5, 0] = "AM";
                matrix[5, 1] = "101";
                matrix[6, 0] = "AD";
                matrix[6, 1] = "110";
                matrix[7, 0] = "AMD";
                matrix[7, 1] = "111";
                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    if (currentCommand2 == matrix[row, coll])
                    {
                        currentCommand2 = matrix[row, coll + 1];
                        return currentCommand2;
                    }

                }
                return "error";

            }
            public string CompMatrix(string currentCommand2)
            {
                int coll = 0;
                string[,] matrix = new string[28, 2];
                matrix[0, 0] = "0";
                matrix[0, 1] = "0101010";
                matrix[1, 0] = "1";
                matrix[1, 1] = "0111111";
                matrix[2, 0] = "-1";
                matrix[2, 1] = "0111010";
                matrix[3, 0] = "D";
                matrix[3, 1] = "0001100";
                matrix[4, 0] = "A";
                matrix[4, 1] = "0110000";
                matrix[5, 0] = "!D";
                matrix[5, 1] = "0001101";
                matrix[6, 0] = "!A";
                matrix[6, 1] = "0110001";
                matrix[7, 0] = "-D";
                matrix[7, 1] = "0001111";
                matrix[8, 0] = "-A";
                matrix[8, 1] = "0110011";
                matrix[9, 0] = "D+1";
                matrix[9, 1] = "0011111";
                matrix[10, 0] = "A+1";
                matrix[10, 1] = "0110111";
                matrix[11, 0] = "D-1";
                matrix[11, 1] = "0001110";
                matrix[12, 0] = "A-1";
                matrix[12, 1] = "0110010";
                matrix[13, 0] = "D+A";
                matrix[13, 1] = "0000010";
                matrix[14, 0] = "D-A";
                matrix[14, 1] = "0010011";
                matrix[15, 0] = "A-D";
                matrix[15, 1] = "0000111";
                matrix[16, 0] = "D&A";
                matrix[16, 1] = "0000000";
                matrix[17, 0] = "D|A";
                matrix[17, 1] = "0010101";
                matrix[18, 0] = "M";
                matrix[18, 1] = "1110000";
                matrix[19, 0] = "!M";
                matrix[19, 1] = "1110001";
                matrix[20, 0] = "-M";
                matrix[20, 1] = "1110011";
                matrix[21, 0] = "M+1";
                matrix[21, 1] = "1110111";
                matrix[22, 0] = "M-1";
                matrix[22, 1] = "1110010";
                matrix[23, 0] = "D+M";
                matrix[23, 1] = "1000010";
                matrix[24, 0] = "D-M";
                matrix[24, 1] = "1010011";
                matrix[25, 0] = "M-D";
                matrix[25, 1] = "1000111";
                matrix[26, 0] = "D&M";
                matrix[26, 1] = "1000000";
                matrix[27, 0] = "D|M";
                matrix[27, 1] = "1010101";
                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    if (currentCommand2 == matrix[row, coll])
                    {
                        currentCommand2 = matrix[row, coll + 1];
                        return currentCommand2;
                    }
                }
                return "error";
            }

            public string JumpMatrix(string currentCommand2)
            {
                int coll = 0;
                string[,] matrix = new string[8, 2];
                matrix[0, 0] = "null";
                matrix[0, 1] = "000";
                matrix[1, 0] = "JGT";
                matrix[1, 1] = "001";
                matrix[2, 0] = "JEQ";
                matrix[2, 1] = "010";
                matrix[3, 0] = "JGE";
                matrix[3, 1] = "011";
                matrix[4, 0] = "JLT ";
                matrix[4, 1] = "100";
                matrix[5, 0] = "JNE";
                matrix[5, 1] = "101";
                matrix[6, 0] = "JLE";
                matrix[6, 1] = "110";
                matrix[7, 0] = "JMP";
                matrix[7, 1] = "111";
                for (int row = 0; row < matrix.GetLength(0); row++)
                {


                    if (currentCommand2 == matrix[row, coll])
                    {
                        currentCommand2 = matrix[row, coll + 1];
                        return currentCommand2;
                    }

                }
                return "errorjump";
            }

            // Are there more commands in the input?
            public Boolean HasMoreCommands()
            {
                string line = "";
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
                    line = line.Trim();
                    //if (sourceFile.Peek() != -1)
                    currentCommand = line;
                    return true;
                }

                return false;
            }

            // Reads the next command from the input and makes it current command
            // Should be called only if HasMoreCommands is true.
            public void Advance()
            {
                

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
                else
                {
                        return commandType.L_COMMAND;
                }
            }

            //Returns the symbol or decimal xxx of the current command @xxx or(xxx)
            //Should be called only when commandType() is A_COMMAND or L_COMMAND
            public string Symbol()
            {
                int a;
                int length;
                string binary = "0000000000000000";
                string newCommand;
                if (CommandType() == commandType.A_COMMAND)
                {

                    string currentCommand1;
                    currentCommand1 = currentCommand;
                    currentCommand1 = currentCommand1.Substring(1);
                    a = Int32.Parse(currentCommand1);
                    currentCommand1 = Convert.ToString(a, 2);
                    length = currentCommand1.Length;
                    binary = binary.Remove(0, length);
                    newCommand = binary + currentCommand1;
                    return newCommand;

                }
                else
                    return "error_symbol";
            }

            //Return the dest mnemonic in the current C command (8 possibilities)
            //Should  be called only when commandType() is C_COMMAND
            public string Dest()
            {
                




                   // int coll = 0;
                    string currentCommand_dest = currentCommand;
                    int index = currentCommand.IndexOf("=");
                    int index2 = currentCommand.IndexOf(";");
                    if (index > 0)
                    currentCommand_dest = currentCommand_dest.Substring(0, index);
                    if (index2 > 0)
                    currentCommand_dest = currentCommand_dest.Substring(0, index2);
                    if (currentCommand.Contains(";"))
                        return "000";
                    currentCommand_dest = DestMatrix(currentCommand_dest);
                return currentCommand_dest;
                //creating the mnemonic table
                /*
                 string[,] matrix = new string[8, 2];
                matrix[0, 0] = "null";
                matrix[0, 1] = "000";
                matrix[1, 0] = "M";
                matrix[1, 1] = "001";
                matrix[2, 0] = "D";
                matrix[2, 1] = "010";
                matrix[3, 0] = "MD";
                matrix[3, 1] = "011";
                matrix[4, 0] = "A";
                matrix[4, 1] = "100";
                matrix[5, 0] = "AM";
                matrix[5, 1] = "101";
                matrix[6, 0] = "AD";
                matrix[6, 1] = "110";
                matrix[7, 0] = "AMD";
                matrix[7, 1] = "111";
                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                        if (currentCommand1 == matrix[row, coll])
                        {
                            currentCommand1 = matrix[row, coll + 1];
                            return currentCommand1;
                        }

                }
                */
                //for (int coll = 0; coll < matrix.GetLength(1); coll++)
                
            }
            
            //Returns the comp mnemonic in the current C command(28 possibilities)
            //Should be called only when commandType() is C_COMMAND
            public string Comp()
            {


                if (currentCommand.Contains("="))
                {
                    char tab = '\u0009';

                    // int coll = 0;
                    string currentCommand_comp = currentCommand.Replace(tab.ToString(), "");
                    int index = currentCommand.IndexOf("=");
                    if (index > 0)
                        currentCommand_comp = currentCommand_comp.Substring(index + 1);
                    currentCommand_comp = CompMatrix(currentCommand_comp);
                    return currentCommand_comp;
                    /*
                    string[,] matrix = new string[28, 2];
                    matrix[0, 0] = "0";
                    matrix[0, 1] = "0101010";
                    matrix[1, 0] = "1";
                    matrix[1, 1] = "0111111";
                    matrix[2, 0] = "-1";
                    matrix[2, 1] = "0111010";
                    matrix[3, 0] = "D";
                    matrix[3, 1] = "0001100";
                    matrix[4, 0] = "A";
                    matrix[4, 1] = "0110000";
                    matrix[5, 0] = "!D";
                    matrix[5, 1] = "0001101";
                    matrix[6, 0] = "!A";
                    matrix[6, 1] = "0110001";
                    matrix[7, 0] = "-D";
                    matrix[7, 1] = "0001111";
                    matrix[8, 0] = "-A";
                    matrix[8, 1] = "0110011";
                    matrix[9, 0] = "D+1";
                    matrix[9, 1] = "0011111";
                    matrix[10, 0] = "A+1";
                    matrix[10, 1] = "0110111";
                    matrix[11, 0] = "D-1";
                    matrix[11, 1] = "0001110";
                    matrix[12, 0] = "A-1";
                    matrix[12, 1] = "0110010";
                    matrix[13, 0] = "D+A";
                    matrix[13, 1] = "0000010";
                    matrix[14, 0] = "D-A";
                    matrix[14, 1] = "0010011";
                    matrix[15, 0] = "A-D";
                    matrix[15, 1] = "0000111";
                    matrix[16, 0] = "D&A";
                    matrix[16, 1] = "0000000";
                    matrix[17, 0] = "D|A";
                    matrix[17, 1] = "0010101";
                    matrix[18, 0] = "M";
                    matrix[18, 1] = "1110000";
                    matrix[19, 0] = "!M";
                    matrix[19, 1] = "1110001";
                    matrix[20, 0] = "-M";
                    matrix[20, 1] = "1110011";
                    matrix[21, 0] = "M+1";
                    matrix[21, 1] = "1110111";
                    matrix[22, 0] = "M-1";
                    matrix[22, 1] = "1110010";
                    matrix[23, 0] = "D+M";
                    matrix[23, 1] = "1000010";
                    matrix[24, 0] = "D-M";
                    matrix[24, 1] = "1010011";
                    matrix[25, 0] = "M-D";
                    matrix[25, 1] = "1000111";
                    matrix[26, 0] = "D&M";
                    matrix[26, 1] = "1000000";
                    matrix[27, 0] = "D|M";
                    matrix[27, 1] = "010101";
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {

                        if (currentCommand1 == matrix[row, coll])
                        {
                            currentCommand1 = matrix[row, coll + 1];
                            return currentCommand1;
                        }
                    }
                    */
                    //return currentCommand1;

                }
                else if (currentCommand.Contains("D"))
                    return "0001100";
                else
                    return "0101010";




            }

            //returns the jump mnemonic im the current C command (8 possibilities)
            //Should be called only when commandType() is C_COMMAND
            public string Jump()
            {
                

                
                    if (currentCommand.Contains(";"))
                    {
                        char tab = '\u0009';
                        int coll = 0;
                        string currentCommand1 = currentCommand.Replace(tab.ToString(), "");
                        int index = currentCommand.IndexOf(";");
                        if (index > 0)
                            currentCommand1 = currentCommand1.Substring(index + 1);
                        currentCommand1 = JumpMatrix(currentCommand1);
                        return currentCommand1;
                        /*
                        string[,] matrix = new string[8, 2];
                        matrix[0, 0] = "null";
                        matrix[0, 1] = "000";
                        matrix[1, 0] = "JGT";
                        matrix[1, 1] = "001";
                        matrix[2, 0] = "JEQ";
                        matrix[2, 1] = "010";
                        matrix[3, 0] = "JGE";
                        matrix[3, 1] = "011";
                        matrix[4, 0] = "JLT ";
                        matrix[4, 1] = "100";
                        matrix[5, 0] = "JNE";
                        matrix[5, 1] = "101";
                        matrix[6, 0] = "JLE";
                        matrix[6, 1] = "110";
                        matrix[7, 0] = "JMP";
                        matrix[7, 1] = "111";
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {


                            if (currentCommand1 == matrix[row, coll])
                            {
                                currentCommand1 = matrix[row, coll + 1];
                                return currentCommand1;
                            }

                        }
                        */

                    }
                    else
                        return "000";
                    
                


                
            }

            
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
            
        }
        public class CodeModule
        {
            private Parser C_Command= new Parser("D:\\Nadav\\HDL\\asm\\PongL.asm");

            public string Dest1(string C_command_dest)
            {
                return C_command_dest;
            }
            public string Comp1(string C_command_comp)
            {
                return C_command_comp;
            }
            public string Jump1(string C_command_jump)
            {
                return C_command_jump;
            }

        }
        public class SymbolTalble
        {
            //create a new empty symbol table
            public void Constructor()
            {

            }

            //Adds the pair (symbol,address) to the table
            public void addEntry(string symbol,int address)
            {

            }

            //Does the symbol table contain the given symbol
            public Boolean contains(string symbol)
            {
                return true;
            }


            public int GetAddress(string symbol)
            {
                return 1;
            }
        }

        static void Main(string[] args)
        {
            int lineCount = 1;
            commandType x;
            string fileName = "D:\\Nadav\\HDL\\asm\\PongL.asm";

            System.IO.StreamWriter destFile = new System.IO.StreamWriter("D:\\Nadav\\HDL\\asm\\PongLMine1.hack");

            Parser Parser = new Parser(fileName);
            CodeModule code_module1 = new CodeModule();
            //Console.WriteLine(Parser.bHasMoreCommands);
            while (Parser.HasMoreCommands())
            {
                x = Parser.CommandType();
                //Console.WriteLine(x);
                if (x == commandType.C_COMMAND)
                {                     // Console.WriteLine("111"+Parser.Comp()+Parser.Dest()+Parser.Jump());
                    Console.WriteLine("ln:" + lineCount + " 111" + Parser.Comp() + Parser.Dest() + Parser.Jump());
                    destFile.WriteLine("111" + Parser.Comp() + Parser.Dest() + Parser.Jump());
                    lineCount++;
                }
                if (x == commandType.A_COMMAND)
                {
                    Console.WriteLine("ln:" + lineCount + " " + Parser.Symbol());
                    destFile.WriteLine(Parser.Symbol());
                    lineCount++;
                }

                //Console.WriteLine();
                //Console.WriteLine(Parser.Comp());
                Parser.Advance();
            }
            destFile.Close();

            //Console.WriteLine(Parser.Parse());


            Console.ReadLine();
        }
    }

}