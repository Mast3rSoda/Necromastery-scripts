using InputActions;
using Scripts.Input.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputBinder
{
    void BindInput(CustomInputActions inputActions);

    void UnbindAll();
}
