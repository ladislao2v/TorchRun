using Code.Services.SaveLoadDataService;
using Zenject;

namespace Code.Installers.GlobalInstallers
{
    public class SaveLoadDataServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindSaveLoadDataService();

        private void BindSaveLoadDataService() =>
            Container
                .BindInterfacesAndSelfTo<SaveLoadDataService>()
                .AsSingle();
    }
}