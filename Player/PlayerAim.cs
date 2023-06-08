using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerAim : MonoBehaviour
{
    private InputAction _action;
    private Vector2 _mousePosition;

    [SerializeField] private LayerMask _aimLayer;

    public void ReceiveInputAction(InputActionSignal inputActionSignal)
    {
        _action = inputActionSignal.inputAction;
    }

    private void FixedUpdate()
    {
        _mousePosition = _action.ReadValue<Vector2>();
        if (Physics.Raycast(Camera.main.ScreenPointToRay(_mousePosition), out RaycastHit hitInfo, Mathf.Infinity, _aimLayer.value))
            transform.LookAt(new Vector3(hitInfo.point.x, 1f, hitInfo.point.z));
    }
}
