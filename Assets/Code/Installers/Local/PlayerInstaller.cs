using Code.Player;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView _playerView;

        public override void InstallBindings() => BindPlayer();

        private void BindPlayer() =>
            Container
                .Bind<PlayerView>()
                .FromInstance(_playerView)
                .AsSingle();
    }
}