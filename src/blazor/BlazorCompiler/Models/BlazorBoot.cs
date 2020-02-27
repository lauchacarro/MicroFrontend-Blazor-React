using System.Collections.Generic;

namespace BlazorCompiler.Models
{
    public class BlazorBoot
    {

        public string Main { get; set; }
        public string EntryPoint { get; set; }
        public IEnumerable<string> AssemblyReferences { get; set; }
        public IEnumerable<string> CssReferences { get; set; }
        public IEnumerable<string> JsReferences { get; set; }
        public bool LinkerEnabled { get; set; }

    }
}
