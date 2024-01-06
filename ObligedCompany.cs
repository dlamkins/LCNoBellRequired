using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LCObligedCompany {
    [BepInPlugin(MOD_NAMESPACE, MOD_NAME, MOD_VERSION)]
    public class ObligedCompany : BaseUnityPlugin {

        private const string MOD_NAMESPACE = "freesnow.obligedcompany";
        private const string MOD_NAME = "Obliged Company";
        private const string MOD_VERSION = "1.0.0";

        private readonly Harmony _harmony = new Harmony(MOD_NAMESPACE);

        internal static ObligedCompany Instance { get; private set; }

        public ManualLogSource Logger { get; private set; }

        void Awake() {
            if (Instance == null) Instance = this;

            this.Logger = BepInEx.Logging.Logger.CreateLogSource(MOD_NAMESPACE);

            this.Logger.LogInfo($"{MOD_NAME} v{MOD_VERSION} is now running.");

            _harmony.PatchAll();
        }

    }
}
