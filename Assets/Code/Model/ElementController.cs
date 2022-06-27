using System.Collections.Generic;
using UnityEngine;

namespace Bricks
{
    public class ElementController
    {
        private BuildingElement _prototype;
        private MouseClicker _mouseClicker;

        private HashSet<BuildingElement> _elements;
        

        public ElementController (BuildingElement prefab, MouseClicker mouseClicker)
        {
            _prototype = prefab;
            _mouseClicker = mouseClicker;
            _elements = new HashSet<BuildingElement>();
        }

        

        public void Execute (float detaTime)
        {
            if (_mouseClicker.DoubleClick && Extentions.IsPointOnElement(out var element))
            {
                RemoveElement(element);
            }
            else if (_mouseClicker.LeftClick && IsPlacementAllowed(Extentions.GetMousePos()))
            {
                CreateElement(Extentions.GetMousePos());
            }
        }

        private void CreateElement(Vector3 position)
        {
            var element = Object.Instantiate(_prototype, position, Quaternion.identity);
            element.SpriteRenderer.color = Random.ColorHSV();
            _elements.Add(element);
        }

        private void RemoveElement(BuildingElement element)
        {
            _elements.Remove(element);
            Object.Destroy(element.gameObject);
        }

        public bool IsPlacementAllowed (Vector3 position)
        {
            var size = _prototype.SpriteRenderer.bounds.max - _prototype.SpriteRenderer.bounds.min;
            var verticalLimit = size.y;
            var horisontalLimit = size.x;

            foreach (var element in _elements)
            {
                var temp = position - element.transform.position;
                if (Mathf.Abs(temp.x) < horisontalLimit && Mathf.Abs(temp.y) < verticalLimit)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
