using System.Collections.Generic;

namespace Cecilia.Lib.Syntax
{
    public class UsingDirectiveSyntax : SytanxBase
    {
        public override SyntaxKind Kind => SyntaxKind.UsingDirective;

        public List<string> UsingNamespace { get; private set; }

        public UsingDirectiveSyntax(List<string> usingNamespace)
        {
            UsingNamespace = usingNamespace;
        }
    }
}
