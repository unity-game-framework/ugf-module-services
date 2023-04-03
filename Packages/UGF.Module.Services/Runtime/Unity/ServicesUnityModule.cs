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

        protected override async Task OnEnableAsync()
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

            await UnityServices.InitializeAsync(options);
        }

        protected override Task OnDisableAsync()
        {
            return Task.CompletedTask;
        }
    }
}
