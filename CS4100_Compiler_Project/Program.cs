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
			quad.AddQuad(5,7,0,6);
            quad.AddQuad(5,7,0,5);
            quad.AddQuad(3,5,8,9);
            quad.AddQuad(10,9,0,8);
            quad.AddQuad(7,0,5,10);
            quad.AddQuad(4,6,10,6);
            quad.AddQuad(4,5,11,5);
            quad.AddQuad(14,6,0,0);
            quad.AddQuad(16,0,0,0);
            quad.AddQuad(0,0,0,2);
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
