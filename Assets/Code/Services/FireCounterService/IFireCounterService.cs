using System;

namespace Code.Services.FireCounterService
{
    public interface IFireCounterService
    {
        public event Action FireAdded;
        public event Action FireRemoved;
        public event Action RanOut; 

        void AddFire();
        void RemoveFire();

        void Reset();
    }
}