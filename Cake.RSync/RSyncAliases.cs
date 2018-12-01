using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.RSync
{
    [CakeNamespaceImport("Cake.RSync")]
    [CakeAliasCategory("RSync")]
    public static class RSyncAliases
    {
        [CakeMethodAlias]
        public static void RSync(this ICakeContext ctx, string source, string destination)
        {
            ctx.RSync(source, destination, new RSyncSettings());
        }

        [CakeMethodAlias]
        public static void RSync(this ICakeContext ctx, string source, string destination, RSyncSettings settings)
        {
            if (ctx.Environment.Platform.Family != PlatformFamily.Linux)
                throw new NotSupportedException("AzCopy is only supported on linux");
            RSyncRunner runner = new RSyncRunner(ctx);
            runner.RunTool(source, destination, settings);
        }
    }
}