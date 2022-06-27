using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Bricks
{
    public class LinesController
    {
        private Transform _parent;

        private List<Pair> _connectedObjects;
        private MouseClicker _mouseClicker;

        private BuildingElement _lastElemeent;

        public LinesController(MouseClicker mouseClicker)
        {
            _mouseClicker = mouseClicker;
            _connectedObjects = new List<Pair>();

            _parent = new GameObject("Renderers").transform;
        }

        public void Execute()
        {
            StateCheck();

            if (_mouseClicker.RightClick)
            {
                if (Extentions.IsPointOnElement(out var element))
                {
                    if (!_lastElemeent)
                    {
                        _lastElemeent = element;
                    }
                    else
                    {
                        var lr = new GameObject().AddComponent<LineRenderer>();
                        lr.gameObject.transform.SetParent(_parent, false);
                        _connectedObjects.Add(new Pair{elementOne = _lastElemeent, elementTwo = element, lineRenderer = lr });
                        
                        Debug.Log("AddedIt");

                    }
                }
                else
                {
                    _lastElemeent = null;
                }
            }
        }

        private void StateCheck ()
        {
            foreach (var pair in _connectedObjects)
            {
                if (!pair.elementOne || !pair.elementTwo)
                {
                    Object.Destroy(pair.lineRenderer.gameObject);
                }
            }
            _connectedObjects.RemoveAll(pair => !pair.elementOne || !pair.elementTwo);
            Debug.Log(_connectedObjects.Count);


            

        }

        private struct Pair
        {
            public BuildingElement elementOne;
            public BuildingElement elementTwo;

            public LineRenderer lineRenderer;
        }
    }
}
