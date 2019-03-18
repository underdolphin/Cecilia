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
        [Fact(DisplayName = "NamespaceTest1")]
        public void NamespaceTest1() {
            const string ceciliaSrc = "namespace{}";
            var lexer = new Lexer();
            var result = lexer.GetNextTokenKind(ceciliaSrc);
            Assert.Equal(3, result.Count);
            Assert.Equal((TokenKind.NamespaceKeyword, 9), result[0]);
            Assert.Equal((TokenKind.LBrace, 10), result[1]);
            Assert.Equal((TokenKind.RBrace, 11), result[2]);
        }
    }
}
