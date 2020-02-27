using Microsoft.JSInterop;

using BlazorCompiler.Services.Interfaces;

namespace BlazorCompiler.Services.Concretes
{
    public class MonacoService : IMonacoService
    {
        private readonly IJSInProcessRuntime Runtime;

        public MonacoService(IJSRuntime runtime)
        {
            Runtime = runtime as IJSInProcessRuntime;
        }

        public void Initialize(string elementId, string initialCode, string language) => Runtime.Invoke<object>("monacoInterop.initialize", elementId, initialCode, language);

        public string GetCode(string elementId) => Runtime.Invoke<string>("monacoInterop.getCode", elementId);

        public void SetCode(string elementId, string code) => Runtime.Invoke<object>("monacoInterop.setCode", elementId, code);
    }
}
