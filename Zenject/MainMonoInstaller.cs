using Scripts.Player;
using UnityEngine;
using Zenject;

public class MainMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InputInstaller.Install(Container);
        PlayerInstaller.Install(Container);
    }
}