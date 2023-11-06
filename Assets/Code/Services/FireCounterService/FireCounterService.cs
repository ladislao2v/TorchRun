using System;

namespace Code.Services.FireCounterService
{
    public class FireCounterService : IFireCounterService
    {
        private readonly int _maxCount = 5;
        private int _count;

        public event Action FireAdded;
        public event Action FireRemoved;
        public event Action RanOut;

        public FireCounterService()
        {
            _count = _maxCount;
        }

        public void AddFire()
        {
            if(_count == _maxCount)
                return;

            _count++;

            FireAdded?.Invoke();
        }

        public void RemoveFire()
        {
            _count--;
            
            FireRemoved?.Invoke();

            if (_count == 0)
                RanOut?.Invoke();
        }

        public void Reset()
        {
            _count = _maxCount;
        }
    }
}