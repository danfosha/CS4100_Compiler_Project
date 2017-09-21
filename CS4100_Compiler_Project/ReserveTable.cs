using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4100_Compiler_Project
// Fosha CS4100 Project 1 Fall 2017
{
    class ReserveTableClass
    {
        // This is a lookup table ADT that will be used here for the opcode lookup, and later in the compiler, a
        // separate instance will hold the reserved word list for the language.Make sure it is built so that it can be
        // used for both applications.  Each indexed entry is a pair consisting of a name string and an integer code.
        // The table as we use it is static, and intialized once at the start of the program, and then used only for
        // lookups later on.


        protected int numUsed = 0;

        public class ReserveTableData
        {
            public ReserveTableData(string name, int code)
            {
                Name = name;
                Code = code;
            }

            public string Name { get; set; }
            public int Code { get; set; }

        }

        static ReserveTableData[] ReserveTable = new ReserveTableData[100];


        // The needed methods are:

        public void Initialize()
        // Constructor, as needed.
        {
            int ReserveCount = 0; //  how to use this value later? Why return value for add function?

            ReserveCount = Add("STOP", 0);
            ReserveCount = Add("DIV", 1);
            ReserveCount = Add("MUL", 2);
            ReserveCount = Add("SUB", 3);
            ReserveCount = Add("ADD", 4);
            ReserveCount = Add("MOV", 5);
            ReserveCount = Add("STI", 6);
            ReserveCount = Add("LDI", 7);
            ReserveCount = Add("BNZ", 8);
            ReserveCount = Add("BNP", 9);
            ReserveCount = Add("BNN", 10);
            ReserveCount = Add("BZ", 11);
            ReserveCount = Add("BP", 12);
            ReserveCount = Add("BN", 13);
            ReserveCount = Add("BR", 14);
            ReserveCount = Add("BINDR", 15);
            ReserveCount = Add("PRINT", 16);

        }


        public int Add(string name, int code)
        // Returns the index of the row where the data was placed; just adds to end of list.
        {
            ReserveTable[numUsed] = new ReserveTableData(name, code);
            return numUsed++;
        }


        public int LookupName(String name)
        // Returns the code associated with name if name is in the table, else returns -1
        {
            foreach (ReserveTableData Data in ReserveTable)
            {

                if (Data.Name == name)
                {
                    return Data.Code;
                }
            }
            return -1;
        }


        public static string LookupCode(int code)
        // Returns the associated name if code is there, else an empty string
        {
            foreach (ReserveTableData Data in ReserveTable)
            {

                if (Data.Code == code)
                {
                    return Data.Name;
                }
            }
            return "";
        }
        
        public void PrintReserveTable()
        // Prints the currently used contents of the Reserve table in neat tabular format
        {
            Console.WriteLine("Name" + "\t" + "Code");
            Console.WriteLine("*************");
            foreach (ReserveTableData ReserveData in ReserveTable)
            {
                if (ReserveData != null)
                {
                    Console.WriteLine(ReserveData.Name + "\t" + ReserveData.Code);
                }
            }
            Console.WriteLine("\n");
        }
    }
}

