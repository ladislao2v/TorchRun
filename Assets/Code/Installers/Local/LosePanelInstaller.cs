using Code.UI;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class LosePanelInstaller : MonoInstaller
    {
        [SerializeField] private LosePanel _losePanel;

        public override void InstallBindings() => BindLosePanel();

        private void BindLosePanel() =>
            Container
                .Bind<LosePanel>()
                .FromInstance(_losePanel)
                .AsSingle();
    }
}