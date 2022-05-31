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
            string pathToConfig = Path.Combine(Info.Location, OWMMConfigFile);
            if(!File.Exists(pathToConfig))
            {
                IsModEnabled = true;
                return  new OWMMConfig();
            }
            string jsonConfigFile = File.ReadAllText(pathToConfig);
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
        public bool enabled = true;
    }
}
