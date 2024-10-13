using System.Linq;
using System.Reflection;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIPresets.Labels;
using Timberborn.SingletonSystem;
using Timberborn.UILayoutSystem;
using UnityEngine.UIElements;
using UnityEngine;

namespace Hytone.Timberborn.Mods.HeightShower
{
    public class HeightShowerPanel : ILoadableSingleton
    {
        private readonly UILayout _gameLayout;
        public Label HeightLabel;


        private readonly UIBuilder _builder;
        private VisualElement _root;

        private const int _panelOrder = 8;

        public HeightShowerPanel(
            UILayout gameLayout, 
            UIBuilder uIBuilder)
        {
            _gameLayout = gameLayout;
            _builder = uIBuilder;
        }

        public void Load()
        {
            _root =
                _builder.Create<VisualElementBuilder>()
                        .SetName("HeightShowerContainer")
                        .AddClass("top-right-item")
                        .AddClass("square-large--green")
                        .SetFlexDirection(FlexDirection.Row)
                        .SetFlexWrap(Wrap.Wrap)
                        .SetJustifyContent(Justify.Center)
                        .AddComponent<LabelBuilder>("HeightShowerLabel",builder => 
                            builder.AddClass("text--centered")
                                   .AddClass("text--yellow")
                                   .AddClass("date-panel__text")
                                   .AddClass("game-text--normal"))
                        .BuildAndInitialize();

            HeightLabel = _root.Q<Label>("HeightShowerLabel");

            _gameLayout.AddTopRight(_root, _panelOrder);
        }
    }
}
