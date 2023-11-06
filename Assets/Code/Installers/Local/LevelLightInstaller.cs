using Code.Light;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class LevelLightInstaller : MonoInstaller
    {
        [SerializeField] private LevelLight _levelLight;

        public override void InstallBindings() => BindLevelLight();

        private void BindLevelLight() =>
            Container
                .Bind<LevelLight>()
                .FromInstance(_levelLight)
                .AsSingle();
    }
}
