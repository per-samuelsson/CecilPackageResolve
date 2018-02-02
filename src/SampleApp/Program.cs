
using System;
using System.IO;
using System.Linq;
using Mono.Cecil;

namespace SampleApp {

    class Program {

        static void Main(string[] args) {
            var dir = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            var targetPath = Path.Combine(dir, @"..\..\..\..\Target\bin\Debug\NetStandard2.0\Target.dll");

            var module = AssemblyDefinition.ReadAssembly(targetPath).MainModule;

            var @ref = module.GetTypeReferences().First(r => r.Name.Contains("Ninject"));
            @ref.Resolve();
        }
    }
}
