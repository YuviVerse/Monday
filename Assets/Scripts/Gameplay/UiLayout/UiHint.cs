using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UiLayout
{
    public class UiHint : IUiElement
    {
        private Image _image;
        private Sprite _sprite;

        public UiHint(Image image)
        {
            _image = image;
        }

        public void UpdateUiComponent()
        {
            _image.sprite = _sprite;
        }

        public void SetImage(Sprite sprite)
        {
            _sprite = sprite;
            UpdateUiComponent();
        }
    }
}
