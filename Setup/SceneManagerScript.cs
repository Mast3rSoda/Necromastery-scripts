using UnityEngine;
using UnityEngine.SceneManagement;
using Scripts.Input.Enums;
using Zenject;

public class SceneManagerScript
{
    private IInputManager _inputManager;

    public SceneManagerScript(IInputManager inputManager)
    { 
        _inputManager = inputManager;
    }

    public void LoadScene(int sceneIndex)
    {

    }

}
