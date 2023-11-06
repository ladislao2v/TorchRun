using System;
using Code.Swipe;
using UnityEngine;
using Zenject;

namespace Code.Services.InputService
{
    public class InputService : IInputService
    {
        public bool IsCrouch => Input.GetMouseButton(0);
        public event Action Jumped;
        
        public void Enable()
        {
            SwipeDetectorService.OnSwipe += OnSwipe; 
        }

        public void Disable()
        {
            SwipeDetectorService.OnSwipe -= OnSwipe; 
        }

        private void OnSwipe(SwipeData swipeData)
        {
            if(swipeData.Direction == SwipeDirection.Up)
                Jumped?.Invoke();
        }
    }
}