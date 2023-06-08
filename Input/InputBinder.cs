using InputActions;
using Scripts.Input.Enums;
using Scripts.Zenject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputBinder : IInputBinder
{

    private SignalBus _signalBus;


    public InputBinder(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void BindInput(CustomInputActions inputActions)
    {
        Debug.Log("Binding Input!");

        BindIngameMap(inputActions.Ingame);
        BindMenuMap(inputActions.Menu);
    }

    public void UnbindAll()
    {
        throw new System.NotImplementedException();
    }

    private void BindIngameMap(CustomInputActions.IngameActions ingameActions)
    {

        _signalBus.FireId(SignalIDs.MovementID, new InputActionSignal() { inputAction = ingameActions.Movement });
        _signalBus.FireId(SignalIDs.AimID, new InputActionSignal() { inputAction = ingameActions.Aim });

    }

    private void BindMenuMap(CustomInputActions.MenuActions menuActions)
    {

    }

}
