using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;


namespace ResxClassGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmd = new GenArgs();
            var parser = new CommandLine.Parser(with => with.HelpWriter = Console.Error);

            if (parser.ParseArgumentsStrict(args, cmd, () =>
            {
                Console.ReadLine();
                Environment.FailFast("Failed");
            }))
            {
                if (File.Exists(cmd.ResxFilePath))
                {
                    Run(cmd);
                }
                else
                {
                    Console.WriteLine($"RESX file {cmd.ResxFilePath} does not eixst");
                }
            }

            Console.WriteLine("Press <ENTER> to quit");
            Console.ReadLine();
        }


        static void Run(GenArgs cmd)
        {
            Console.WriteLine("Deleting any old interface & class files");
            File.Delete($"I{cmd.Class}.cs");
            File.Delete($"{cmd.Class}.cs");

            var @class = new StringBuilder();
            var @int = new StringBuilder();

            @int
                .AppendLine("using System;")
                .AppendLine()
                .AppendLine($"namespace {cmd.Namespace}")
                .AppendLine("{")
                .AppendLine($"    public interface I{cmd.Class}")
                .AppendLine("    {");

            @class
                .AppendLine("using System;")
                .AppendLine()
                .AppendLine($"namespace {cmd.Namespace}.Impl")
                .AppendLine("{")
                .AppendLine($"    public class {cmd.Class} : I{cmd.Class}")
                .AppendLine("    {");

            var values = GetValues(cmd.ResxFilePath);
            foreach (var value in values)
            {
                @int
                    .AppendLine("        /// <summary>")
                    .AppendLine($"        /// Localized value equivalent to '{value.Item2}'")
                    .AppendLine("        /// </summary>")
                    .Append($"        string {value.Item1}")
                    .Append(" { get; }")
                    .AppendLine()
                    .AppendLine();

                @class
                    .Append($"        public string {value.Item1}")
                    .Append(" { get; set; }")
                    .AppendLine();
            }
            @int
                .AppendLine("    }")
                .AppendLine("}");

            @class
                .AppendLine("    }")
                .AppendLine("}");

            Console.WriteLine("Writing Interface & Class Files");
            File.WriteAllText($"I{cmd.Class}.cs", @int.ToString());
            File.WriteAllText($"{cmd.Class}.cs", @class.ToString());
            Console.WriteLine("Files Generated Successfully");
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
