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
using Cecilia.Compiler.Analyzer;
using Cecilia.Compiler.Syntax;
using Sprache;
using Xunit;

namespace Cecilia.Test.AnalyzerTest.GrammarTests
{
    public class MemberModifierTest
    {
        [Fact(DisplayName = "PublicModifierTest")]
        public void PublicModifierTest()
        {
            var ceciliaSrc = "public";
            var parseResult = Grammar.AllMemberModifier.Parse(ceciliaSrc);

            Assert.Equal(SyntaxKind.Public, parseResult);
        }

        [Fact(DisplayName = "PrivateModifierTest")]
        public void MemberModifierTest1()
        {
            var ceciliaSrc = "private";
            var parseResult = Grammar.AllMemberModifier.Parse(ceciliaSrc);

            Assert.Equal(SyntaxKind.Private, parseResult);
        }

        [Fact(DisplayName = "InternalModifierTest")]
        public void InternalModifierTest()
        {
            var ceciliaSrc = "internal";
            var parseResult = Grammar.AllMemberModifier.Parse(ceciliaSrc);

            Assert.Equal(SyntaxKind.Internal, parseResult);
        }
    }
}
