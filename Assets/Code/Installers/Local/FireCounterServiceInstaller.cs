using Code.Services.FireCounterService;
using Zenject;

namespace Code.Installers.Local
{
    public class FireCounterServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindFireCounter();

        private void BindFireCounter() => 
            Container
                .BindInterfacesAndSelfTo<FireCounterService>()
                .AsSingle();
    }
}