using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bricks
{
    public static class Extentions
    {
        public static Vector3 GetMousePos()
        {
            var cam = Camera.main;
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            return mousePos;
        }

        public static bool IsPointOnElement(out BuildingElement element)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.collider.TryGetComponent<BuildingElement>(out var component))
            {
                element = component;
                return true;
            }
            else
            {
                element = null;
                return false;
            }
        }

        public static List<T> SortByDistance<T>(this IEnumerable<T> objects, Vector3 mesureFrom) where T : Component
        {
            return objects.OrderBy(x => Vector3.Distance(x.transform.position, mesureFrom)).ToList();
        }
    }
}
