using UnityEngine;
using HarmonyLib;

namespace CAMOWA
{

    [HarmonyPatch(typeof(SettingsMenu), "Awake")]
    public class SceneLoading
    {
        public delegate void SceneLoad(int sceneId);
        public static event SceneLoad OnSceneLoad;
        
        public static void Prefix()
        {
            OnSceneLoad?.Invoke(Application.loadedLevel);
        }
    }
}
