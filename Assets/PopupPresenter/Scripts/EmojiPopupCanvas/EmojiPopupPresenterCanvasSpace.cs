using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace SquareDino.Popups
{
    [AddComponentMenu("SquareDino/Popups/EmojiCanvasPopup")]
    public class EmojiPopupPresenterCanvasSpace : CanvasPopupPresenter
    {

        [SerializeField] private List<Sprite> positiveUniqueSprites;
        [SerializeField] private List<Sprite> negativeUniqueSprites;

        [Header("DoTweenSettings")] [SerializeField]
        private DoTweenPopupSettings _doTweenPopupSettings;

        private Transform spawnParent;
        private EmojiPopupCanvasSpace _emojiPopupElementPrefab;

        protected override void TryInit()
        {
            if (initizlized) return;

            if (spawnParent == null)
            {
                spawnParent = new GameObject("[POOL] Emoji Parent").transform;
                spawnParent.SetParent(canvas.transform, false);
                spawnParent.SetAsLastSibling();
            }

            _emojiPopupElementPrefab = new GameObject("Emoji Popup Element").AddComponent<EmojiPopupCanvasSpace>();
            _emojiPopupElementPrefab.gameObject.AddComponent<RectTransform>();
            _emojiPopupElementPrefab.gameObject.AddComponent<CanvasRenderer>();
            var image = _emojiPopupElementPrefab.gameObject.AddComponent<Image>();
            var mat = new Material(Shader.Find("UI/Default"));
            image.type = Image.Type.Simple;
            image.preserveAspect = true;
            image.raycastTarget = false;
            image.maskable = false;
            image.material = mat;
            _emojiPopupElementPrefab.PreInit(image);
            _emojiPopupElementPrefab.gameObject.SetActive(false);
            _emojiPopupElementPrefab.gameObject.hideFlags = HideFlags.HideInHierarchy;

            popupElementPool.Init(_emojiPopupElementPrefab, poolCountObjects, _doTweenPopupSettings, spawnParent);

            initizlized = true;
        }

        public void SpawnEmojiPopup(EmojiType emojiType, Vector3 position = default(Vector3),
            bool worldPositionSpace = true, Quaternion rotation = default(Quaternion))
        {
            var popupElement = popupElementPool.GetPoolObject<EmojiPopupElement>();

            switch (emojiType)
            {
                case EmojiType.Positive:
                    popupElement.SetSprite(positiveUniqueSprites[Random.Range(0, positiveUniqueSprites.Count)]);
                    break;
                case EmojiType.Negative:
                    popupElement.SetSprite(negativeUniqueSprites[Random.Range(0, negativeUniqueSprites.Count)]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(emojiType), emojiType, null);
            }

            if (worldPositionSpace)
                popupElement.transform.position = position;
            else
                popupElement.transform.localPosition = position;

            popupElement.transform.rotation = rotation;

            popupElement.transform.SetAsLastSibling();
            popupElement.Spawn();
        }
    }
}