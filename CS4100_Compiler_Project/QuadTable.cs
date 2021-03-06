﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4100_Compiler_Project
// Fosha CS4100 Project 1 Fall 2017
{
    class QuadTable
    {

        static int MaxSymbols = 100;
        protected int NumUsed = 0;

        public QuadTable(int maxSymbols)
        {
            {
                MaxSymbols = maxSymbols;
            }
        }
                
        public class QuadStruct
        {

            public QuadStruct(int opcode, int op1, int op2, int op3)
            {

                OpCode = opcode;
                Op1 = op1;
                Op2 = op2;
                Op3 = op3;
            }

            public int OpCode { get; set; }
            public int Op1 { get; set; }
            public int Op2 { get; set; }
            public int Op3 { get; set; }

        }


        QuadStruct[] QuadTableArray = new QuadStruct[MaxSymbols];
        
        // The QuadTable is different from the SymbolTable in its access and contents.Each indexed entry row
        //  consists of four int values representing an opcode and three operands.  The methods needed are:

        public static void Initialize()  // size and other parameters as needed
        // Create a new, empty QuadTable ready for data to be added, with the specified number of rows(size).
        {
            // I wasn't able to match signature of method with code that create an array 
            // accessible to other methods with the method Initialize();
        }

        public int NextQuad()
        // Returns the int index of the next open slot in the QuadTable. Very important during code generation, this must be implemented exactly as described.
        {
            return NumUsed++;
        }


        public void AddQuad(int opcode, int op1, int op2, int op3)
        // Expands the active length of the quad table by adding a new row at the NextQuad slot, with the parameters sent as the new contents, 
        // and increments the NextQuad counter to the next available(empty) index.}
        {
            QuadTableArray[NextQuad()] = new QuadStruct(opcode, op1, op2, op3);

        }

        public QuadStruct GetQuad(int index)
        // Returns the data for the opcode and three operands located at index
        {
            return QuadTableArray[index];
        }

        void SetQuad(int index, int opcode, int op1, int op2, int op3)
        // Changes the contents of the existing quad at index. Used only when backfilling
        // jump addresses later, during code generation, and very important
        {
            QuadTableArray[index].OpCode = opcode;
            QuadTableArray[index].Op1 = op1;
            QuadTableArray[index].Op2 = op2;
            QuadTableArray[index].Op3 = op3;
        }

        public string GetMnemonic(int opcode)
        // Returns the mnemonic string (‘ADD’, ‘PRINT’, etc.) associated with the opcode parameter. Used during interpreter
        // ‘TRACE’ mode to print out the stored opcodes in readable format. Use the ReserveTable ADT to implement this.
        {
            string code = ReserveTableClass.LookupCode(opcode);
            return code;
        }

        public void PrintQuadTable()
        //Prints the currently used contents of the Quad table in neat tabular format
        {
            Console.WriteLine("OpCode" + "\t" + "Op1" + "\t" + "Op2" + "\t" + "Op3");
            Console.WriteLine("****************************");
            foreach (QuadStruct Quad in QuadTableArray)
            {
                if (Quad != null)
                {
                    Console.WriteLine(GetMnemonic(Quad.OpCode) + "\t" + Quad.Op1 + "\t" + Quad.Op2 + "\t" + Quad.Op3);
                }
            }
            Console.WriteLine("\n");

        }


    }
}
