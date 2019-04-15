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
using Cecilia.Lib.Syntax;
using Sprache;
using System.Collections.Generic;
using System.Linq;

namespace Cecilia.Lib.Analyzer
{
    public class Grammar
    {
        /// <summary>
        /// Identifier: Letter LetterOrDigit*;
        /// </summary>
        public static readonly Parser<string> Identifier =
            from first in Parse.Letter.Once()
            from rest in Parse.LetterOrDigit.Many()
            select new string(first.Concat(rest).ToArray());

        /// <summary>
        /// qualified_identifier: (Identifier) (Dot Identifier)*;
        /// </summary>
        public static readonly Parser<IEnumerable<string>> QualifiedIdentifier =
            Identifier.DelimitedBy(Parse.Char('.').Token())
            .Named("QualifiedIdentifier");

        /// <summary>
        /// using_directive: UsingKeyword qualified_identifier;
        /// </summary>
        public static readonly Parser<UsingDirectiveSyntax> UsingDirective =
            from usingKeyword in Parse.IgnoreCase(CeciliaKeywords.Using).Token()
            from usingNamespace in QualifiedIdentifier.Select(id => id)
            from colon in Parse.Char(';').Optional()
            select new UsingDirectiveSyntax(usingNamespace.ToList());

        /// <summary>
        /// all_member_modifier:
        /// PublicKeyword
        /// | PrivateKeyword
        /// | InternalKeyword;
        /// </summary>
        public static readonly Parser<SyntaxKind> AllMemberModifier =
            Parse.String(CeciliaKeywords.Public).Return(SyntaxKind.Public)
            .Or(Parse.String(CeciliaKeywords.Private).Return(SyntaxKind.Private))
            .Or(Parse.String(CeciliaKeywords.Internal).Return(SyntaxKind.Internal));
    }
}
