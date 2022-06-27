using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bricks
{
    public class Starter : MonoBehaviour
    {
        [SerializeField]
        private BuildingElement _prototype;

        private ElementController _elementController;
        private MouseClicker _mouseClicker;

        private LinesController linesController;

        void Start()
        {
            _mouseClicker = new MouseClicker();
            _elementController = new ElementController(_prototype, _mouseClicker);
            linesController = new LinesController(_mouseClicker);
        }

        void Update()
        {
            _mouseClicker.Check();
            _elementController.Execute(Time.deltaTime);
            linesController.Execute();
        }
    }
}
