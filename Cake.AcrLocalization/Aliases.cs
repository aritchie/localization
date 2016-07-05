using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;


namespace Cake.AcrLocalization
{
    [CakeAliasCategory("AcrLocalize")]
    public static class Aliases
    {

        [CakeMethodAlias]
        public static void Generate(this ICakeContext context, FilePath path)
        {
            
        }
    }
}
