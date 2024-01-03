using BepInEx;
using BepInEx.Logging;
using ShovelFixPatch;

namespace shovelFix
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modName = "Shovel Hotfix";
        private const string modVersion = "1.0.0";
        private const string modGUID = "Rocksnotch.ShovelHotfix";
        internal static Plugin Instance;
        public static ManualLogSource logSrc = BepInEx.Logging.Logger.CreateLogSource("loggingSource");
        private void Awake()
        {
            // Plugin startup logic
            if (Instance == null)
            {
                Instance = this;
            }

            try {
                ShovelFix.Init();
                logSrc.LogInfo("Patched ShovelFix!");
            } catch (System.Exception e) {
                logSrc.LogError($"Error Patching Files: {e.Message}");
            }

            logSrc.LogInfo($"Plugin {modGUID} is loaded!");
        }
    }
}
