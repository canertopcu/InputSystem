using UnityEngine;

namespace Assets.Scripts.Core.InputSystem
{
    public interface IInput
    {  
        bool GetButtonDown();
        bool GetButton();
        bool GetButtonUp();
        Vector3 GetPosition();
        int GetTouchCount();
        Touch GetTouch(int index);
        Vector2 GetDeltaPosition(); 
    }
}
