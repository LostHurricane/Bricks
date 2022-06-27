using UnityEngine;

namespace Bricks
{
    /// <summary>
    /// Main View of elements
    /// </summary>
    public class BuildingElement : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        private void OnMouseDrag()
        {
            _rigidbody2D.MovePosition(Extentions.GetMousePos());
        }

        private void OnMouseDown()
        {
            //Debug.Log("Unfreeze");
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        private void OnMouseUp()
        {
            //Debug.Log("freeze");
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }


    }
}
