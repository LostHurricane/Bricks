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
        
        public static List<T> SortByDistance<T>(this List<T> objects, Vector3 mesureFrom) where T : Component
        {
            return objects.OrderBy(x => Vector3.Distance(x.transform.position, mesureFrom)).ToList();
        }

        public static IEnumerable<T> SortByDistance<T>(this IEnumerable<T> objects, Vector3 mesureFrom) where T : Component
        {
            return objects.OrderBy(x => Vector3.Distance(x.transform.position, mesureFrom)).ToList();
        }
    }
}
