using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4100_Compiler_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // int MaxQuad = 1000;
            QuadTable Quad1 = new QuadTable();
            ReserveTableClass Reserve1 = new ReserveTableClass();
            SymbolTable SymbolTable1 = new SymbolTable();

            BuildQuads(Quad1, Reserve1);
            BuildSymbolTable(SymbolTable1);

            
            InterpretQuads(Quad1, SymbolTable1, true);
            InterpretQuads(Quad1, SymbolTable1, false);

        }

        // these are redundant
        public static void BuildQuads(QuadTable quad, ReserveTableClass reserve)
        // not taking maxQuad yet
        {
            quad.PrintQuadTable();
            reserve.PrintReserveTable();
        }

        private static void BuildSymbolTable(SymbolTable symbolTable)
        {
            symbolTable.PrintSymbolTable();
        }

        private static void InterpretQuads(QuadTable Q, SymbolTable S, bool TraceOn)
        {
            Interpreter interpreterTrace = new Interpreter();
            interpreterTrace.IntrepretQuads(Q, S, TraceOn);
            
        }
    }

}
