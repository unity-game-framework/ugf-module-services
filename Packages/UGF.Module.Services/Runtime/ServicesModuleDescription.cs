using System;
using UGF.Application.Runtime;

namespace UGF.Module.Services.Runtime
{
    public class ServicesModuleDescription : ApplicationModuleDescription
    {
        public bool EnableOnInitializeAsync { get; }

        public ServicesModuleDescription(Type registerType, bool enableOnInitializeAsync)
        {
            RegisterType = registerType ?? throw new ArgumentNullException(nameof(registerType));
            EnableOnInitializeAsync = enableOnInitializeAsync;
        }
    }
}
