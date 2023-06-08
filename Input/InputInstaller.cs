using InputActions;
using Scripts.Input;
using Scripts.Zenject;
using UnityEngine.InputSystem;
using Zenject;

public class InputInstaller : Installer<InputInstaller>
{
    public override void InstallBindings()
    {
        //InputActionMap
        Container.Bind<CustomInputActions>().AsSingle();

        //InputManager
        Container.BindInterfacesTo<InputManager>().AsSingle();

        //Binders
        Container.BindInterfacesTo<InputBinder>().AsSingle();

        //Signals
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<InputActionSignal>().WithId(SignalIDs.MovementID);
        Container.DeclareSignal<InputActionSignal>().WithId(SignalIDs.AimID);
    }
}