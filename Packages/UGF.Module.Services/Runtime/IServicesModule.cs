using System.Threading.Tasks;
using UGF.Application.Runtime;

namespace UGF.Module.Services.Runtime
{
    public interface IServicesModule : IApplicationModule
    {
        bool IsEnabled { get; }

        Task EnableAsync();
        Task DisableAsync();
    }
}
