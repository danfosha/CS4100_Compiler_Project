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
            ReserveTable[0] = new ReserveTableData("STOP", 0);
            ReserveTable[1] = new ReserveTableData("DIV", 1);
            ReserveTable[2] = new ReserveTableData("MUL", 2);
            ReserveTable[3] = new ReserveTableData("SUB", 3);
            ReserveTable[4] = new ReserveTableData("ADD", 4);
            ReserveTable[5] = new ReserveTableData("MOV", 5);
            ReserveTable[6] = new ReserveTableData("STI", 6);
            ReserveTable[7] = new ReserveTableData("LDI", 7);
            ReserveTable[8] = new ReserveTableData("BNZ", 8);
            ReserveTable[9] = new ReserveTableData("BNP", 9);
            ReserveTable[10] = new ReserveTableData("BNN", 10);
            ReserveTable[11] = new ReserveTableData("BZ", 11);
            ReserveTable[12] = new ReserveTableData("BP", 12);
            ReserveTable[13] = new ReserveTableData("BN", 13);
            ReserveTable[14] = new ReserveTableData("BR", 14);
            ReserveTable[15] = new ReserveTableData("BINDR", 15);
            ReserveTable[16] = new ReserveTableData("PRINT", 16);

        }


        int Add(string name, int code)
        // Returns the index of the row where the data was placed; just adds to end of list.
        {
            int notUsed = 0;
            foreach (ReserveTableData Data in ReserveTable)
            {
                // check this conditional
                if (ReserveTable[notUsed] == null)
                {
                    notUsed++;
                }
            }
            ReserveTable[notUsed] = new ReserveTableData(name, code);
            return notUsed;
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

