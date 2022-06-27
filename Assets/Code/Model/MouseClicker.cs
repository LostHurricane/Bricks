using UnityEngine;

namespace Bricks
{
    /// <summary>
    /// Universal Input Class for this project
    /// </summary>
    public class MouseClicker
    {
        private const float DOUBLE_CLICK_TIME = 0.3f;

        public bool LeftClick => Input.GetMouseButtonDown(0);
        public bool RightClick => Input.GetMouseButtonDown(1);
        public bool DoubleClick { get; private set; }

        private float _lastClickTime;

        public void Check()
        {
            if (LeftClick)
            {
                float timeSinceLastClick = Time.time - _lastClickTime;
                if (timeSinceLastClick <= DOUBLE_CLICK_TIME)
                {
                    DoubleClick = true;
                }
                else
                {
                    DoubleClick = false;
                }
                _lastClickTime = Time.time;
            }
            else
            {
                DoubleClick = false;
            }
        }
    }
}
