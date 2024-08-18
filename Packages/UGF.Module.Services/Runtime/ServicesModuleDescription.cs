using UGF.Application.Runtime;

namespace UGF.Module.Services.Runtime
{
    public class ServicesModuleDescription : ApplicationModuleDescription
    {
        public bool EnableOnInitializeAsync { get; }

        public ServicesModuleDescription(bool enableOnInitializeAsync)
        {
            EnableOnInitializeAsync = enableOnInitializeAsync;
        }
    }
}
