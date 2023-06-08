using Scripts.Input;
using Scripts.Player;
using UnityEngine;
using Zenject;
using Scripts.Zenject;

public class PlayerInstaller : Installer<PlayerInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<Rigidbody>().FromComponentSibling().AsSingle();

        Container.BindSignal<InputActionSignal>().WithId(SignalIDs.MovementID).ToMethod<PlayerMovement>(x => x.ReceiveInputAction).FromResolve();
        Container.BindSignal<InputActionSignal>().WithId(SignalIDs.AimID).ToMethod<PlayerAim>(x => x.ReceiveInputAction).FromResolve();

    }
}