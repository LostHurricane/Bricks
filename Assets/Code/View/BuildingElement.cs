using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bricks
{
    public class BuildingElement : MonoBehaviour
    {
        public Action <BuildingElement> OnDrop { get; set; }

        [SerializeField]
        private float _speed = 10;

        private bool _isDraged;
        private bool _isOverOtherElement;

        private void OnMouseDrag()
        {
            _isDraged = true;
            transform.position = Vector3.MoveTowards(transform.position, Extentions.GetMousePos() , _speed * Time.deltaTime);
            Debug.Log(_isOverOtherElement);
        }

        private void OnMouseUp()
        {
            if (_isDraged && _isOverOtherElement)
            {
                if (OnDrop != null)
                {
                    OnDrop.Invoke(this);
                }
            }
            _isDraged = false;

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isDraged && collision.TryGetComponent<BuildingElement>(out _) )
            {
                _isOverOtherElement = true;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (_isDraged && collision.TryGetComponent<BuildingElement>(out _))
            {
                _isOverOtherElement = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _isOverOtherElement = false;

        }

    }
}
