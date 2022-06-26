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

        void Start()
        {
            _elementController = new ElementController(_prototype);
        
        }

        void Update()
        {
            _elementController.Execute(Time.deltaTime);
        }
    }
}
