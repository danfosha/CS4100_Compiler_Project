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
            int MaxQuad = 100;

            //Run one
            QuadTable Quads1 = new QuadTable(MaxQuad);
            ReserveTableClass Reserves = new ReserveTableClass();            
            SymbolTable Symbols1 = new SymbolTable(MaxQuad);

            BuildQuads1(Quads1, Reserves);
            BuildSymbolTable1(Symbols1);

            InterpretQuads(Quads1, Symbols1, true);
            InterpretQuads(Quads1, Symbols1, false);
            Console.WriteLine("Press any key to continue to next run");
            Console.ReadKey();

            // Run two
            QuadTable Quads2 = new QuadTable(MaxQuad);
            SymbolTable Symbols2 = new SymbolTable(MaxQuad);

            BuildQuads2(Quads2, Reserves);
            BuildSymbolTable2(Symbols2);           

            InterpretQuads(Quads2, Symbols2, true);
            InterpretQuads(Quads2, Symbols2, false);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
        
        public static void BuildQuads1(QuadTable quads, ReserveTableClass reserve)
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
            quads.AddQuad(0, 0, 0, 0);
            
            reserve.Initialize();

            quads.PrintQuadTable();
            reserve.PrintReserveTable();
        }

        public static void BuildQuads2(QuadTable quads, ReserveTableClass reserve)
        {
            quads.AddQuad(3, 2, 0, 3);
            quads.AddQuad(12, 3, 0, 5);
            quads.AddQuad(2, 1, 2, 1);
            quads.AddQuad(4, 4, 2, 2);
            quads.AddQuad(14, 0, 0, 0);
            quads.AddQuad(16, 1, 0, 0);
            quads.AddQuad(0, 0, 0, 0);
            
            reserve.Initialize();

            quads.PrintQuadTable();
            reserve.PrintReserveTable();
        }

        public static void BuildSymbolTable1(SymbolTable symbolTable)
        {
            symbolTable.AddSymbol("score1    ", SymbolTable.Data_Kind.variable, 73);
            symbolTable.AddSymbol("score2    ", SymbolTable.Data_Kind.variable, 65);
            symbolTable.AddSymbol("score3    ", SymbolTable.Data_Kind.variable, 89);
            symbolTable.AddSymbol("score4    ", SymbolTable.Data_Kind.variable, 93);
            symbolTable.AddSymbol("score5    ", SymbolTable.Data_Kind.variable, 80);
            symbolTable.AddSymbol("i         ", SymbolTable.Data_Kind.variable, 0);
            symbolTable.AddSymbol("sum       ", SymbolTable.Data_Kind.variable, 0);
            symbolTable.AddSymbol("0         ", SymbolTable.Data_Kind.constant, 0);
            symbolTable.AddSymbol("num_scores", SymbolTable.Data_Kind.constant, 5);
            symbolTable.AddSymbol("comp_result", SymbolTable.Data_Kind.constant, 0);
            symbolTable.AddSymbol("temp_add", SymbolTable.Data_Kind.variable, 0);
            symbolTable.AddSymbol("increment", SymbolTable.Data_Kind.constant, 1);

            symbolTable.PrintSymbolTable();
        }

        public static void BuildSymbolTable2(SymbolTable symbolTable)
        {
            symbolTable.AddSymbol("n_factorial", SymbolTable.Data_Kind.variable, 10);
            symbolTable.AddSymbol("product    ", SymbolTable.Data_Kind.variable, 1);
            symbolTable.AddSymbol("i          ", SymbolTable.Data_Kind.variable, 2);
            symbolTable.AddSymbol("sub_compare", SymbolTable.Data_Kind.variable, 0);
            symbolTable.AddSymbol("1          ", SymbolTable.Data_Kind.constant, 1);
          
            symbolTable.PrintSymbolTable();
        }

        private static void InterpretQuads(QuadTable Q, SymbolTable S, bool TraceOn)
        {
            Interpreter interpreterTrace = new Interpreter();
            interpreterTrace.IntrepretQuads(Q, S, TraceOn);            
        }
    }

}
