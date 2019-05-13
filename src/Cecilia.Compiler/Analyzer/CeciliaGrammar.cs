/* Copyright 2019 masato sueda

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License. */
using Irony.Parsing;

namespace Cecilia.Compiler.Analyzer
{
    [Language("Cecilia", "0.1", "")]
    public class CeciliaGrammar : Grammar
    {
        public CeciliaGrammar()
        {
            #region Lexical rules
            // keywords
            var BoolKeyword = new KeyTerm("bool", "bool");
            var CharKeyword = new KeyTerm("char", "char");
            var StringKeyword = new KeyTerm("string", "string");
            var ObjectKeyword = new KeyTerm("object", "object");
            var ByteKeyword = new KeyTerm("byte", "byte");
            var ShortKeyword = new KeyTerm("short", "short");
            var IntKeyword = new KeyTerm("int", "int");
            var LongKeyword = new KeyTerm("long", "long");
            var UbyteKeyword = new KeyTerm("ubyte", "ubyte");
            var UShortKeyword = new KeyTerm("ushort", "short");
            var UIntKeyword = new KeyTerm("uint", "int");
            var ULongKeyword = new KeyTerm("ulong", "long");
            var HalfKeyword = new KeyTerm("half", "half");
            var FloatKeyword = new KeyTerm("float", "float");
            var DoubleKeyword = new KeyTerm("double", "double");
            var DecimalKeyword = new KeyTerm("decimal", "decimal");
            var NamespaceKeyword = new KeyTerm("namespace", "namespace");
            var PublicKeyword = new KeyTerm("public", "public");
            var PrivateKeyword = new KeyTerm("private", "private");
            var InternalKeyword = new KeyTerm("internal", "internal");
            var UsingKeyword = new KeyTerm("using", "using");
            var VarKeyword = new KeyTerm("var", "var");
            var ConstKeyword = new KeyTerm("const", "const");
            var SwitchKeyword = new KeyTerm("switch", "switch");
            var LoopKeyword = new KeyTerm("loop", "loop");
            var MacroKeyword = new KeyTerm("macro", "macro");
            var TrueKeyword = new KeyTerm("true", "true");
            var FalseKeyword = new KeyTerm("false", "false");
            var DefaultKeyword = new KeyTerm("default", "default");
            var ReturnKeyword = new KeyTerm("return", "return");

            //symbols
            var LParen = ToTerm("(");
            var RParen = ToTerm(")");
            var LBracket = ToTerm("[");
            var RBracket = ToTerm("]");
            var LBrace = ToTerm("{");
            var RBrace = ToTerm("}");
            var Exclamation = ToTerm("!");
            var Dollar = ToTerm("$");
            var Percent = ToTerm("%");
            var Caret = ToTerm("^");
            var Ampersand = ToTerm("&");
            var Asterisk = ToTerm("*");
            var Minus = ToTerm("-");
            var Plus = ToTerm("+");
            var Equals = ToTerm("=");
            var Bar = ToTerm("|");
            var Backslash = ToTerm("\\");
            var Colon = ToTerm(":");
            var SemiColon = ToTerm(";");
            var DoubleQuote = ToTerm("\"");
            var SingleQuote = ToTerm("\'");
            var LessThan = ToTerm("<");
            var GreaterThan = ToTerm(">");
            var Comma = ToTerm(",");
            var Dot = ToTerm(".");
            var Question = ToTerm("?");
            var Hash = ToTerm("#");
            var Slash = ToTerm("/");

            var BarBar = ToTerm("||");
            var AmpAmp = ToTerm("&&");
            var MinusMinus = ToTerm("--");
            var PlusPlus = ToTerm("++");
            var QuestionQuestion = ToTerm("??");
            var EqualsEquals = ToTerm("==");
            var ExclamationEquals = ToTerm("!=");
            var Arrow = ToTerm("=>");
            var LessThanEqual = ToTerm("<=");
            var GreaterThanEqual = ToTerm(">=");
            var LessThanLessThan = ToTerm("<<");
            var GreaterThanGreaterThan = ToTerm(">>");
            var PlusEqual = ToTerm("+=");
            var MinusEqual = ToTerm("-=");
            var AsteriskEqual = ToTerm("*=");
            var SlashEqual = ToTerm("/=");
            var BarEqual = ToTerm("|=");
            var CaretEqual = ToTerm("^=");

            var LessThanLessThanEqual = ToTerm("<<=");
            var GreaterThanGreaterThanEqual = ToTerm(">>=");

            var SemicolonOpt = new NonTerminal("semicolonOpt");
            SemicolonOpt.Rule = SemiColon.Q();

            var Identifier = TerminalFactory.CreateCSharpIdentifier("identifier");
            var NumberLiteral = TerminalFactory.CreateCSharpNumber("NumberLiteral");
            var StringLiteral = TerminalFactory.CreateCSharpString("string_literal");

            var SingleLineComment = new CommentTerminal("SingleLineComment", "//", "\r", "\n");
            NonGrammarTerminals.Add(SingleLineComment);
            #endregion

            #region non terminals
            // program and namespace 
            var Program = new NonTerminal("program");
            var UsingDirectives = new NonTerminal("using_directives");
            var UsingDirective = new NonTerminal("using_directive");
            var QualifiedIdentifier = new NonTerminal("qualified_identifier");
            var NamespaceMemberDeclarations = new NonTerminal("namespace_member_declarations");
            var NamespaceMemberDeclaration = new NonTerminal("namespace_member_declaration");
            var NamespaceDeclaration = new NonTerminal("namespace_declaration");
            var NamespaceDeclarations = new NonTerminal("namespace_declarations");

            // member declaration
            var TypeDeclaration = new NonTerminal("type_declaration");
            var AllMemberModifiers = new NonTerminal("all_member_modifiers");
            var AllMemberModifier = new NonTerminal("all_member_modifier");
            var MemberDeclaration = new NonTerminal("member_declaration");
            var ConstantDeclaration = new NonTerminal("constant_declaration");
            var VariableDeclaration = new NonTerminal("variable_declaration");
            var MacroDeclaration = new NonTerminal("macro_declaration");
            var VariableDeclarators = new NonTerminal("variable_declarators");
            var VariableDeclarator = new NonTerminal("variable_declarator");
            var TypeAnnotation = new NonTerminal("type_annotation");
            var TypeAnnotationOpt = new NonTerminal("type_annotationOpt");

            // types
            var Type = new NonTerminal("type");
            var EmbeddedType = new NonTerminal("embedded_type");
            var NumberType = new NonTerminal("number_type");
            var IntegralNumberType = new NonTerminal("integral_number_type");
            var FloatingNumberType = new NonTerminal("floating_number_type");
            var OtherBaseType = new NonTerminal("other_base_type");
            var SpecialSupportType = new NonTerminal("special_support_type");
            var UserDefinitionType = new NonTerminal("user_definition_type");

            // expression
            var Expression = new NonTerminal("expression");
            var ConditionalExpression = new NonTerminal("conditional_expression");
            var ConditionalExpressionBody = new NonTerminal("conditional_expression_body");
            var BinOpExpression = new NonTerminal("bin_op_expression");
            var BinOp = new NonTerminal("bin_op");
            var AssignmentExpression = new NonTerminal("assignment_expression");
            var UnaryExpression = new NonTerminal("unary_expression");
            var UnaryOperator = new NonTerminal("unary_operator");
            var PrimaryExpression = new NonTerminal("primary_expression");
            var AssignmentOperator = new NonTerminal("assignment_operator");

            // loop expression
            var LoopExpression = new NonTerminal("loop_expression");
            var LoopCondition = new NonTerminal("loop_condition");

            // return expression
            var ReturnExpression = new NonTerminal("return_expression");

            // switch expression
            var SwitchExpression = new NonTerminal("switch_expression");
            var SwitchSection = new NonTerminal("switch_section");
            var SwitchLabel = new NonTerminal("switch_label");

            // function expression
            var FunctionExpression = new NonTerminal("function_expression");
            var FunctionSignature = new NonTerminal("function_signature");
            var FunctionParameterList = new NonTerminal("function_parameter_list");
            var FunctionParameter = new NonTerminal("function_parameter");
            var FunctionBody = new NonTerminal("function_body");
            var Block = new NonTerminal("block");

            var ExpressonList = new NonTerminal("expression_list");
            var ExpressionListOpt = new NonTerminal("expression_listOpt");

            // member access
            var IndexBracket = new NonTerminal("index_bracket");
            var IndexBracketOpt = new NonTerminal("index_bracketOpt");
            IndexBracketOpt.Rule = MakeStarRule(IndexBracketOpt, IndexBracket);
            var MemberAccess = new NonTerminal("member_access");
            var MemberAccessSegmentsOpt = new NonTerminal("member_access_segmentsOpt");
            var MemberAccessSegment = new NonTerminal("member_access_segment");

            // literal
            var Literal = new NonTerminal("literal");
            var BooleanLiteral = new NonTerminal("boolean_literal");

            #endregion

            #region operators punctuation delimiter
            RegisterOperators(1, BarBar);
            RegisterOperators(2, AmpAmp);
            RegisterOperators(3, Bar);
            RegisterOperators(4, Caret);
            RegisterOperators(5, Ampersand);
            RegisterOperators(6, EqualsEquals, ExclamationEquals);
            RegisterOperators(7, GreaterThan, LessThan, GreaterThanEqual, LessThanEqual);
            RegisterOperators(8, GreaterThanGreaterThan, LessThanLessThan);
            RegisterOperators(9, Plus, Minus);
            RegisterOperators(10, Asterisk, Slash, Percent);
            RegisterOperators(-1, QuestionQuestion);
            RegisterOperators(-2, Question);
            RegisterOperators(-3, Equals, PlusEqual, MinusEqual, AsteriskEqual, SlashEqual, BarEqual, CaretEqual, GreaterThanGreaterThanEqual, LessThanLessThanEqual);

            MarkPunctuation(";", ",", "(", ")", "{", "}", "[", "]", ":");
            MarkTransient(NamespaceMemberDeclaration, MemberDeclaration, Literal, BinOp, PrimaryExpression);

            AddTermsReportGroup("assignment",
                Equals,
                PlusEqual, MinusEqual,
                AsteriskEqual, SlashEqual,
                SlashEqual, BarEqual, CaretEqual,
                GreaterThanGreaterThanEqual, LessThanLessThanEqual);
            AddTermsReportGroup("unary operator", Plus, Minus, Exclamation);
            AddToNoReportGroup(Comma, SemiColon);
            AddToNoReportGroup(VarKeyword, ConstKeyword, PlusPlus, MinusMinus, LBrace, RBrace);
            #endregion

            #region Syntax rules
            // program and namespace 
            Program.Rule =
                UsingDirectives
                + NamespaceDeclarations;
            UsingDirectives.Rule = MakeStarRule(UsingDirectives, null, UsingDirective);
            UsingDirective.Rule = UsingKeyword + QualifiedIdentifier + SemicolonOpt;
            QualifiedIdentifier.Rule =
                MakeStarRule(QualifiedIdentifier, Dot, Identifier);
            NamespaceDeclaration.Rule =
                NamespaceKeyword + QualifiedIdentifier + Block + SemicolonOpt;
            NamespaceDeclarations.Rule =
                MakeStarRule(NamespaceDeclarations, null, NamespaceDeclaration);
            NamespaceMemberDeclarations.Rule =
                MakeStarRule(NamespaceMemberDeclarations, NamespaceMemberDeclaration);
            NamespaceMemberDeclaration.Rule =
                NamespaceDeclaration | TypeDeclaration;
            Block.Rule = LBrace + UsingDirectives + NamespaceMemberDeclarations + RBrace;

            // member declaration
            TypeDeclaration.Rule = AllMemberModifiers + MemberDeclaration;
            AllMemberModifiers.Rule =
                MakeStarRule(AllMemberModifiers, AllMemberModifier);
            AllMemberModifier.Rule =
                PublicKeyword | PrivateKeyword | InternalKeyword;

            MemberDeclaration.Rule = ConstantDeclaration | VariableDeclaration | MacroDeclaration;
            ConstantDeclaration.Rule = ConstKeyword + VariableDeclarators;
            VariableDeclaration.Rule = VarKeyword + VariableDeclarators;
            MacroDeclaration.Rule = MacroKeyword + VariableDeclarators;
            VariableDeclarators.Rule = MakePlusRule(VariableDeclarators, Comma, VariableDeclarator);

            VariableDeclarator.Rule = Identifier + TypeAnnotationOpt + Equals + Expression + SemicolonOpt;
            TypeAnnotation.Rule = Colon + Type;
            TypeAnnotationOpt.Rule = TypeAnnotation.Q();

            // types
            Type.Rule = EmbeddedType | UserDefinitionType;
            EmbeddedType.Rule = NumberType | OtherBaseType | SpecialSupportType;
            NumberType.Rule =
                IntegralNumberType
                | FloatingNumberType
                | DecimalKeyword;
            IntegralNumberType.Rule =
                ByteKeyword
                | UbyteKeyword
                | ShortKeyword
                | UShortKeyword
                | IntKeyword
                | UIntKeyword
                | LongKeyword
                | ULongKeyword;
            FloatingNumberType.Rule =
                HalfKeyword | FloatKeyword | DoubleKeyword;
            OtherBaseType.Rule =
                BoolKeyword | CharKeyword;
            SpecialSupportType.Rule =
                StringKeyword | ObjectKeyword;
            UserDefinitionType.Rule = QualifiedIdentifier;

            #region expressions
            Expression.Rule =
                FunctionExpression
                | BinOpExpression
                | PrimaryExpression
                /*| AssignmentExpression
                | SwitchExpression
                | LoopExpression
                | ReturnExpression*/
                | ConditionalExpression;

            ConditionalExpression.Rule =
                Expression + ConditionalExpressionBody;
            ConditionalExpressionBody.Rule =
                PreferShiftHere() + Question + Expression + Colon + Expression;

            // bin op expression
            BinOpExpression.Rule =
                Expression + BinOp + Expression;
            BinOp.Rule =
                BarBar
                | AmpAmp
                | Bar
                | Caret
                | Ampersand
                | EqualsEquals
                | ExclamationEquals
                | GreaterThan
                | LessThan
                | GreaterThanEqual
                | LessThanEqual
                | GreaterThanGreaterThan
                | Plus
                | Minus
                | Asterisk
                | Slash
                | Percent
                | Equals
                | PlusEqual
                | MinusEqual
                | AsteriskEqual
                | SlashEqual
                | BarEqual
                | CaretEqual
                | GreaterThanGreaterThanEqual
                | LessThanLessThanEqual
                | QuestionQuestion;

            // primary expresson
            PrimaryExpression.Rule =
                Literal
                | UnaryExpression
                | MemberAccess;

            // literal
            Literal.Rule = NumberLiteral | StringLiteral | TrueKeyword | FalseKeyword;

            UnaryExpression.Rule =
               UnaryOperator + PrimaryExpression;
            UnaryOperator.Rule =
                Plus
                | Minus
                | Exclamation
                | Asterisk;

            MemberAccess.Rule = Identifier + MemberAccessSegmentsOpt;
            MemberAccessSegmentsOpt.Rule = MakeStarRule(MemberAccessSegmentsOpt, MemberAccessSegment);
            MemberAccessSegment.Rule =
                Dot + Identifier;

            // function expression
            FunctionExpression.Rule =
                FunctionSignature + Arrow + FunctionBody;
            FunctionSignature.Rule =
                LParen + FunctionParameterList + RParen
                | Identifier;
            FunctionParameterList.Rule =
                MakeStarRule(FunctionParameterList, Comma, FunctionParameter);
            FunctionParameter.Rule =
                Identifier + TypeAnnotationOpt;
            FunctionBody.Rule =
                Expression | Block;
            ExpressionListOpt.Rule = ExpressonList.Q();
            ExpressonList.Rule = MakePlusRule(ExpressonList, Expression);
            #endregion

            #endregion

            Root = Program;
        }
    }
}
