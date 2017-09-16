using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4100_Compiler_Project
{
    class Interpreter
    {

        public int PC;
		public int OpCode, Op1, Op2, Op3 = 0; // don't need these if passing QuadTable in
        public int MaxQuad = 1000;
        public bool TraceOn;
        public SymbolTable SymbolTable;
        public QuadTable QuadTable;


        public Interpreter() { }
        
        public void IntrepretQuads(QuadTable quadTable, SymbolTable symbolTable, bool traceOn)
        {
            while (PC < MaxQuad)
            {
                if (quadTable.OpCode<=16)
				switch(QuadTable.OpCode)
				{
					case 0: // stop
						Console.Writeline("Execution terminated by program stop");
						PC = MaxQuad;
						break;

					case 1: // div
						symbolTable[PC].Op3 = symbolTable[PC].Op1 / symbolTable[PC].Op2;
						PC++1;
						break;

					case 8: // bnz
						if (SymbolTable[PC].Op1 <> 0)
						{
							PC = Quadtable[PC].Op3
						}
						else
						{
							PC++1;
						}
						break;

				}
				

            }

        }
    }
}
