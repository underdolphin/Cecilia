﻿using System;
using Irony.Parsing;
namespace Cecilia.Lib
{
    [Language("Cecilia")]
    public class CeciliaGrammer : Grammar
    {
        public CeciliaGrammer()
        {
            #region Literals
            //Literals
            var StringLiteral = TerminalFactory.CreateCSharpString("StringLiteral");
            var CharLiteral = TerminalFactory.CreateCSharpChar("CharLiteral");
            var NumberLiteral = TerminalFactory.CreateCSharpNumber("NumberLiteral");
            var Identifier = TerminalFactory.CreateCSharpIdentifier("Identifier");
            #endregion

            #region Comment
            // Comment
            var SingleLineComment = new CommentTerminal("SingleLineComment", "//", "\r", "\n", "\u2085", "\u2028", "\u2029");
            var DelimitedComment = new CommentTerminal("DelimitedComment", "/*", "*/");
            NonGrammarTerminals.Add(SingleLineComment);
            NonGrammarTerminals.Add(DelimitedComment);
            #endregion

            #region Terminals
            // Terminals
            // Keyword
            var Abstract = ToTerm("abstract");
            var Async = ToTerm("async");
            var Await = ToTerm("await");
            var Base = ToTerm("base");
            var Bool = ToTerm("bool");
            var Break = ToTerm("break");
            var Byte = ToTerm("byte");
            var Case = ToTerm("case");
            var Char = ToTerm("char");
            var Class = ToTerm("class");
            var Const = ToTerm("const");
            var Continue = ToTerm("continue");
            var Decimal = ToTerm("decimal");
            var Default = ToTerm("default");
            var Double = ToTerm("double");
            var Enum = ToTerm("enum");
            var False = ToTerm("false");
            var Float = ToTerm("float");
            var For = ToTerm("for");
            var Instanceof = ToTerm("instanceof");
            var Int = ToTerm("int");
            var Long = ToTerm("long");
            var Namespace = ToTerm("namespace");
            var New = ToTerm("new");
            var Object = ToTerm("object");
            var Override = ToTerm("override");
            var Protected = ToTerm("protected");
            var Public = ToTerm("public");
            var Ref = ToTerm("ref");
            var Return = ToTerm("return");
            var Sealed = ToTerm("sealed");
            var SByte = ToTerm("sbyte");
            var Short = ToTerm("short");
            var Static = ToTerm("static");
            var String = ToTerm("string");
            var Switch = ToTerm("switch");
            var This = ToTerm("this");
            var True = ToTerm("true");
            var UInt = ToTerm("uint");
            var ULong = ToTerm("ulong");
            var UShort = ToTerm("ushort");
            var Using = ToTerm("using");
            var Var = ToTerm("var");
            var Virtual = ToTerm("virtual");
            var Void = ToTerm("void");
            var Volatile = ToTerm("volatile");
            // Separators
            var Lparen = ToTerm("(");
            var Rparen = ToTerm(")");
            var Lbrace = ToTerm("{");
            var Rbrace = ToTerm("}");
            var LBracket = ToTerm("[");
            var RBracket = ToTerm("]");
            var Semicolon = ToTerm(";");
            var Comma = ToTerm(",");
            var Dot = ToTerm(".");
            var VarArgs = ToTerm("...");
            var Atsign = ToTerm("@");
            // Operators
            var Assign = ToTerm("=");
            var Great = ToTerm(">");
            var Less = ToTerm("<");
            var Not = ToTerm("!");
            var WaveDash = ToTerm("~");
            var Question = ToTerm("?");
            var Colon = ToTerm(":");
            var Arrow = ToTerm("=>");
            var Equal = ToTerm("==");
            var GreatEq = ToTerm(">=");
            var LessEq = ToTerm("<=");
            var NotEq = ToTerm("!=");
            var And = ToTerm("&&");
            var Or = ToTerm("||");
            var Increment = ToTerm("++");
            var Decrement = ToTerm("--");
            var Plus = ToTerm("+");
            var Minus = ToTerm("-");
            var Multi = ToTerm("*");
            var Division = ToTerm("/");
            var BitAnd = ToTerm("&");
            var BitOr = ToTerm("|");
            var BitXor = ToTerm("^");
            var Mod = ToTerm("%");
            var UnsignedLshift = ToTerm("<<");
            var SignedRshift = ToTerm(">>");
            var UnsignedRshift = ToTerm(">>>");
            var PlusEq = ToTerm("+=");
            var MinusEq = ToTerm("-=");
            var MultiEq = ToTerm("*=");
            var DivisionEq = ToTerm("/=");
            var BitAndEq = ToTerm("&=");
            var BitOrEq = ToTerm("|=");
            var BitXorEq = ToTerm("^=");
            var ModEq = ToTerm("%=");
            var UnsignedLshiftEq = ToTerm("<<=");
            var SignedRshiftEq = ToTerm(">>=");
            var UnsignedRshiftEq = ToTerm(">>>=");
            #endregion

            #region operators,||punctuation and delimiters
            RegisterOperators(1, "||");
            RegisterOperators(2, "&&");
            RegisterOperators(3, "|");
            RegisterOperators(4, "^");
            RegisterOperators(5, "&");
            RegisterOperators(6, "==", "!=");
            RegisterOperators(7, "<", ">", "<=", ">=", "is", "as");
            RegisterOperators(8, "<<", ">>");
            RegisterOperators(9, "+", "-");
            RegisterOperators(10, "*", "/", "%");
            #endregion
            // NonTerminals
            #region Types
            var Type = new NonTerminal("Type");
            var EmbeddedType = new NonTerminal("EmbeddedType");
            var UserDefinedType = new NonTerminal("UserDefinedType");
            var NumericType = new NonTerminal("NumericType");
            var IntegralType = new NonTerminal("IntegralType");
            var FloatingPointType = new NonTerminal("FloatingPointType");
            var DecimalType = new NonTerminal("DecimalType");
            var BoolType = new NonTerminal("BoolType");
            var ClassType = new NonTerminal("ClassType");
            var EnumType = new NonTerminal("EnumType");
            var FunctionType = new NonTerminal("FunctionType");
            var EmbeddedRefType = new NonTerminal("EmbeddedRefType");
            var TypeArgumentList = new NonTerminal("TypeArgumentList");
            var TypeArguments = new NonTerminal("TypeArguments");
            #endregion

            #region Namespaces
            var CompilationUnit = new NonTerminal("CompilationUnit ");
            var UsingDirectivesOpt = new NonTerminal("UsingDirectivesOpt");
            var UsingDirectives = new NonTerminal("UsingDirectives");
            var UsingDirective = new NonTerminal("UsingDirective");
            var UsingAliasDirective = new NonTerminal("UsingAliasDirective");
            var UsingNamespaceDirective = new NonTerminal("UsingNamespaceDirective");
            var UsingStaticDirective = new NonTerminal("UsingStaticDirective");
            var NamespaceMemberDeclarationsOpt = new NonTerminal("NamespaceMemberDeclationsOpt");
            var NamespaceMemberDeclarations = new NonTerminal("NamespaceMemberDeclations");
            var NamespaceMemberDeclaration = new NonTerminal("NamespaceMemberDeclation");
            var NamespaceDeclaration = new NonTerminal("NamespaceDeclaration");
            var NamespaceOrTypeName = new NonTerminal("NamespaceOrTypeName");
            var NamespaceBody = new NonTerminal("NamespaceBody");
            var TypeDeclaration = new NonTerminal("TypeDeclaration");

            #endregion

            // Rules
            #region Types
            Type.Rule = EmbeddedType | UserDefinedType;
            EmbeddedType.Rule = NumericType | BoolType | EmbeddedRefType;
            EmbeddedRefType.Rule = String | Object;
            NumericType.Rule = IntegralType | FloatingPointType | DecimalType;
            IntegralType.Rule = Byte | SByte | Short | UShort | Int | UInt | Long | ULong | Char;
            FloatingPointType.Rule = Float | Double;
            DecimalType.Rule = Decimal;
            BoolType.Rule = Bool;
            UserDefinedType.Rule = NamespaceOrTypeName;
            TypeArgumentList.Rule = Less + TypeArguments + Great;
            TypeArguments.Rule = MakeStarRule(TypeArguments, Comma, Type);

            #endregion

            #region Namespaces
            CompilationUnit.Rule = UsingDirectivesOpt + NamespaceMemberDeclarationsOpt;
            UsingDirectivesOpt.Rule = Empty | UsingDirectives;
            UsingDirectives.Rule = MakePlusRule(UsingDirectives, UsingDirective);
            UsingDirective.Rule = UsingAliasDirective | UsingNamespaceDirective | UsingStaticDirective;
            UsingAliasDirective.Rule = Using + Identifier + Assign + NamespaceOrTypeName + Semicolon;
            UsingNamespaceDirective.Rule = Using + NamespaceOrTypeName + Semicolon;
            UsingStaticDirective.Rule = Using + Static + NamespaceOrTypeName + Semicolon;
            NamespaceMemberDeclarationsOpt.Rule = Empty | NamespaceMemberDeclarations;
            NamespaceMemberDeclarations.Rule = MakePlusRule(NamespaceMemberDeclarations, NamespaceMemberDeclaration);
            NamespaceMemberDeclaration.Rule = NamespaceDeclaration /*| TypeDeclaration*/;
            NamespaceDeclaration.Rule = Namespace + NamespaceOrTypeName + NamespaceBody + Semicolon.Q();
            NamespaceOrTypeName.Rule = MakeStarRule(NamespaceOrTypeName, Dot, Identifier);
            NamespaceBody.Rule = Lbrace + UsingDirectivesOpt + NamespaceMemberDeclarationsOpt + Rbrace;
            #endregion

            Root = CompilationUnit;
        }
    }
}
