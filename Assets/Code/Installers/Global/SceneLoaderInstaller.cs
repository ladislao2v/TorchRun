using Code.Services.SceneLoader;
using Zenject;

namespace Code.Installers.Global
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindSceneLoader();

        private void BindSceneLoader() =>
            Container
                .Bind<SceneLoader>()
                .AsSingle();
    }
}