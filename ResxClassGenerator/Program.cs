using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;


namespace ResxClassGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //var cmd = new GenArgs
            //{
            //    ResxFilePath = "Strings.resx",
            //    Class = "Strings",
            //    Namespace = "Test"
            //};
            var cmd = new GenArgs();
            if (!CommandLine.Parser.Default.ParseArguments(args, cmd))
                return;

            if (!File.Exists(cmd.ResxFilePath))
            {
                Console.WriteLine($"RESX file {cmd.ResxFilePath} does not eixst");
                return;
            }

            Console.WriteLine("Deleting any old interface & class files");
            File.Delete($"I{cmd.Class}.cs");
            File.Delete($"{cmd.Class}.cs");



            Console.WriteLine("Writing Interface & Class Files");
            File.WriteAllText($"I{cmd.Class}.cs", @int.ToString());
            File.WriteAllText($"{cmd.Class}.cs", @class.ToString());
            Console.WriteLine("Done - Press <ENTER> to quit");
            Console.ReadLine();
        }


        static IEnumerable<Tuple<string, string>> GetValues(string resxFilePath)
        {
            var values = new List<Tuple<string, string>>();
            using (var resx = new ResXResourceSet(resxFilePath))
            {
                var en = resx.GetEnumerator();
                while (en.MoveNext())
                {
                    var name = (string) en.Key;
                    var value = resx
                        .GetString(name)
                        .Replace(Environment.NewLine, " ")
                        .Replace("&", "-");
                    values.Add(new Tuple<string, string>(name, value));
                }
            }
            return values.OrderBy(x => x.Item1).ToList();
        }
    }
}
