using Code.UI.StatsPanel;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class StatsPanelInstaller : MonoInstaller
    {
        [SerializeField] private StatsPanel _statsPanel;

        public override void InstallBindings() => BindLosePanel();

        private void BindLosePanel() =>
            Container
                .Bind<StatsPanel>()
                .FromInstance(_statsPanel)
                .AsSingle();
    }
}