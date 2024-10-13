using Timberborn.CursorToolSystem;
using Timberborn.InputSystem;
using Timberborn.Localization;
using Timberborn.SingletonSystem;
using UnityEngine;

namespace Hytone.Timberborn.Mods.HeightShower
{
    public class CursorTracker : ILoadableSingleton, IInputProcessor
    {
        private CursorCoordinatesPicker _cursorCoordinatesPicker;
        private HeightShowerPanel _heightShowerPanel;
        private ILoc _loc;

        private InputService _inputService;

        public CursorTracker(
            CursorCoordinatesPicker cursorCoordinatesPicker,
            HeightShowerPanel heightShowerPanel,
            ILoc loc,
            InputService inputService)
        {
            _cursorCoordinatesPicker = cursorCoordinatesPicker;
            _heightShowerPanel = heightShowerPanel;    
            _loc = loc;
            _inputService = inputService;
        }

        public void Load()
        {
            _inputService.AddInputProcessor(this);
        }

        public bool ProcessInput()
        {
            var coords = _cursorCoordinatesPicker.CursorCoordinates();
            if (coords != null)
            {
                _heightShowerPanel.HeightLabel.text = $"{_loc.T("HeightShower.Panel.Height")} {coords.Value.TileCoordinates.z}";
            }
            else {
                _heightShowerPanel.HeightLabel.text = $"{_loc.T("HeightShower.Panel.Height")} ";
            }
            return false;
        }
    }
}