using System;

namespace Employee.Core.Config
{
    [Serializable]
    public class IPluginContext
    {
        public string FullAssemblyPath { get; set; }
        public string AssemblyName { get; set; }
        public int Bits { get; set; }
        public string MainClass { get; set; }
        public string Name { get; set; }
        public string Parameters { get; set; }
    }
}
