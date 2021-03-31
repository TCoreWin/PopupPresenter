using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SquareDino.Popups
{
    public abstract class PopupElement : MonoBehaviour
    {
        protected PopupPool _popupPool;
        protected DoTweenPopupSettings _doTweenPopupSettings;

        public virtual void Spawn()
        {

        }

        protected virtual void ReturnToPool()
        {
            _popupPool.ReturnToPool(this);
        }

        public virtual void Init(PopupPool popupPool, DoTweenPopupSettings doTweenPopupSettings)
        {
            _popupPool = popupPool;
            _doTweenPopupSettings = doTweenPopupSettings;
        }
    }
}