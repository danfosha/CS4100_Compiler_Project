using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4100_Compiler_Project
{
    class Interpreter
    {

        public int PC, OpCode, Op1, Op2, Op3 = 0;
        public int MaxQuad = 1000;
        public bool TraceOn;
        public SymbolTable SymbolTable;
        public QuadTable QuadTable;


        public Interpreter() { }
        
        public void IntrepretQuads(QuadTable quadTable, SymbolTable symbolTable, bool traceOn)
        {
            while (PC < MaxQuad)
            {
                
            }

        }
    }
}
