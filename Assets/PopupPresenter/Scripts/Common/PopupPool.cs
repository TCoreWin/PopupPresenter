using System.Collections.Generic;
using UnityEngine;

namespace SquareDino.Popups
{
    public class PopupPool
    {
        private List<PopupElement> pool = new List<PopupElement>();
        private DoTweenPopupSettings _settings;
        private PopupElement _prefab;
        private Transform _parent;

        public void Init(PopupElement prefab, int count, DoTweenPopupSettings settings, Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;
            _settings = settings;

            FillPool(count);
        }

        public PopupElement GetPoolObject()
        {
            if (pool.Count == 0)
                FillPool(5);

            var randomIndex = Random.Range(0, pool.Count);
            var poolObject = pool[randomIndex];
            poolObject.gameObject.SetActive(true);
            pool.RemoveAt(randomIndex);

            return poolObject;
        }

        public T GetPoolObject<T>() where T : MonoBehaviour
        {
            var poolObject = GetPoolObject();
            return poolObject.GetComponent<T>();
        }

        private void FillPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var newPoolObject = Object.Instantiate(_prefab, _parent);
                newPoolObject.gameObject.SetActive(false);
                newPoolObject.Init(this, _settings);

                pool.Add(newPoolObject);
            }
        }

        public void ReturnToPool(PopupElement element)
        {
            element.gameObject.SetActive(false);
            pool.Add(element);
        }
    }
}