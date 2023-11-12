using UnityEngine;

namespace Assets.Scripts.Core.InputSystem
{
    public class TouchInput :MonoBehaviour, IInput
    {  
        public bool GetButtonDown()
        { 
            return Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began;
        }

        public bool GetButton()
        {
            return Input.touchCount > 0 && (Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary);
        }

        public bool GetButtonUp()
        {
            return Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended;
        }

        public Vector3 GetPosition()
        {
            return Input.touchCount > 0 ? Input.touches[0].position : Vector3.zero;
        }

        public int GetTouchCount()
        {
            return Input.touchCount;
        }

        public Touch GetTouch(int index)
        {
            return Input.GetTouch(index);
        }

        public Vector2 GetDeltaPosition()
        {
            return Input.touchCount > 0 ? Input.touches[0].deltaPosition : Vector2.zero;
        }
    }
}
