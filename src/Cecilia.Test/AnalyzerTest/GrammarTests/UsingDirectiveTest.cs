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
using System.Linq;
using Xunit;

namespace Cecilia.Test.AnalyzerTest.GrammarTests
{
    public class UsingDirectiveTest
    {
        [Fact(DisplayName = "UsingDirectiveTest1")]
        public void UsingDirectiveTest1()
        {
            var ceciliaSrc = "using Test.Test";
            var parseResult = Grammar.UsingDirective.Parse(ceciliaSrc);

            Assert.Equal("Test", parseResult.UsingNamespace[0]);
            Assert.Equal("Test", parseResult.UsingNamespace[1]);
            Assert.Equal(SyntaxKind.UsingDirective, parseResult.Kind);
        }

        [Fact(DisplayName = "UsingDirectiveTest2")]
        public void UsingDirectiveTest2()
        {
            var ceciliaSrc = "using Test.Test;";
            var parseResult = Grammar.UsingDirective.Parse(ceciliaSrc);

            Assert.Equal("Test", parseResult.UsingNamespace[0]);
            Assert.Equal("Test", parseResult.UsingNamespace[1]);
            Assert.Equal(SyntaxKind.UsingDirective, parseResult.Kind);
        }
    }
}
