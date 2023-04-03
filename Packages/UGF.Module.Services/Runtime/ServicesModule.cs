using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Initialize.Runtime;
using UGF.Module.Services.Runtime.Unity;

namespace UGF.Module.Services.Runtime
{
    public abstract class ServicesModule<TDescription> : ApplicationModuleAsync<TDescription>, IServicesModule where TDescription : ServicesUnityModuleDescription
    {
        public bool IsEnabled { get { return m_state; } }

        private InitializeState m_state;

        protected ServicesModule(TDescription description, IApplication application) : base(description, application)
        {
        }

        protected override async Task OnInitializeAsync()
        {
            await base.OnInitializeAsync();

            if (Description.EnableOnInitializeAsync)
            {
                await EnableAsync();
            }
        }

        public Task EnableAsync()
        {
            m_state = m_state.Initialize();

            return OnEnableAsync();
        }

        public Task DisableAsync()
        {
            m_state = m_state.Uninitialize();

            return OnDisableAsync();
        }

        protected abstract Task OnEnableAsync();
        protected abstract Task OnDisableAsync();
    }
}
