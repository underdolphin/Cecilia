using System;

using Cecilia.Driver;

namespace Cecilia
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "";
            new Driver.Driver().Handle(text);
        }
    }
}
