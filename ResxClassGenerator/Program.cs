using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using S = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;


namespace ResxClassGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmd = new GenArgs();
            if (!CommandLine.Parser.Default.ParseArguments(args, cmd))
                return;


            var @class = new StringBuilder();
            var @int = new StringBuilder();

            @int
                .AppendLine("using System;")
                .AppendLine()
                .AppendLine($"namespace {cmd.InterfaceNamespace}")
                .AppendLine("{")
                .AppendLine($"    public interface {cmd.InterfaceName}")
                .AppendLine("{");

            @class
                .AppendLine("using System;")
                .AppendLine()
                .AppendLine($"namespace {cmd.ImplementationNamespace}")
                .AppendLine("{")
                .AppendLine($"    public class {cmd.ImplementationClassName} : {cmd.InterfaceNamespace}.{cmd.InterfaceName}")
                .AppendLine("    {");

            var content = File.ReadAllText(cmd.ResxFilePath);

            using (var resx = ResXResourceReader.FromFileContents(content))
            {
                resx.UseResXDataNodes = true;
                var en = resx.GetEnumerator();
                while (en.MoveNext())
                {
                    var node = (ResXDataNode)en.Value;

                    @int
                        .AppendLine("/// <summary>")
                        .AppendLine($"/// English value is '")
                        .AppendLine("/// </summary>")
                        .Append($"        public string {node.Name}")
                        .Append(" { get; }")
                        .AppendLine();
                    @class
                        .Append($"        public string {node.Name}")
                        .Append(" { get; set; }")
                        .AppendLine();
                    //        @int = @int.AddMembers(S
                    //            .PropertyDeclaration(stringType, node.Name)
                    //            .AddModifiers(S.Token(SyntaxKind.PublicKeyword))
                    //            .AddAccessorListAccessors(
                    //                S
                    //                    .AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    //                    .WithSemicolonToken(S.Token(SyntaxKind.SemicolonToken))
                    //            )
                    //        );

                    //        @class = @class.AddMembers(S
                    //            .PropertyDeclaration(stringType, node.Name)
                    //            .AddModifiers(S.Token(SyntaxKind.PublicKeyword))
                    //            .AddAccessorListAccessors(
                    //                S
                    //                    .AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    //                    .WithSemicolonToken(S.Token(SyntaxKind.SemicolonToken)),

                    //                S
                    //                    .AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    //                    .WithSemicolonToken(S.Token(SyntaxKind.SemicolonToken)
                    //            )
                    //        ));
                }
            }
            @int
                .AppendLine("    }")
                .AppendLine("}");

            @class
                .AppendLine("    }")
                .AppendLine("}");

            File.WriteAllText(cmd.InterfaceFilePath, @int.ToString());
            File.WriteAllText(cmd.ImplementationFilePath, @class.ToString());
        }
    }
}
