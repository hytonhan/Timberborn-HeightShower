using System;
using System.Collections.Generic;
//using System.Reflection.Emit;
using System.Text;
using TimberApi.UiBuilderSystem;
using Timberborn.CoreUI;
using Timberborn.GameUI;
using Timberborn.InputSystem;
using Timberborn.Localization;
using Timberborn.SingletonSystem;
using Timberborn.WaterSystemRendering;
using UnityEngine.UIElements;

namespace Hytone.Timberborn.Mods.HeightShower
{
    public class HeightShowerPanel : ILoadableSingleton
    {
        private readonly VisualElementLoader _visualElementLoader;
        private readonly GameLayout _gameLayout;
        private readonly ITooltipRegistrar _tooltipRegistrar;
        private Label _label;


        private readonly UIBuilder _builder;
        private VisualElement _root;
        private readonly ILoc _loc;

        public HeightShowerPanel(
            VisualElementLoader visualElementLoader, 
            GameLayout gameLayout, 
            ITooltipRegistrar tooltipRegistrar)
        {
            _visualElementLoader = visualElementLoader;
            _gameLayout = gameLayout;
            _tooltipRegistrar = tooltipRegistrar;
        }

        public void Load()
        {
            _root =
                _builder.CreateComponentBuilder()
                        .CreateVisualElement()
                        .AddPreset(factory => factory.Labels()
                                                     .GameTextBig(locKey: "HeightShower.Panel.Height",
                                                                  name: "HeightShowerLabel"))
                        .BuildAndInitialize();

            _label = _root.Q<Label>("HeightShowerLabel");
        }
    }
}
