## Input System

This project contains a flexible input handling system for Unity that allows for various input sources such as mouse, touch, and joystick interactions.

### Overview

The `InputHandler` class is the core of the input system. It manages different input events and delegates the handling to specific input sources. Here’s a breakdown of the key components:

- **`InputHandler` Class:** Manages various input events and delegates them to specific input sources.
  
  - **Events:** 
    - `OnPointerMove`: Triggered on pointer movement.
    - `OnSwipe`: Triggered on a swipe gesture.
    - `OnClickStart`: Triggered on the start of a click or touch.
    - `OnClickEnd`: Triggered on the end of a click or touch.
    - `OnJoystickMove`: Triggered when joystick movement is detected.

  - **Input Sources:** 
    - `MouseInput`: Handles input from the mouse.
    - `TouchInput`: Handles touch input on mobile devices.

### How to Use

1. **Attach `InputHandler` to an object in your scene.**
2. **Set the Input Sources:**
   - Assign `MouseInput` or `TouchInput` scripts to `InputSourceObject` as needed.
3. **Subscribe to Events:**
   - Other scripts can subscribe to events triggered by `InputHandler` to react to various input actions. Example usage can be seen in the `InputChecker` script.
4. **Customize Input Handling:**
   - You can modify or add more input sources by implementing the `IInput` interface and creating additional classes to handle specialized input devices.

### Usage Example

The `InputChecker` script demonstrates how to subscribe to and handle input events triggered by the `InputHandler`. You can expand on this by creating your own scripts to respond to specific input events.

### Additional Notes

- The system allows for easy integration of new input sources by implementing the `IInput` interface.
- Modify the `considerFingerOverUI` flag in `InputHandler` to control input handling over UI elements.

### Requirements

- Unity 3D (compatible with the version used in the provided code).

 
