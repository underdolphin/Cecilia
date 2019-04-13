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

        [Fact(DisplayName = "UsingDirectivesTest1")]
        public void UsingDirectivesTest1()
        {
            var ceciliaSrc = "using Test.Test using Test2.Test2";
            var parseResult = Grammar.UsingDirectives.Parse(ceciliaSrc);
            var resultList = parseResult.ToList();

            Assert.Equal("Test", resultList[0].UsingNamespace[0]);
            Assert.Equal("Test", resultList[0].UsingNamespace[1]);
            Assert.Equal(SyntaxKind.UsingDirective, resultList[0].Kind);
            Assert.Equal("Test2", resultList[1].UsingNamespace[0]);
            Assert.Equal("Test2", resultList[1].UsingNamespace[1]);
            Assert.Equal(SyntaxKind.UsingDirective, resultList[1].Kind);
        }

        [Fact(DisplayName = "UsingDirectivesTest2")]
        public void UsingDirectivesTest2()
        {
            var ceciliaSrc = "using Test.Test; using Test2.Test2";
            var parseResult = Grammar.UsingDirectives.Parse(ceciliaSrc);
            var resultList = parseResult.ToList();

            Assert.Equal("Test", resultList[0].UsingNamespace[0]);
            Assert.Equal("Test", resultList[0].UsingNamespace[1]);
            Assert.Equal(SyntaxKind.UsingDirective, resultList[0].Kind);
            Assert.Equal("Test2", resultList[1].UsingNamespace[0]);
            Assert.Equal("Test2", resultList[1].UsingNamespace[1]);
            Assert.Equal(SyntaxKind.UsingDirective, resultList[1].Kind);
        }

        [Fact(DisplayName = "UsingDirectivesTest3")]
        public void UsingDirectivesTest3()
        {
            var ceciliaSrc = "using Test.Test using Test2.Test2;";
            var parseResult = Grammar.UsingDirectives.Parse(ceciliaSrc);
            var resultList = parseResult.ToList();

            Assert.Equal("Test", resultList[0].UsingNamespace[0]);
            Assert.Equal("Test", resultList[0].UsingNamespace[1]);
            Assert.Equal(SyntaxKind.UsingDirective, resultList[0].Kind);
            Assert.Equal("Test2", resultList[1].UsingNamespace[0]);
            Assert.Equal("Test2", resultList[1].UsingNamespace[1]);
            Assert.Equal(SyntaxKind.UsingDirective, resultList[1].Kind);
        }

        [Fact(DisplayName = "UsingDirectivesTest4")]
        public void UsingDirectivesTest4()
        {
            var ceciliaSrc = "";
            var parseResult = Grammar.UsingDirectives.Parse(ceciliaSrc);
            var resultList = parseResult.ToList();

            Assert.Empty(resultList);
        }
    }
}
