using Code.Player;
using Code.UI.Menu;

namespace Code.StateMachine.States
{
    public class MenuState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly MenuUI _menu;

        public MenuState(IStateMachine stateMachine, MenuUI menu)
        {
            _stateMachine = stateMachine;
            _menu = menu;
        }
        
        public void Enter()
        {
            _menu.StartButtonClicked += _stateMachine.Enter<GameLoopState>;
            
            _menu.Show();
        }

        public void Exit()
        {
            _menu.Hide();
            
            _menu.StartButtonClicked -= _stateMachine.Enter<GameLoopState>;
        }
    }
}