using System;
using System.Collections.Generic;

namespace CAMOWA.AccessHelpers
{
    [Obsolete("Use the publicized Nuget instead")]
    public static class OWInputHelper
    {
        public static ref HashSet<InputCommand> LastInputs() { return ref HarmonyLib.AccessTools.StaticFieldRefAccess<HashSet<InputCommand>>(typeof(OWInput), "_lastInputs"); }

        public static ref HashSet<InputCommand> ActiveInputs() { return ref HarmonyLib.AccessTools.StaticFieldRefAccess<HashSet<InputCommand>>(typeof(OWInput), "_activeInputs"); }

        public static HashSet<InputCommand> characterInputs;

        public static ref bool UsingTelescope() { return ref HarmonyLib.AccessTools.StaticFieldRefAccess<bool>(typeof(OWInput), "_usingTelescope"); }

        static OWInputHelper()
        {
            characterInputs = HarmonyLib.AccessTools.StaticFieldRefAccess<HashSet<InputCommand>>(typeof(OWInput), "_characterInputs");
        }
    }
}
