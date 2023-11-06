using Code.Light;
using Code.Player;
using Code.Services.FireCounterService;
using Code.Services.InputService;
using Code.Services.MapGeneratorService;
using Code.Services.ScoreService;
using Code.UI;
using Code.UI.Gameplay;

namespace Code.StateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IInputService _inputService;
        private readonly IMapGeneratorService _mapGenerator;
        private readonly IFireCounterService _fireCounterService;
        private readonly LosePanel _losePanel;
        private readonly IScoreService _scoreService;
        private readonly LevelLight _levelLight;
        private readonly PlayerView _player;
        private readonly GameplayOverlayUI _gameplayOverlay;

        protected GameLoopState(IStateMachine stateMachine,
            IInputService inputService,
            PlayerView player,
            GameplayOverlayUI gameplayOverlay,
            IMapGeneratorService mapGenerator,
            IFireCounterService fireCounterService,
            LosePanel losePanel,
            IScoreService scoreService,
            LevelLight levelLight)
        {
            _stateMachine = stateMachine;
            _inputService = inputService;
            _player = player;
            _gameplayOverlay = gameplayOverlay;
            _mapGenerator = mapGenerator;
            _fireCounterService = fireCounterService;
            _losePanel = losePanel;
            _scoreService = scoreService;
            _levelLight = levelLight;
        }

        public void Enter()
        {
            _inputService.Jumped += _player.Jump;
            _fireCounterService.RanOut += _mapGenerator.Stop;
            _fireCounterService.RanOut += _player.Die;
            _fireCounterService.RanOut += _losePanel.Show;
            _fireCounterService.RanOut += _scoreService.Stop;
            _fireCounterService.RanOut += _levelLight.TurnOff;
            _losePanel.RestartButton.onClick.AddListener(OnRestartButtonClick);
            
            _gameplayOverlay.Show();
            _player.Run();
            _inputService.Enable();
            
            _mapGenerator.Run();
            _scoreService.Run();
        }

        public void Exit()
        {
            _losePanel.Hide();
            _gameplayOverlay.Hide();
            _inputService.Disable();
            _fireCounterService.Reset();
            
            _inputService.Jumped -= _player.Jump;
            _fireCounterService.RanOut -= _mapGenerator.Stop;
            _fireCounterService.RanOut -= _player.Die;
            _fireCounterService.RanOut -= _losePanel.Show;
            _fireCounterService.RanOut -= _scoreService.Stop;
            _fireCounterService.RanOut -= _levelLight.TurnOff;
            _losePanel.RestartButton.onClick.RemoveListener(OnRestartButtonClick);
        }

        private void OnRestartButtonClick()
        {
            _stateMachine.Enter<SaveDataState>();
        }
    }
}