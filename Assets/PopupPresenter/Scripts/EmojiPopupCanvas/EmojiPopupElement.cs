using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace SquareDino.Popups
{
    public class EmojiPopupElement : PopupElement
    {
        [SerializeField, HideInInspector] protected Image _image;

        public void PreInit(Image image)
        {
            _image = image;
        }

        public virtual void SetSprite(Sprite sprite)
        {

        }

        public override void Spawn()
        {
            base.Spawn();

            transform.localRotation = Quaternion.Euler(0, 0, _doTweenPopupSettings.GetRotateOffset() + 360);
            transform.localScale = Vector3.one * _doTweenPopupSettings.GetScaleFactor().x;
            StartCoroutine(SpawnLoop());
        }

        private IEnumerator SpawnLoop()
        {
            TweenerCore<Quaternion, Vector3, QuaternionOptions> rotateLoop = null;
            TweenerCore<Vector3, Vector3, VectorOptions> scaleLoop = null;
            var sequance = DOTween.Sequence();

            sequance.Join(transform.DOMove(_doTweenPopupSettings.GetMoveOffset() + transform.position,
                _doTweenPopupSettings.moveDuration).SetEase(_doTweenPopupSettings.moveCurve));

            if (Math.Abs(_doTweenPopupSettings.GetRotateOffset()) > 0.01f)
            {
                rotateLoop = transform.DOLocalRotate(
                        new Vector3(transform.localRotation.x, transform.localRotation.y,
                            -_doTweenPopupSettings.GetRotateOffset()), _doTweenPopupSettings.rotateDuration)
                    .SetEase(_doTweenPopupSettings.rotateCurve).SetLoops(-1, LoopType.Yoyo);
            }

            sequance.Join(_image.DOGradientColor(_doTweenPopupSettings.colorOverLifeTime,
                _doTweenPopupSettings.duration));

            sequance.Join(_image.DOGradientAlpha(_doTweenPopupSettings.colorOverLifeTime,
                _doTweenPopupSettings.duration));

            if (_doTweenPopupSettings.scaleOptions == ScaleOptions.ScaleBetweenTwoValue)
            {
                scaleLoop = transform.DOScale(
                        _doTweenPopupSettings.scaleOptions == ScaleOptions.Constant
                            ? _doTweenPopupSettings.GetScaleFactor().x
                            : _doTweenPopupSettings.GetScaleFactor().y, _doTweenPopupSettings.scaleDuration)
                    .SetEase(_doTweenPopupSettings.scaleCurve)
                    .SetLoops(-1, LoopType.Yoyo);
            }

            yield return new WaitForSeconds(_doTweenPopupSettings.duration);
            rotateLoop?.Kill();
            scaleLoop?.Kill();
            sequance.Kill();
            transform.rotation = Quaternion.identity;
            ReturnToPool();
        }
    }
}