using UnityEngine;

namespace SquareDino.Popups
{
    public class EmojiPopupCanvasSpace : EmojiPopupElement
    {
        public override void SetSprite(Sprite sprite)
        {
            base.SetSprite(sprite);

            _image.sprite = sprite;
        }
    }
}