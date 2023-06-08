using InputActions;
using Scripts.Input.Enums;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Scripts.Input
{
    public class InputManager : IInputManager
    {
        

        private readonly CustomInputActions _inputActions;

        private InputActionMap _currentInputActionMap;

        private IInputBinder _binder;

        public InputManager(CustomInputActions inputActions, IInputBinder binder)
        {
            _inputActions = inputActions;
            _binder = binder;
        }

        //Don't think we'll need this since we are using signals
        public InputActionMap GetInputActionMap()
        {
            Debug.Log("GetInputActionMap");
            return _currentInputActionMap;
        }


        public void SetActiveInputActionMap(InputMapEnum mapEnum)
        {
            Debug.Log("Setting InputActionMap!");
            
            if (_currentInputActionMap != null) _currentInputActionMap.Disable();

            switch (mapEnum)
            {
                case InputMapEnum.Menu:
                    _currentInputActionMap = _inputActions.Menu;
                    break;
                
                case InputMapEnum.Ingame:
                    _currentInputActionMap = _inputActions.Ingame;
                    break;

                default:
                    return;
            }
            _currentInputActionMap.Enable();
        }

        public void BindInputActionMap()
        {
            _binder.BindInput(_inputActions);
        }
    }
}

