using Assets.Scripts.Core.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.InputSystem
{
    public class InputChecker : MonoBehaviour
    {
        private void OnEnable()
        {
            InputHandler.OnClickStart += InputHandler_OnClickStart;
            InputHandler.OnPointerMove += InputHandler_OnPointerMove;
            InputHandler.OnJoystickMove += InputHandler_OnJoystickMove;
        }

        private void InputHandler_OnJoystickMove(Vector2 direction)
        {
            Debug.Log("OnJoystickMove( : " + direction);
        }

        private void InputHandler_OnPointerMove(Vector3 pointerPosition, Vector3 deltaPosition)
        {
            Debug.Log("OnPointerMove : "+pointerPosition +"-"+ deltaPosition);
        }

        private void OnDisable()
        {
            InputHandler.OnClickStart -= InputHandler_OnClickStart;
            InputHandler.OnPointerMove -= InputHandler_OnPointerMove;
        }

        private void InputHandler_OnClickStart(Vector3 pointerPosition)
        {
            Debug.Log("Click start");
        }
    }
}