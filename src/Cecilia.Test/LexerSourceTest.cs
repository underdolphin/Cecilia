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
using Cecilia.Lib;
using Xunit;

namespace Cecilia.Test
{
    public class LexerSourceTest
    {
        [Fact(DisplayName = "EmptyTest1")]
        public void EmptyTest1()
        {
            const string ceciliaSrc = "";
            var lexer = new Lexer();
            var result = lexer.GetNextTokenKind(ceciliaSrc);
            Assert.Equal((SyntaxKind.EmptyRow, 0, null), result[0]);
        }

        [Fact(DisplayName = "NamespaceTest1")]
        public void NamespaceTest1()
        {
            const string ceciliaSrc = "namespace{}";
            var lexer = new Lexer();
            var result = lexer.GetNextTokenKind(ceciliaSrc);
            Assert.Equal(3, result.Count);
            Assert.Equal((SyntaxKind.NamespaceKeyword, 9, null), result[0]);
            Assert.Equal((SyntaxKind.LBrace, 10, null), result[1]);
            Assert.Equal((SyntaxKind.RBrace, 11, null), result[2]);
        }

        [Fact(DisplayName = "PublicAccessTest1")]
        public void PublicAccessTest1()
        {
            const string ceciliaSrc = "public var publicFunction = () => {}";
            var lexer = new Lexer();
            var result = lexer.GetNextTokenKind(ceciliaSrc);
            Assert.Equal(15, result.Count);
            Assert.Equal(SyntaxKind.PublicKeyword, result[0].kind);
            Assert.Equal(SyntaxKind.Whitespace, result[1].kind);
            Assert.Equal(SyntaxKind.VarKeyword, result[2].kind);
            Assert.Equal(SyntaxKind.Whitespace, result[3].kind);
            Assert.Equal(SyntaxKind.Identifier, result[4].kind);
            Assert.Equal(SyntaxKind.Whitespace, result[5].kind);
            Assert.Equal(SyntaxKind.Equals, result[6].kind);
            Assert.Equal(SyntaxKind.Whitespace, result[7].kind);
            Assert.Equal(SyntaxKind.LParen, result[8].kind);
            Assert.Equal(SyntaxKind.RParen, result[9].kind);
            Assert.Equal(SyntaxKind.Whitespace, result[10].kind);
            Assert.Equal(SyntaxKind.Arrow, result[11].kind);
            Assert.Equal(SyntaxKind.Whitespace, result[12].kind);
            Assert.Equal(SyntaxKind.LBrace, result[13].kind);
            Assert.Equal(SyntaxKind.RBrace, result[14].kind);
        }

        [Fact(DisplayName = "IdentifierTest1")]
        public void IdentifierTest1()
        {
            const string ceciliaSrc = "ID123456789";
            var lexer = new Lexer();
            var result = lexer.GetNextTokenKind(ceciliaSrc);
            Assert.Single(result);
            Assert.Equal((SyntaxKind.Identifier, 11, ceciliaSrc), result[0]);
        }
    }
}
