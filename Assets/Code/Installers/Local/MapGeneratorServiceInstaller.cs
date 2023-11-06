using Code.Services.MapGeneratorService;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class MapGeneratorServiceInstaller : MonoInstaller
    {
        [SerializeField] private MapGeneratorService _mapGenerator;
        
        public override void InstallBindings() => BindMapGenerator();

        private void BindMapGenerator() =>
            Container
                .BindInterfacesAndSelfTo<MapGeneratorService>()
                .FromInstance(_mapGenerator)
                .AsSingle();
    }
}