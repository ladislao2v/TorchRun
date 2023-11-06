using Code.Services.GameDataService;
using Code.Services.SaveLoadDataService.Data;
using UnityEngine;

namespace Code.StateMachine.States
{
    public sealed class LoadDataState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IGameDataService _gameDataService;
        private readonly ProgressData _progress;

        public LoadDataState(IStateMachine stateMachine, IGameDataService gameDataService, ProgressData progress)
        {
            _stateMachine = stateMachine;
            _gameDataService = gameDataService;
            _progress = progress;
        }

        public void Enter()
        {
            Load();
            
            _stateMachine.Enter<MenuState>();
        }

        private void Load()
        {
            _gameDataService.Add(_progress);
            _gameDataService.LoadData();
        }

        public void Exit() { }
    }
}