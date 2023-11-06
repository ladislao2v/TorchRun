using UnityEngine;

namespace Code.Providers
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorProvider : MonoBehaviour
    {
        private const string IdleTrigger = nameof(IdleTrigger);
        private const string JumpTrigger = nameof(JumpTrigger);
        private const string RunTrigger = nameof(RunTrigger);
        private const string IsCrouch = nameof(IsCrouch);

        private Animator _animator;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayJumpAnimation()
        {
            _animator.SetTrigger(JumpTrigger);
        }

        public void PlayRunAnimation()
        {
            _animator.SetTrigger(RunTrigger);
        }

        public void PlayIdleAnimation()
        {
            _animator.SetTrigger(IdleTrigger);
        }

        public void PlayCrouch(bool isCrouch)
        {
            _animator.SetBool(IsCrouch, isCrouch);
        }
    }
}
