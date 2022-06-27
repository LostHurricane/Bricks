using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Bricks
{
    public class LinesController
    {
        private Transform _parent;

        private List <LineRenderer> _lineRenderers;
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
                        _connectedObjects.Add(new Pair{elementOne = _lastElemeent, elementTwo = element});
                        Debug.Log("AddedIt");

                    }
                }
                else
                {
                    _lastElemeent = null;
                }
            }
            StateCheck();
        }

        private void StateCheck ()
        {
            _connectedObjects.RemoveAll(pair => !pair.elementOne || !pair.elementTwo);
            Debug.Log(_connectedObjects.Count);


        
        }

        private struct Pair
        {
            public BuildingElement elementOne;
            public BuildingElement elementTwo;
        }
    }
}
