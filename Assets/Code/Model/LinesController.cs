using System.Collections.Generic;
using UnityEngine;

namespace Bricks
{
    public class LinesController
    {
        private Transform _parent;

        private List<Pair> _connectedObjects;
        private MouseClicker _mouseClicker;

        private BuildingElement _lastElement; // first element we clicked

        public LinesController(MouseClicker mouseClicker)
        {
            _mouseClicker = mouseClicker;
            _connectedObjects = new List<Pair>();

            _parent = new GameObject("Renderers").transform;
        }

        public void Execute()
        {
            StateCheck();
            MouseCheck();
            Draw();

        }

        private void MouseCheck()
        {
            if (_mouseClicker.RightClick)
            {
                if (Extentions.IsPointOnElement(out var element))
                {
                    if (!_lastElement)
                    {
                        _lastElement = element;
                    }
                    else
                    {
                        _connectedObjects.Add(new Pair { elementOne = _lastElement.transform, elementTwo = element.transform, lineRenderer = LaneRendererBuild() });
                        _lastElement = null;
                    }
                }
                else
                {
                    _lastElement = null;
                }
            }
        }

        private void Draw ()
        {
            foreach (var pair in _connectedObjects)
            {
                var temp = new Vector3(pair.elementOne.position.x, pair.elementOne.position.y, -1); // for some reason I nedd to plase lines closer to camera (z = -10) in order to draw lines over elements
                pair.lineRenderer.SetPosition(0, temp);
                temp = new Vector3(pair.elementTwo.position.x, pair.elementTwo.position.y, -1);
                pair.lineRenderer.SetPosition(1, temp);

            }
        }

        private LineRenderer LaneRendererBuild()
        {
            var lr = new GameObject().AddComponent<LineRenderer>();
            lr.gameObject.transform.SetParent(_parent, false);
            lr.startWidth = 0.05f;
            return lr;
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
        }

        private struct Pair
        {
            public Transform elementOne;
            public Transform elementTwo;

            public LineRenderer lineRenderer;
        }
    }
}
