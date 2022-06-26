using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bricks
{
    public class BuildingElement : MonoBehaviour
    {
        private Vector3 _dragOffset;
        private Camera _cam;

        [SerializeField] private float _speed = 10;

        void Awake()
        {
            _cam = Camera.main;
        }

        private void OnMouseDown()
        {
            
        }

        private void OnMouseDrag()
        {
            transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
        }

        Vector3 GetMousePos()
        {
            var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            return mousePos;
        }
    }
}
