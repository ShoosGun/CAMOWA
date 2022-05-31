using UnityEngine;
using HarmonyLib;

namespace CAMOWA
{
    //TODO Find a place that loads even earlier when a new scene loads
    [HarmonyPatch(typeof(MonoBehaviour), "SettingsMenu")]
    public class SceneLoading
    {
        public delegate void SceneLoad(int sceneId);
        public delegate void SceneTypeLoad(SceneType scene);
        public static event SceneLoad OnSceneLoad;
        public static event SceneTypeLoad OnSceneLoaded;

        public static void Prefix()
        {
            OnSceneLoad?.Invoke(Application.loadedLevel);
            OnSceneLoaded?.Invoke(GetSceneType(Application.loadedLevel));
        }
        public static SceneType GetSceneType(int loadedLevel)
        {
            switch (loadedLevel)
            {
                case 0:
                    return SceneType.MainMenu;
                case 1:
                    return SceneType.SolarSystem;
                default:
                    return SceneType.Other;
            }
        }
    }

    public enum SceneType 
    {
        MainMenu = 0,
        SolarSystem = 1,
        Other = -1
    }
}
