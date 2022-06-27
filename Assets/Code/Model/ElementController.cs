using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bricks
{
    public class ElementController
    {
        private BuildingElement _prototype;

        private HashSet<BuildingElement> _elements;
        

        public ElementController (BuildingElement prefab)
        {
            _prototype = prefab;
            _elements = new HashSet<BuildingElement>();
        }

        

        public void Execute (float detaTime)
        {
            if (Input.GetMouseButtonUp(0) && IsPlacementAllowed(Extentions.GetMousePos()))
            {
                CreateElement(Extentions.GetMousePos());
            }
            else if (Input.GetMouseButtonUp(1) && IsPointOnElement(out var element))
            {
                RemoveElement(element);
            }
        }

        private void CreateElement(Vector3 position)
        {
            var element = Object.Instantiate<BuildingElement>(_prototype, position, Quaternion.identity);
            _elements.Add(element);
        }

        private void RemoveElement(BuildingElement element)
        {
            _elements.Remove(element);
            Object.Destroy(element.gameObject);
        }

        public bool IsPointOnElement (out BuildingElement element)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.collider.TryGetComponent<BuildingElement>(out var component))
            {
                //Debug.Log("Target name: " + hit.collider.name);
                element = component;
                return true;
            }
            else
            {
                element = null;
                return false;
            }
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
