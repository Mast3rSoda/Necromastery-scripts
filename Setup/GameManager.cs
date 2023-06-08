using System.Collections;
using System.Collections.Generic;
using Scripts.Input.Enums;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private IInputManager _inputManager;

    [Inject]
    public void Init(IInputManager inputManager)
    {
        _inputManager = inputManager;
    }

    // Start is called before the first frame update
    [ExecuteInEditMode]
    void Awake()
    {
        Application.targetFrameRate = 60;
        _inputManager.BindInputActionMap();
        _inputManager.SetActiveInputActionMap(InputMapEnum.Ingame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
