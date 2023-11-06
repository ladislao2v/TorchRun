using Code.Services.ScoreService;
using Zenject;

namespace Code.Installers.Local
{
    public class ScoreServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindScore();

        private void BindScore() =>
            Container
                .BindInterfacesAndSelfTo<ScoreService>()
                .AsSingle();
    }
}