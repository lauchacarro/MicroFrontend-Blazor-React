namespace BlazorCompiler.Services.Interfaces
{
    public interface IMonacoService
    {
        void Initialize(string elementId, string initialCode, string language);
        string GetCode(string elementId);
        void SetCode(string elementId, string code);
    }
}
