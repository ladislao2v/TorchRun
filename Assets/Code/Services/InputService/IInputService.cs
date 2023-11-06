using System;

namespace Code.Services.InputService
{
    public interface IInputService
    {
        public bool IsCrouch { get; }
        public event Action Jumped;

        void Enable();
        void Disable();
    }
}