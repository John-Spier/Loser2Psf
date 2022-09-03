using System;
using System.IO;
namespace Loser2Meido
{
    class Program
    {
        static void Main(string[] args)
        {
            string infile, outfile;
            string[] strout;
            
            if (args.Length < 1)
            {
                Console.Write("Input PROGRAMS.TXT:");
                infile = Console.ReadLine();
            }
            else
            {
                infile = args[0];
            }

            if (args.Length < 2)
            {
                Console.Write("Output TITLES.TXT:");
                outfile = Console.ReadLine();
            }
            else
            {
                outfile = args[1];
            }
            try
            {
                StreamWriter writefile = new StreamWriter(outfile);
                
                foreach (string strin in File.ReadLines(infile))
                {

                    if (strin.ToUpperInvariant() != "\"END\"" && strin.ToUpperInvariant() != "START")
                    {
                        try
                        {
                            strout = strin.Split('"', StringSplitOptions.RemoveEmptyEntries);
                            strout[1] = strout[1].Substring(6, strout[1].Length - 8); //clean up filename
                            
                            writefile.WriteLine("\"" + strout[0] + "\" \"" + strout[1] + "\" \"801FFFF0\"");

                        }
                        catch (Exception x)
                        {
                            Console.WriteLine("Line '" + strin + "' Exception: " + x.Message);
                        }
                    }
                }
                
                writefile.Flush();
                writefile.BaseStream.WriteByte(0x80);

                writefile.Close();
            }
            catch (Exception fx)
            {
                Console.WriteLine(fx.Message);
            }

        }
    }
}
