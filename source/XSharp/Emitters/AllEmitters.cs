﻿using System;
using Spruce.Attribs;
using Spruce.Tokens;
using XSharp.Tokens;
using XSharp.x86;

namespace XSharp.Emitters
{
    // Emitters does the actual translation from X# (via Spruce) to x86 (via Assemblers)
    public class AllEmitters : Emitters
    {
        public AllEmitters(Compiler aCompiler, x86.Assemblers.Assembler aAsm) : base(aCompiler, aAsm)
        {
        }

        // ===============================================================
        // Keywords

        // ===============================================================
        // Reg =

        [Emitter(typeof(Reg), typeof(OpEquals), typeof(OpOpenBracket), typeof(Variable), typeof(OpPlus), typeof(Int32u), typeof(OpCloseBracket))]
        [Emitter(typeof(Reg), typeof(OpEquals), typeof(OpOpenBracket), typeof(Variable), typeof(OpMinus), typeof(Int32u), typeof(OpCloseBracket))]
        [Emitter(typeof(Reg), typeof(OpEquals), typeof(OpOpenBracket), typeof(Reg), typeof(OpPlus), typeof(Int32u), typeof(OpCloseBracket))]
        [Emitter(typeof(Reg), typeof(OpEquals), typeof(OpOpenBracket), typeof(Reg), typeof(OpMinus), typeof(Int32u), typeof(OpCloseBracket))]
        protected void MemoryAssignToReg(Register aDestReg, string aOpEquals, string aOpOpen, object aSrc, string aOp, UInt32 aOffset, string aOpClose)
        {
        }

        [Emitter(typeof(OpOpenBracket), typeof(Reg), typeof(OpCloseBracket), typeof(OpEquals), typeof(Reg))]
        [Emitter(typeof(OpOpenBracket), typeof(Reg), typeof(OpCloseBracket), typeof(OpEquals), typeof(Variable))]
        [Emitter(typeof(OpOpenBracket), typeof(Reg), typeof(OpCloseBracket), typeof(OpEquals), typeof(Int32u))]
        protected void ValueAssignToMemory(string aOpOpenBracket, Register aTargetRegisterRoot, string aOpCloseBracket, string aOpEquals, object source)
        {
        }

        [Emitter(typeof(OpOpenBracket), typeof(Reg), typeof(OpPlus), typeof(Int32u), typeof(OpCloseBracket), typeof(OpEquals), typeof(Reg))]
        [Emitter(typeof(OpOpenBracket), typeof(Reg), typeof(OpPlus), typeof(Reg), typeof(OpCloseBracket), typeof(OpEquals), typeof(Reg))]
        [Emitter(typeof(OpOpenBracket), typeof(Reg), typeof(OpMinus), typeof(Int32u), typeof(OpCloseBracket), typeof(OpEquals), typeof(Reg))]
        [Emitter(typeof(OpOpenBracket), typeof(Reg), typeof(OpMinus), typeof(Reg), typeof(OpCloseBracket), typeof(OpEquals), typeof(Reg))]
        [Emitter(typeof(OpOpenBracket), typeof(Reg), typeof(OpPlus), typeof(Int32u), typeof(OpCloseBracket), typeof(OpEquals), typeof(Variable))]
        [Emitter(typeof(OpOpenBracket), typeof(Reg), typeof(OpPlus), typeof(Reg), typeof(OpCloseBracket), typeof(OpEquals), typeof(Variable))]
        [Emitter(typeof(OpOpenBracket), typeof(Reg), typeof(OpMinus), typeof(Int32u), typeof(OpCloseBracket), typeof(OpEquals), typeof(Variable))]
        [Emitter(typeof(OpOpenBracket), typeof(Reg), typeof(OpMinus), typeof(Reg), typeof(OpCloseBracket), typeof(OpEquals), typeof(Variable))]
        protected void RegAssignToMemory(string aOpOpenBracket, Register aTargetRegisterRoot, string aOpOperator, object aOffset, string aOpCloseBracket, string aOpEquals, object source)
        {
        }

        // Don't use Reg. This method ensures proper data sizes.
        // This could be combined with RegAssignReg by using object type for last arg, but this is a bit cleaner to separate.
        [Emitter(typeof(Reg08), typeof(OpEquals), typeof(Int08u))] // AH = 0
        [Emitter(typeof(Reg16), typeof(OpEquals), typeof(Int16u))] // AX = 0
        [Emitter(typeof(Reg32), typeof(OpEquals), typeof(Int32u))] // EAX = 0
        protected void RegAssigNum(Register aDestReg, string aEquals, object aVal)
        {
            int i = 4;
            //Asm.Emit(OpCode.Mov, aDestReg, aSrcReg);
        }

        // OLD to be deprecated in G2. Use EAX = [EBX + 4] instead
        // EAX = EBX[4]
        //[Emitter(typeof(Reg32), typeof(OpEquals), typeof(Reg32), typeof(OpOpenBracket), typeof(Int08u), typeof(OpCloseBracket))]
        //protected void RegTest3(object a1, object a2, object a3, object a4, object a5, object a6) {
        //    int i = 4;
        //}

        [Emitter(typeof(Reg), typeof(OpEquals), typeof(Variable))]
        [Emitter(typeof(Reg), typeof(OpEquals), typeof(Const))]
        [Emitter(typeof(Reg32), typeof(OpEquals), typeof(VariableAddress))]
        protected void RegAssigOther(Register aReg, string aEquals, object aVal)
        {
            int i = 4;
            //Asm.Emit(OpCode.Mov, aReg, aVal);
        }

        // ===============================================================

        [Emitter(typeof(Variable), typeof(OpEquals), typeof(Int08u))]
        [Emitter(typeof(Variable), typeof(OpEquals), typeof(Int16u))]
        [Emitter(typeof(Variable), typeof(OpEquals), typeof(Int32u))]
        [Emitter(typeof(Variable), typeof(OpEquals), typeof(Variable))]
        [Emitter(typeof(Variable), typeof(OpEquals), typeof(VariableAddress))]
        [Emitter(typeof(Variable), typeof(OpEquals), typeof(Const))]
        [Emitter(typeof(Variable), typeof(OpEquals), typeof(Reg))]
        protected void VariableAssignment(string aVariableName, string aOpEquals, object aValue)
        {
        }

        // if AL = #Vs2Ds_Noop return
        [Emitter(typeof(If), typeof(Compare), typeof(Return))]
        protected void IfConditionReturn(string aOpIf, object[] aCompareData, object aOpReturn)
        {
        }

        [Emitter(typeof(If), typeof(Compare), typeof(OpOpenBrace))]
        protected void IfConditionBlockStart(string aOpIf, object[] aCompareData, object aOpOpenBrace)
        {
        }

        [Emitter(typeof(If), typeof(Compare), typeof(GotoKeyword), typeof(Identifier))]
        protected void IfConditionGoto(string aOpIf, object[] aCompareData, string aGotoKeyword, string aLabel)
        {
        }

        // if AL = #Vs2Ds_Noop return
        [Emitter(typeof(If), typeof(Size), typeof(CompareVar), typeof(Return))]
        protected void IfConditionReturn(string aOpIf, string aSize, object[] aCompareData, object aOpReturn)
        {
        }

        [Emitter(typeof(If), typeof(Size), typeof(CompareVar), typeof(OpOpenBrace))]
        protected void IfConditionBlockStart(string aOpIf, string aSize, object[] aCompareData, object aOpOpenBrace)
        {
        }

        [Emitter(typeof(If), typeof(Size), typeof(CompareVar), typeof(GotoKeyword), typeof(Identifier))]
        protected void IfConditionGoto(string aOpIf, string aSize, object[] aCompareData, string aGotoKeyword, string aLabel)
        {
        }

        // If = return
        [Emitter(typeof(If), typeof(OpPureComparators), typeof(Return))]
        protected void IfConditionPureReturn(string aOpIf, string aPureComparator, string aReturns)
        {
        }

        [Emitter(typeof(If), typeof(OpPureComparators), typeof(OpOpenBrace))]
        protected void IfConditionPureBlockStart(string aOpIf, string aOpPureComparators, string aOpOpenBrace)
        {
        }

        [Emitter(typeof(If), typeof(OpPureComparators), typeof(GotoKeyword), typeof(Identifier))]
        protected void IfConditionPureGoto(string aOpIf, string aOpPureComparators, string aGotoKeyword, string aLabel)
        {
        }

        [Emitter(typeof(While), typeof(Compare), typeof(OpOpenBrace))]
        protected void WhileConditionBlockStart(string aOpWhile, object[] aCompareData, object aOpOpenBrace)
        {
        }

        [Emitter(typeof(While), typeof(Size), typeof(CompareWithMem), typeof(OpOpenBrace))]
        protected void WhileConditionWithMemoryBlockStart(string aOpWhile, string aSize, object[] aCompareData, object aOpOpenBrace)
        {
        }

        [Emitter(typeof(While), typeof(OpPureComparators), typeof(OpOpenBrace))]
        protected void WhileConditionPureBlockStart(string aOpWhile, string aOpPureComparators, string aOpOpenBrace)
        {
        }

        [Emitter(typeof(Repeat), typeof(Int32u), typeof(Times), typeof(OpOpenBrace))]
        protected void RepeatBlockStart(string aOpRepeat, UInt32 loops, string aOpTimes, string aOpOpenBrace)
        {
        }

        // const i = 0
        [Emitter(typeof(ConstKeyword), typeof(Identifier), typeof(OpEquals), typeof(Int32u))]
        [Emitter(typeof(ConstKeyword), typeof(Identifier), typeof(OpEquals), typeof(StringLiteral))]
        protected void ConstDefinition(string aConstKeyword, string aConstName, string oOpEquals, object aConstValue)
        {
        }

        [Emitter(typeof(VarKeyword), typeof(Identifier), typeof(OpEquals), typeof(Int32u))]
        [Emitter(typeof(VarKeyword), typeof(Identifier), typeof(OpEquals), typeof(StringLiteral))]
        [Emitter(typeof(VarKeyword), typeof(Identifier), typeof(OpEquals), typeof(Const))]
        [Emitter(typeof(VarKeyword), typeof(Identifier), typeof(OpEquals), typeof(Variable))]
        [Emitter(typeof(VarKeyword), typeof(Identifier), typeof(OpEquals), typeof(VariableAddress))]
        protected void VariableDefinition(string aVarKeyword, string aVariableName, string oOpEquals, object aVariableValue)
        {
        }

        [Emitter(typeof(VarKeyword), typeof(Identifier))]
        protected void VariableDefinition(string aVarKeyword, string aVariableName)
        {
        }

        [Emitter(typeof(VarKeyword), typeof(Identifier), typeof(Size), typeof(OpOpenBracket), typeof(Int32u), typeof(OpCloseBracket))]
        protected void VariableArrayDefinition(string aVarKeyword, string aVariableName, string aSize, string aOpOpenBracket, object aNumberOfItems, string aOpCloseBracket)
        {
        }

        [Emitter(typeof(Reg), typeof(OpMath), typeof(Const))]
        [Emitter(typeof(Reg), typeof(OpMath), typeof(Variable))]
        [Emitter(typeof(Reg08), typeof(OpMath), typeof(Int08u))]
        [Emitter(typeof(Reg16), typeof(OpMath), typeof(Int16u))]
        [Emitter(typeof(Reg32), typeof(OpMath), typeof(Int32u))]
        protected void Arithmetic(Register aRegister, string aOpArithmetic, object aValue)
        {
        }

        [Emitter(typeof(Reg), typeof(OpMath), typeof(Reg))]
        protected void ArithmeticRegReg(Register aRegister, string aOpArithmetic, object aValue)
        {
        }

        [Emitter(typeof(Reg), typeof(OpBitwise), typeof(Const))]
        [Emitter(typeof(Reg), typeof(OpBitwise), typeof(Variable))]
        [Emitter(typeof(Reg08), typeof(OpBitwise), typeof(Reg08))]
        [Emitter(typeof(Reg08), typeof(OpBitwise), typeof(Int08u))]
        [Emitter(typeof(Reg16), typeof(OpBitwise), typeof(Reg16))]
        [Emitter(typeof(Reg16), typeof(OpBitwise), typeof(Int16u))]
        [Emitter(typeof(Reg32), typeof(OpBitwise), typeof(Reg32))]
        [Emitter(typeof(Reg32), typeof(OpBitwise), typeof(Int32u))]
        [Emitter(typeof(Reg32), typeof(OpBitwise), typeof(VariableAddress))]
        protected void BitwiseArithmetic(Register aRegister, string aOpBitwise, object aValue)
        {
        }

        [Emitter(typeof(Reg08), typeof(OpEquals), typeof(OpTilde), typeof(Reg08))]
        [Emitter(typeof(Reg16), typeof(OpEquals), typeof(OpTilde), typeof(Reg16))]
        [Emitter(typeof(Reg32), typeof(OpEquals), typeof(OpTilde), typeof(Reg32))]
        protected void BitwiseNot(Register aRegister, string aOpEquals, string aOpTilde, Register aSourceRegister)
        {
        }

        [Emitter(typeof(Reg), typeof(OpShift), typeof(Int08u))]
        protected void BitwiseShift(Register aRegister, string aBitwiseShift, object aNumberBits)
        {
        }

        [Emitter(typeof(Reg), typeof(OpRotate), typeof(Int08u))]
        protected void RotateRegister(Register aRegister, object aOpRotate, object aNumBits)
        {
        }

        // interrupt iNmae123 {
        [Emitter(typeof(Interrupt), typeof(Identifier), typeof(OpOpenBrace))]
        protected void InterruptDefinitionStart(string interruptKeyword, string functionName, string opOpenBraces)
        {
        }

        // function fName123 {
        [Emitter(typeof(Function), typeof(Identifier), typeof(OpOpenBrace))]
        protected void FunctionDefinitionStart(string funcKeyword, string functionName, string opOpenBraces)
        {
        }

        // }
        [Emitter(typeof(OpCloseBrace))]
        protected void BlockEnd(string opCloseBrace)
        {
        }

        [Emitter(typeof(GotoKeyword), typeof(Identifier))]
        protected void Goto(string aGotoKeyword, string aLabelName)
        {
        }

        // Important! All that start with AlphaNum MUST be last to allow fall through to prevent early claims over keywords.
        // fName ()
        [Emitter(typeof(Identifier), typeof(OpOpenParen), typeof(OpCloseParen))]
        protected void FunctionCall(string functionName, string opOpenParanthesis, string opCloseParanthesis)
        {
        }

        // Label
        [Emitter(typeof(Identifier), typeof(OpColon))]
        protected void LabelDefinition(string aLabelName, string aOpColon)
        {
        }
    }
}
