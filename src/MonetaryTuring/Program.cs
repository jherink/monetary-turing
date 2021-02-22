using System;

namespace MonetaryTuring
{
    class Program
    {
        static void Main( string[] args )
        {
            var turing = new MonetaryTuring();

            while ( true )
            {
                var c = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if ( c == 'd' )
                {
                    turing.Delete();
                }
                else if ( c == 'e' )
                {
                    break;
                }
                else
                {
                    turing.Update( c );
                }

                Console.WriteLine( turing.Value );
            }
        }
    }
}
