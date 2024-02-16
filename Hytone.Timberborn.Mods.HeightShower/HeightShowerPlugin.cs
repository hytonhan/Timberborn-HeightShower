using HarmonyLib;
using TimberApi.ConsoleSystem;
using TimberApi.DependencyContainerSystem;
using TimberApi.ModSystem;
using Timberborn.CursorToolSystem;
using Timberborn.Localization;
using UnityEngine;

namespace Hytone.Timberborn.Mods.HeightShower
{
    [HarmonyPatch]
    public class HeightShowerPlugin : IModEntrypoint
    {
        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            var harmony = new Harmony("hytone.plugins.heightshower");
            harmony.PatchAll();

            consoleWriter.LogInfo("HeightShowerPlugin is loaded.");
        }
    }

    [HarmonyPatch(typeof(CursorDebugger), "ProcessInput")]
    public class CursorDebuggerPatch
    {
        private static ILoc _loc;
        private static HeightShowerPanel _heightPanel;

        public static void Prefix(CursorCoordinatesPicker ____cursorCoordinatesPicker)
        {
            CursorCoordinates? cursorCoordinates = ____cursorCoordinatesPicker.CursorCoordinates();
            if (_heightPanel == null)
            {
                _heightPanel = DependencyContainer.GetInstance<HeightShowerPanel>();
            }
            if (_loc == null)
            {
                _loc = DependencyContainer.GetInstance<ILoc>();
            }
            CursorCoordinates valueOrDefault = cursorCoordinates.GetValueOrDefault();
            _heightPanel.HeightLabel.text = $"{_loc.T("HeightShower.Panel.Height")} {valueOrDefault.TileCoordinates.z}"; // is +1 here needed?
        }
    }
}
