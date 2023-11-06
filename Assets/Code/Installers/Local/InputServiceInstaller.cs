using Code.Services.InputService;
using Zenject;

namespace Code.Installers.Local
{
    public class InputServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindInputService();

        private void BindInputService() =>
            Container
                .BindInterfacesAndSelfTo<InputService>()
                .AsSingle();
    }
}