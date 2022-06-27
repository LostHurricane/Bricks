using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bricks
{
    public class ElementController
    {
        private BuildingElement _prototype;

        private HashSet<BuildingElement> _elements;
        private MouseClicker _mouseClicker;




        public ElementController (BuildingElement prefab)
        {
            _prototype = prefab;
            _elements = new HashSet<BuildingElement>();
            _mouseClicker = new MouseClicker();

        }

        

        public void Execute (float detaTime)
        {
            _mouseClicker.Check();
            if (_mouseClicker.DoubleClick && IsPointOnElement(out var element))
            {
                Debug.Log("Removing");
                RemoveElement(element);
            }
            else if (_mouseClicker.LeftClick && !IsPointOnElement(out _))
            {
                CreateElement(Extentions.GetMousePos());
            }
            
        }
        /*
        public void PlaceElement (BuildingElement element)
        {
            //List <BuildingElement> elements = new List<BuildingElement>(_elements.SortByDistance<BuildingElement>(element.transform.position));
            var closestElement = _elements.SortByDistance<BuildingElement>(element.transform.position)[1];
            var closestRenderer = closestElement.GetComponent<SpriteRenderer>();
            Debug.Log(closestRenderer.bounds.max - closestRenderer.bounds.min);
            

        }
        */
        private void CreateElement(Vector3 position)
        {
            var element = Object.Instantiate<BuildingElement>(_prototype, position, Quaternion.identity);
            //element.OnDrop += PlaceElement;
            _elements.Add(element);
        }

        private void RemoveElement(BuildingElement element)
        {
            _elements.Remove(element);
            //element.OnDrop -= PlaceElement;
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

    }
}
