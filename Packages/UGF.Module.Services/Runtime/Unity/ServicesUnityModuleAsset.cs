using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Services.Runtime.Unity
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Services/Services Unity Module", order = 2000)]
    public class ServicesUnityModuleAsset : ApplicationModuleAsset<ServicesUnityModule, ServicesUnityModuleDescription>
    {
        [SerializeField] private bool m_enableOnInitializeAsync;
        [SerializeField] private string m_environmentName;

        public bool EnableOnInitializeAsync { get { return m_enableOnInitializeAsync; } set { m_enableOnInitializeAsync = value; } }
        public string EnvironmentName { get { return m_environmentName; } set { m_environmentName = value; } }

        protected override ServicesUnityModuleDescription OnBuildDescription()
        {
            return new ServicesUnityModuleDescription(m_enableOnInitializeAsync,
                m_environmentName
            );
        }

        protected override ServicesUnityModule OnBuild(ServicesUnityModuleDescription description, IApplication application)
        {
            return new ServicesUnityModule(description, application);
        }
    }
}
