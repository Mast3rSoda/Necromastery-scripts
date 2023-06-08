using Scripts.Input.Enums;
using UnityEngine.InputSystem;

public interface IInputManager
{
    InputActionMap GetInputActionMap();

    void SetActiveInputActionMap(InputMapEnum mapEnum);

    void BindInputActionMap();
}
