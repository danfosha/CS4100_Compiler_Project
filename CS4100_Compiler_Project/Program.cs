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
            // make constant
            int MaxQuad = 100;
            QuadTable Quads = new QuadTable(MaxQuad);
            ReserveTableClass Reserves = new ReserveTableClass();
            
            SymbolTable Symbols = new SymbolTable(MaxQuad);

            BuildQuads(Quads, Reserves);
            BuildSymbolTable(Symbols);

            InterpretQuads(Quads, Symbols, true);
            InterpretQuads(Quads, Symbols, false);
            Console.ReadLine();
			
        }

        // these are redundant
        public static void BuildQuads(QuadTable quads, ReserveTableClass reserve)
        {
            quads.AddQuad(5, 7, 0, 6);
            quads.AddQuad(5, 7, 0, 5);
            quads.AddQuad(3, 5, 8, 9);
            quads.AddQuad(10, 9, 0, 8);
            quads.AddQuad(7, 0, 5, 10);
            quads.AddQuad(4, 6, 10, 6);
            quads.AddQuad(4, 5, 11, 5);
            quads.AddQuad(14, 0, 0, 2);
            quads.AddQuad(16, 6, 0, 0);
            quads.AddQuad(0, 0, 0, 2);
            quads.PrintQuadTable();
            reserve.Initialize();
            reserve.PrintReserveTable();
        }

        public static void BuildSymbolTable(SymbolTable symbolTable)
        {
            symbolTable.AddSymbol("scores", SymbolTable.Data_Kind.variable, 73);
            symbolTable.AddSymbol("$1", SymbolTable.Data_Kind.variable, 65);
            symbolTable.AddSymbol("$2", SymbolTable.Data_Kind.variable, 89);
            symbolTable.AddSymbol("$3", SymbolTable.Data_Kind.variable, 93);
            symbolTable.AddSymbol("$4", SymbolTable.Data_Kind.variable, 80);
            symbolTable.AddSymbol("i", SymbolTable.Data_Kind.variable, 0);
            symbolTable.AddSymbol("sum", SymbolTable.Data_Kind.variable, 0);
            symbolTable.AddSymbol("$5", SymbolTable.Data_Kind.variable, 0);
            symbolTable.AddSymbol("$6", SymbolTable.Data_Kind.constant, 5);
            symbolTable.AddSymbol("$7", SymbolTable.Data_Kind.constant, 0);
            symbolTable.AddSymbol("$8", SymbolTable.Data_Kind.variable, 0);
            symbolTable.AddSymbol("$9", SymbolTable.Data_Kind.constant, 1);

            symbolTable.PrintSymbolTable();
        }

        private static void InterpretQuads(QuadTable Q, SymbolTable S, bool TraceOn)
        {
            Interpreter interpreterTrace = new Interpreter();
            interpreterTrace.IntrepretQuads(Q, S, TraceOn);
            
        }
    }

}
