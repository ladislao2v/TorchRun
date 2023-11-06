using Code.Providers;
using Code.Services.InputService;
using Code.Torch;
using UnityEngine;
using Zenject;

namespace Code.Player
{
    [RequireComponent(typeof(Jumper))]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private TorchView _torchView;
        [SerializeField] private ParticleSystem _runEffects;
        
        private Jumper _jumper;
        private AnimatorProvider _animatorProvider;
        private Rigidbody _rigidbody;
        private InputService _inputService;
        private bool _isLosed;
        private bool _isCrouch;

        public bool IsLosed => _isLosed;
        public bool IsCrouch => _isCrouch;

        [Inject]
        private void Construct(InputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _isLosed = false;
            _animatorProvider = GetComponentInChildren<AnimatorProvider>();
            _jumper = GetComponent<Jumper>();
        }

        private void Update()
        {
            Crouch();
        }

        private void Crouch()
        {
            _isCrouch = _inputService.IsCrouch;

            _animatorProvider.PlayCrouch(_isCrouch);
        }

        public void Run()
        {
            _animatorProvider.PlayRunAnimation();
            _runEffects.gameObject.SetActive(true);
        }

        public void Jump()
        {
            _runEffects.gameObject.SetActive(false);
            _jumper.Jump(() => _runEffects.gameObject.SetActive(true));
        }

        public void Die()
        {
            _runEffects.gameObject.SetActive(false);
            _isLosed = true;
            _animatorProvider.PlayIdleAnimation();
            
            _torchView.TurnOff();
        }
    }
}