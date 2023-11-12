using UnityEngine;

namespace Assets.Scripts.Core.InputSystem
{
    public class MouseInput : MonoBehaviour, IInput
    { 
        public bool GetButtonDown()
        { 
            return Input.GetMouseButtonDown(0);
        }

        public bool GetButton()
        {
            return Input.GetMouseButton(0);
        }

        public bool GetButtonUp()
        { 
            return Input.GetMouseButtonUp(0);
        }

        public Vector3 GetPosition()
        { 
            return Input.mousePosition;
        }

        public int GetTouchCount()
        {
            return 1;
        }

        public Touch GetTouch(int index)
        {
            return new Touch();
        }

        Vector3 lastPosition=Vector3.zero;
        public Vector2 GetDeltaPosition()
        {
            if (GetButtonDown()) { 
                lastPosition= GetPosition();
            }

            Vector3 delta = GetPosition() - lastPosition;
            lastPosition = GetPosition();
            return delta;
        }
    }
}
