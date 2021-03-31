using UnityEngine;

namespace SquareDino.Popups
{
    public abstract class CanvasPopupPresenter : PopupPresenter
    {
        [SerializeField] protected Canvas canvas;

        protected virtual void Awake()
        {
            TryInit();
        }

        protected virtual void TryInit() {}
    }
}