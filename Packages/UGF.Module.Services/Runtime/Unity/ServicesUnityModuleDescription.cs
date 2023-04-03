using System;

namespace UGF.Module.Services.Runtime.Unity
{
    public class ServicesUnityModuleDescription : ServicesModuleDescription
    {
        public string EnvironmentName { get { return HasEnvironmentName ? m_environmentName : throw new ArgumentException("Value not specified."); } }
        public bool HasEnvironmentName { get { return !string.IsNullOrEmpty(m_environmentName); } }

        private readonly string m_environmentName;

        public ServicesUnityModuleDescription(Type registerType, bool enableOnInitializeAsync, string environmentName) : base(registerType, enableOnInitializeAsync)
        {
            m_environmentName = environmentName;
        }
    }
}
