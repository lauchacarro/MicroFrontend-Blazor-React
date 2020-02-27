using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using BlazorCompiler.Services.Interfaces;

namespace BlazorCompiler.Pages
{
    public class CompilerComponent : ComponentBase
    {
        public string Output = "";
        const string DefaultCodeCSharp = @"using System;

class Program
{
    public static void Main()
    {
        Console.WriteLine(""Hello World"");
    }
}";
        const string DefaultVisualBasicCode = @"
Imports System

Namespace Rextester
    Public Module Program
        Public Sub Main(args() As string)
            'Your code goes here
            Console.WriteLine(""Hello, world!"")
        End Sub
    End Module
End Namespace
";
        [Inject] private HttpClient Client { get; set; }
        [Inject] private IMonacoService MonacoService { get; set; }
        [Inject] private ICompilerService CompilerService { get; set; }

        protected override Task OnInitializedAsync()
        {
            CompilerService.InitializeMetadataReferences(Client);
            return base.OnInitializedAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                MonacoService.Initialize("container", DefaultCodeCSharp, "csharp");
            }
        }

        public void Run()
        {
            CompilerService.WhenReady(RunInternal);
        }

        async Task RunInternal()
        {
            Output = "";

            Console.WriteLine("Compiling and Running code");
            var sw = Stopwatch.StartNew();

            var currentOut = Console.Out;
            var writer = new StringWriter();
            Console.SetOut(writer);

            Exception exception = null;
            try
            {
                var (success, asm) = CompilerService.LoadSource(MonacoService.GetCode("container"));
                if (success)
                {
                    var entry = asm.EntryPoint;
                    if (entry.Name == "<Main>") // sync wrapper over async Task Main
                    {
                        entry = entry.DeclaringType.GetMethod("Main", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static); // reflect for the async Task Main
                    }
                    var hasArgs = entry.GetParameters().Length > 0;
                    var result = entry.Invoke(null, hasArgs ? new object[] { new string[0] } : null);
                    if (result is Task t)
                    {
                        await t;
                    }
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Output = writer.ToString();
            if (exception != null)
            {
                Output += "\r\n" + exception.ToString();
            }
            Console.SetOut(currentOut);

            sw.Stop();
            Console.WriteLine("Done in " + sw.ElapsedMilliseconds + "ms");
            CompilerService.DispatchBlazorCodeCompiledEvent(sw.ElapsedMilliseconds);
            StateHasChanged();
        }
    }
}
