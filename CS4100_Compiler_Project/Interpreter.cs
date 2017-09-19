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
        public int OpCode, Op1, Op2, Op3 = 0;
        public int MaxQuad = 100;
        public bool TraceOn;
        //public SymbolTable SymbolTable;
        //public QuadTable QuadTable;

        public Interpreter() { }

        public void IntrepretQuads(QuadTable quadTable, SymbolTable symbolTable, bool traceOn)
        {
            while (PC < MaxQuad)
            {
                // this could be compressed/refactored somehow
                OpCode = quadTable.GetQuad(PC).OpCode;
                Op1 = quadTable.GetQuad(PC).Op1;
                Op2 = quadTable.GetQuad(PC).Op2;
                Op3 = quadTable.GetQuad(PC).Op3;

                if (OpCode <= 16)
                    switch (OpCode)
                    {
                        case 0: // stop
                            Console.WriteLine("Execution terminated by program stop");
                            PC = MaxQuad;
                            break;

                        case 1: // div
                            // need separate casting types here, double?
                            symbolTable.SymbolTableArray[Op3].Value = (int)(symbolTable.SymbolTableArray[Op1].Value) / (int)(symbolTable.SymbolTableArray[Op2].Value);
                            PC++;
                            break;

                        case 2: // mul
                            symbolTable.SymbolTableArray[Op3].Value = (int)(symbolTable.SymbolTableArray[Op1].Value) * (int)(symbolTable.SymbolTableArray[Op2].Value);
                            PC++;
                            break;

                        case 3: // sub
                            symbolTable.SymbolTableArray[Op3].Value = (int)(symbolTable.SymbolTableArray[Op1].Value) - (int)(symbolTable.SymbolTableArray[Op2].Value);
                            PC++;
                            break;

                        case 4: // sub
                            symbolTable.SymbolTableArray[Op3].Value = (int)(symbolTable.SymbolTableArray[Op1].Value) + (int)(symbolTable.SymbolTableArray[Op2].Value);
                            PC++;
                            break;

                        case 5: // mov
                            symbolTable.SymbolTableArray[Op3].Value = (int)(symbolTable.SymbolTableArray[Op1].Value);
                            PC++;
                            break;

                        case 6: // sti
                            // is this the correct way to offset 2 with 3
                            symbolTable.SymbolTableArray[Op1].Value = (int)(symbolTable.SymbolTableArray[Op2].Value) + (int)(symbolTable.SymbolTableArray[Op3].Value);
                            PC++;
                            break;

                        case 7: // ldi
                            // is this the correct way to offset 1 with 2
                            symbolTable.SymbolTableArray[Op3].Value = (int)(symbolTable.SymbolTableArray[Op1].Value) + (int)(symbolTable.SymbolTableArray[Op2].Value);
                            PC++;
                            break;


                        case 8: // bnz
                            if (Op1 != 0)
                            {
                                PC = quadTable.GetQuad(PC).Op3;
                            }
                            else
                            {
                                PC++;
                            }
                            break;

                        case 9: // bnp
                            if (Op1 <= 0)
                            {
                                PC = quadTable.GetQuad(PC).Op3;
                            }
                            else
                            {
                                PC++;
                            }
                            break;

                        case 10: // bnn
                            if (Op1 >= 0)
                            {
                                PC = quadTable.GetQuad(PC).Op3;
                            }
                            else
                            {
                                PC++;
                            }
                            break;

                        case 11: // bz
                            if (Op1 == 0)
                            {
                                PC = quadTable.GetQuad(PC).Op3;
                            }
                            else
                            {
                                PC++;
                            }
                            break;

                        case 12: // bp
                            if (Op1 > 0)
                            {
                                PC = quadTable.GetQuad(PC).Op3;
                            }
                            else
                            {
                                PC++;
                            }
                            break;

                        case 13: // bn
                            if (Op1 < 0)
                            {
                                PC = quadTable.GetQuad(PC).Op3;
                            }
                            else
                            {
                                PC++;
                            }
                            break;

                        case 14: // br
                            PC = quadTable.GetQuad(PC).Op3;
                            break;

                        case 15: // bindr
                            PC = (int)symbolTable.SymbolTableArray[Op3].Value;
                            break;

                        case 16:
                            Console.WriteLine((string)symbolTable.SymbolTableArray[PC].Name + "\t" + (int)symbolTable.SymbolTableArray[Op1].Value);
                            PC++;
                            break;
                    }

                if ((traceOn) & (PC!=MaxQuad))
                {
                    Console.WriteLine("PC = " + PC + ": " + OpCode + ", " + Op1 + ", " + Op2 + ", " + Op3 );
                }

            }

        }
    }
}
