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
using Cecilia.Lib.Analyzer;
using Cecilia.Lib.Syntax;
using Sprache;
using Xunit;

namespace Cecilia.Test.AnalyzerTest.GrammarTests
{
    public class LiteralTest
    {
        [Fact(DisplayName = "BooleanTest")]
        public void BooleanTest()
        {
            var ceciliaSrc = "true";
            var parseResult = Grammar.BooleanLiteral.Parse(ceciliaSrc);
            Assert.True(parseResult.Value);
            Assert.Equal(SyntaxKind.BoolType, parseResult.Kind);
            var ceciliaSrc2 = "false";
            var parseResult2 = Grammar.BooleanLiteral.Parse(ceciliaSrc2);
            Assert.False(parseResult2.Value);
            Assert.Equal(SyntaxKind.BoolType, parseResult2.Kind);
        }
    }
}
