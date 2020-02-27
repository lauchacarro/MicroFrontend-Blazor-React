using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorCompiler.Services.Interfaces
{
    public interface ICompilerService
    {
        void InitializeMetadataReferences(HttpClient client);
        void WhenReady(Func<Task> action);
        (bool success, Assembly asm) LoadSource(string source);
        string Format(string source);
        string DispatchBlazorCodeCompiledEvent(float time);
    }
}
