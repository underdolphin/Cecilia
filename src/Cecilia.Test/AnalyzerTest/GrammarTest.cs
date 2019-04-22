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
using Sprache;
using System.Linq;
using Xunit;

namespace Cecilia.Test.AnalyzerTest
{
    public class GrammarTest
    {
        [Fact(DisplayName = "IdentifierTest")]
        public void IdentifierTest()
        {
            var ceciliaSrc = "abc123";
            Assert.Equal(ceciliaSrc, Grammar.Identifier.Parse(ceciliaSrc));
        }

        [Fact(DisplayName = "QualifiedIdentifierTest")]
        public void QualifiedIdentifierTest()
        {
            var ceciliaSrc = "abc.d12";
            var parseResult = Grammar.QualifiedIdentifier.Parse(ceciliaSrc);
            var parseList = parseResult.ToList();

            Assert.Equal("abc", parseList[0]);
            Assert.Equal("d12", parseList[1]);
        }
    }
}
