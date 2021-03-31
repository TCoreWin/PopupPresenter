using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquareDino.Popups
{
    public abstract class PopupPresenter : MonoBehaviour
    {
        [SerializeField] [Range(10, 100)] protected int poolCountObjects = 10;
        protected bool initizlized;
        protected PopupPool popupElementPool = new PopupPool();

        public virtual void ReturnToPool(PopupElement popupElement)
        {

        }
    }
}
