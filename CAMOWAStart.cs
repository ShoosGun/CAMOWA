using HarmonyLib;
using BepInEx;

namespace CAMOWA
{
    [BepInPlugin("locochoco.plugins.CAMOWA","CAMOWA","1.0.1")]
    [BepInProcess("OuterWilds_Alpha_1_2.exe")]
    class CAMOWAStart : BaseUnityPlugin
    {
        public void Awake()
        {
            var harmonyInstance = new Harmony("locochoco.CAMOWA");
            harmonyInstance.PatchAll();
        }
    }
}
