using BepInEx;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace CAMOWA
{
    public abstract class EnableMod : BaseUnityPlugin
    {
        public bool IsModEnabled { get; private set; }
        public OWMMConfig OWMMConfig { get; private set; }

        public const string OWMMConfigFile = "config.json";

        protected OWMMConfig CheckModConfig() 
        {
            string jsonConfigFile = File.ReadAllText(Path.Combine(Info.Location,OWMMConfigFile));
            OWMMConfig config = JsonConvert.DeserializeObject<OWMMConfig>(jsonConfigFile);
            IsModEnabled = config.enabled;
            return config;
        }
        private void Awake() 
        {
            OWMMConfig = CheckModConfig();
            if (!IsModEnabled) 
            {
                enabled = false;
                return;
            }
            ModAwake();
        }
        protected virtual void ModAwake() 
        {
            
        }
    }

    public class OWMMConfig 
    {
        public bool enabled;
    }
}
