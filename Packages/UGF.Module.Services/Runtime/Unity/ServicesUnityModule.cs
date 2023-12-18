using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Logs.Runtime;
using Unity.Services.Core;
using Unity.Services.Core.Environments;

namespace UGF.Module.Services.Runtime.Unity
{
    public class ServicesUnityModule : ServicesModule<ServicesUnityModuleDescription>
    {
        public event ServicesUnityOptionsHandler ConfiguringOptions;

        public ServicesUnityModule(ServicesUnityModuleDescription description, IApplication application) : base(description, application)
        {
        }

        protected override Task OnEnableAsync()
        {
            var options = new InitializationOptions();

            if (Description.HasEnvironmentName)
            {
                options.SetEnvironmentName(Description.EnvironmentName);

                Log.Debug("Services Unity setup environment", new
                {
                    Description.EnvironmentName
                });
            }

            ConfiguringOptions?.Invoke(options);

            return UnityServices.InitializeAsync(options);
        }

        protected override Task OnDisableAsync()
        {
            return Task.CompletedTask;
        }
    }
}
