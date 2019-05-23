using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E12_Encriptar
{
    class Program
    {
        static void Main(string[] args)
        {     
            /*
            string cadenatest = "Ner lbh thlf univat sha?\nLn erfbyivreba ry rwrepvpvb qry ebgnqbe?\ndhé yrlraqn dhvrera ra fh gnmn?";
            Console.WriteLine(Encriptar(cadenatest));
            */
            bool salir = false;
            string opcion, cadena;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Ingrese la cadena a encriptar:");
                cadena = Console.ReadLine();

                if (cadena.Length > 0)
                {
                    Console.WriteLine("Resultado:");
                    Console.ForegroundColor = ConsoleColor.Cyan;                    
                    Console.WriteLine(Encriptar(cadena));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cadena vacía");
                }

                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("n : nuevo, s : salir");
                    opcion = Console.ReadLine();

                    if (opcion.Equals("s"))
                    {
                        salir = true;
                        break;
                    }
                    else if (!opcion.Equals("n"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se reconoce opción...");
                    }
                    else
                        break;
                } while (true);

            } while (!salir);
        }

        public static string Encriptar(string cadena)
        {
            StringBuilder result = new StringBuilder();
            char[] caracteres = cadena.ToLower().ToCharArray();

            foreach (var c in caracteres)
                result.Append(string.Format("{0}", Convertir(c)));

            return result.ToString();
        }
        public static char Convertir(char v)
        {
            if (ValidarLetra(v))
            {
                int codigo = ObtenerCodigo(v.ToString());                
                codigo = Rotar(codigo);
                return Convert.ToChar(codigo);
            }
            return v;
        }

        public static int ObtenerCodigo(string s)
        {
            return Encoding.ASCII.GetBytes(s)[0];
        }
        public static bool ValidarLetra(char c)
        {
            Regex patron = new Regex("[a-z]");
            return patron.IsMatch(c.ToString());
        }
        public static int Rotar(int numero)
        {            
            numero += 13;                
            if (numero > 122)            
                return 96 + (numero - 122);            
            if (numero < 97)            
                return 123 - (97 - numero);            
            return numero;
        }
    }
}
