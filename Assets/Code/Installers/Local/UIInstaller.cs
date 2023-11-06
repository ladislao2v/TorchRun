using Code.UI;
using Code.UI.Gameplay;
using Code.UI.Menu;
using Code.UI.StatsPanel;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private MenuUI _menu;
        [SerializeField] private GameplayOverlayUI _gameplayOverlay;
        [SerializeField] private LosePanel _losePanel;
        [SerializeField] private StatsPanel _statsPanel;

        public override void InstallBindings()
        {
            BindMenu();
            BindGameplayOverlay();
            BindStatsPanel();
            BindLosePanel();
        }

        private void BindLosePanel() =>
            Container
                .Bind<LosePanel>()
                .FromInstance(_losePanel)
                .AsSingle();

        private void BindStatsPanel()
        {
            Container
                .Bind<StatsPanel>()
                .FromInstance(_statsPanel)
                .AsSingle();
        }

        private void BindMenu() =>
            Container
                .Bind<MenuUI>()
                .FromInstance(_menu)
                .AsSingle();

        private void BindGameplayOverlay() =>
            Container
                .Bind<GameplayOverlayUI>()
                .FromInstance(_gameplayOverlay)
                .AsSingle();
    }
}