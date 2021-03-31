using TMPro;
using UnityEngine;

namespace SquareDino.Popups
{
    [AddComponentMenu("SquareDino/Popups/TextCanvasPopup")]
    public class TextPopupPresenterCanvasSpace : CanvasPopupPresenter
    {
        [SerializeField] private TMP_FontAsset font;

        [Header("DoTweenSettings")] [SerializeField]
        private DoTweenPopupSettings _doTweenPopupSettings;

        private Transform spawnParent;
        private TextPopupElementCanvasSpace _emojiPopupElementPrefab;

        protected override void TryInit()
        {
            if (initizlized) return;

            if (spawnParent == null)
            {
                spawnParent = new GameObject("[POOL] Text Parent").transform;
                spawnParent.SetParent(canvas.transform, false);
                spawnParent.SetAsLastSibling();
            }

            _emojiPopupElementPrefab = new GameObject("Text Popup Element").AddComponent<TextPopupElementCanvasSpace>();
            _emojiPopupElementPrefab.gameObject.AddComponent<RectTransform>();
            _emojiPopupElementPrefab.gameObject.AddComponent<CanvasRenderer>();
            var text = _emojiPopupElementPrefab.gameObject.AddComponent<TextMeshProUGUI>();
            text.alignment = TextAlignmentOptions.Center;
            text.alignment = TextAlignmentOptions.Midline;
            _emojiPopupElementPrefab.PreInit(text, font);
            _emojiPopupElementPrefab.gameObject.SetActive(false);
            _emojiPopupElementPrefab.gameObject.hideFlags = HideFlags.HideInHierarchy;

            popupElementPool.Init(_emojiPopupElementPrefab, poolCountObjects, _doTweenPopupSettings, spawnParent);

            initizlized = true;
        }

        public void SpawnEmojiPopup(string textValue, Vector3 position = default(Vector3),
            bool worldPositionSpace = true, Quaternion rotation = default(Quaternion))
        {
            var popupElement = popupElementPool.GetPoolObject<TextPopupElement>();
            popupElement.SetText(textValue);

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