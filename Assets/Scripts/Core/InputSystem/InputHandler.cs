using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Core.InputSystem
{
    public class InputHandler : MonoBehaviour
    {
        public bool considerFingerOverUI = false;

        public static event Action<Vector3, Vector3> OnPointerMove;
        public static event Action<Vector3> OnSwipe;
        public static event Action<Vector3> OnClickStart;
        public static event Action<Vector3> OnClickEnd;
        public static event Action<Vector2> OnJoystickMove;

        public IInput inputSource; // This can be set to any input source (TouchInput, MouseInput, etc.)
        public GameObject InputSourceObject; // This can be set to any input source (TouchInput, MouseInput, etc.);
        private bool isClicked = false;
        public Joystick joystick;
        public float swipeTreshold = 1f;

        private Vector3 pointerDownPosition = Vector3.zero;


        private void Awake()
        {
            inputSource = InputSourceObject.GetComponent<IInput>();
        }

        void Update()
        {
            if (considerFingerOverUI)
            {
                if (!IsPointerOverUI())
                {
                    HandleInput();
                }
            }
            else
            {
                HandleInput();
            }
        }

        private void HandleInput()
        {
            if (inputSource.GetButtonDown())
            {
                HandleClickStart(inputSource.GetPosition());
            }

            if (isClicked && inputSource.GetButton())
            {
                HandleMovement(inputSource.GetPosition(), inputSource.GetDeltaPosition());
                HandleJoystickMovement();
            }

            if (inputSource.GetButtonUp())
            {
                HandleClickEnd(inputSource.GetPosition());
                HandleSwipeCheck(inputSource.GetPosition());
            }
        }


        private void HandleClickStart(Vector3 pointerPosition)
        {
            isClicked = true;
            OnClickStart?.Invoke(pointerPosition);
            pointerDownPosition = pointerPosition;
        }

        private void HandleMovement(Vector3 pointerPosition, Vector3 deltaPos)
        {
            OnPointerMove?.Invoke(pointerPosition, deltaPos);
        }

        private void HandleJoystickMovement()
        {
            if (joystick != null)
            {
                OnJoystickMove?.Invoke(joystick.Direction);
            }
        }

        private void HandleClickEnd(Vector3 pointerPosition)
        {
            isClicked = false;
            OnClickEnd?.Invoke(pointerPosition);
        }

        private void HandleSwipeCheck(Vector3 pointerPosition)
        {
            if (Vector3.Distance(pointerPosition, pointerDownPosition) > swipeTreshold)
            {
                Vector3 deltaPos = pointerPosition - pointerDownPosition;
                OnSwipe?.Invoke(deltaPos);
            }
            pointerPosition = Vector3.zero;
        }

        public bool IsPointerOverUI()
        {
#if UNITY_EDITOR
            return EventSystem.current.IsPointerOverGameObject();
#elif UNITY_ANDROID || UNITY_IOS
        return Input.GetTouch(0).phase == TouchPhase.Began && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
#endif
        }

    }
}
