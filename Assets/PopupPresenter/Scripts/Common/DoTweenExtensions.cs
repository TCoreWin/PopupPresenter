using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

namespace SquareDino.Popups
{
    public static class DoTweenExtensions
    {
        public static Sequence DOGradientAlpha(this Image target, Gradient gradient, float duration)
        {
            Sequence s = DOTween.Sequence();
            GradientAlphaKey[] alphas = gradient.alphaKeys;
            int len = alphas.Length;
            for (int i = 0; i < len; ++i)
            {
                GradientAlphaKey a = alphas[i];
                if (i == 0 && a.time <= 0)
                {
                    target.color = new Color(target.color.r, target.color.g, target.color.b, a.alpha);
                    continue;
                }

                float colorDuration = i == len - 1
                    ? duration - s.Duration(false) // Verifies that total duration is correct
                    : duration * (i == 0 ? a.time : a.time - alphas[i - 1].time);
                s.Append(target.DOFade(a.alpha, colorDuration).SetEase(Ease.Linear));
            }

            s.SetTarget(target);
            return s;
        }

        public static Sequence DOGradientAlpha(this TextMeshProUGUI target, Gradient gradient, float duration)
        {
            Sequence s = DOTween.Sequence();
            GradientAlphaKey[] alphas = gradient.alphaKeys;
            int len = alphas.Length;
            for (int i = 0; i < len; ++i)
            {
                GradientAlphaKey a = alphas[i];
                if (i == 0 && a.time <= 0)
                {
                    target.color = new Color(target.color.r, target.color.g, target.color.b, a.alpha);
                    continue;
                }

                float colorDuration = i == len - 1
                    ? duration - s.Duration(false) // Verifies that total duration is correct
                    : duration * (i == 0 ? a.time : a.time - alphas[i - 1].time);
                s.Append(target.DOFade(a.alpha, colorDuration).SetEase(Ease.Linear));
            }

            s.SetTarget(target);
            return s;
        }

        public static Sequence DOGradientColor(this TextMeshProUGUI target, Gradient gradient, float duration)
        {
            Sequence s = DOTween.Sequence();
            GradientColorKey[] colors = gradient.colorKeys;
            int len = colors.Length;
            for (int i = 0; i < len; ++i)
            {
                GradientColorKey c = colors[i];
                if (i == 0 && c.time <= 0)
                {
                    target.color = c.color;
                    continue;
                }

                float colorDuration = i == len - 1
                    ? duration - s.Duration(false) // Verifies that total duration is correct
                    : duration * (i == 0 ? c.time : c.time - colors[i - 1].time);
                s.Append(target.DOColor(c.color, colorDuration).SetEase(Ease.Linear));
            }

            s.SetTarget(target);
            return s;
        }
    }
}