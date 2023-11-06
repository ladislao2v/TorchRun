using Code.Services.SaveLoadDataService.Data;
using Zenject;

namespace Code.Installers.Global
{
    public class DataInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindProgressData();

        private void BindProgressData() =>
            Container
                .Bind<ProgressData>()
                .AsSingle();
    }
}
