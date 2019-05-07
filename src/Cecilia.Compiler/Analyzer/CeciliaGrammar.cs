using Irony.Parsing;

namespace Cecilia.Compiler.Analyzer
{
    [Language("Cecilia", "0.1", "")]
    public class CeciliaGrammar : Grammar
    {
        public CeciliaGrammar()
        {
            // keywords
            var ConstKeyword = new KeyTerm("const", "const");
            var InternalKeyword = new KeyTerm("internal", "internal");
            var NamespaceKeyword = new KeyTerm("namespace", "namespace");
            var UsingKeyword = new KeyTerm("using", "using");
            var VarKeyword = new KeyTerm("var", "var");

            //symbols
            var Dot = ToTerm(".");
            var Semicolon = ToTerm(";", "Semicolon");
            var SemicolonOpt = new NonTerminal("semicolonOpt");
            SemicolonOpt.Rule = Semicolon.Q();
            var LBrace = ToTerm("{");
            var RBrace = ToTerm("}");

            #region non terminals
            var Identifier = new IdentifierTerminal("identifier");
            var QualifiedIdentifier = new NonTerminal("qualified_identifier");

            // type
            var TypeDeclaration = new NonTerminal("type_declaration");
            var AllMemberModifiers = new NonTerminal("all_member_modifiers");
            var AllMemberModifier = new NonTerminal("all_member_modifier");

            // program and namespace 
            var Program = new NonTerminal("program");
            var UsingDirectives = new NonTerminal("using_directives");
            var UsingDirective = new NonTerminal("using_directive");
            var NamespaceMemberDeclarations = new NonTerminal("namespace_member_declarations");
            var NamespaceMemberDeclaration = new NonTerminal("namespace_member_declaration");
            var NamespaceDeclaration = new NonTerminal("namespace_declaration");
            var NamespaceBody = new NonTerminal("namespace_body");

            // members
            var MemberDeclaration = new NonTerminal("member_declaration");
            var ConstantDeclaration = new NonTerminal("constant_declaration");
            var VariableDeclaration = new NonTerminal("variable_declaration");
            #endregion

            // syntax
            QualifiedIdentifier.Rule =
                MakeStarRule(QualifiedIdentifier, Dot, Identifier);

            // type
            TypeDeclaration.Rule = AllMemberModifiers + MemberDeclaration;
            AllMemberModifiers.Rule = MakePlusRule(AllMemberModifiers, AllMemberModifier);
            AllMemberModifier.Rule = InternalKeyword;

            // program and namespace 
            Program.Rule =
                UsingDirectives
                + NamespaceMemberDeclarations 
                + Eof;
            UsingDirectives.Rule = MakeStarRule(UsingDirectives, UsingDirective);
            UsingDirective.Rule = UsingKeyword + QualifiedIdentifier;
            NamespaceMemberDeclarations.Rule = MakeStarRule(NamespaceMemberDeclarations, NamespaceMemberDeclaration);
            NamespaceMemberDeclaration.Rule =
                NamespaceDeclaration | TypeDeclaration;
            NamespaceDeclaration.Rule = NamespaceKeyword + QualifiedIdentifier + NamespaceBody + SemicolonOpt;
            NamespaceBody.Rule = LBrace + UsingDirectives + NamespaceMemberDeclarations + RBrace;

            // members
            MemberDeclaration.Rule = ConstantDeclaration | VariableDeclaration;
            ConstantDeclaration.Rule = ConstKeyword;
            VariableDeclaration.Rule = VarKeyword;

            Root = Program;
        }
    }
}
