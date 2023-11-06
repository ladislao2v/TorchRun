using Code.Services.FireCounterService;
using UnityEngine;
using Zenject;

namespace Code.Obstacles
{
    public abstract class Obstacle : MonoBehaviour
    {
        private IFireCounterService _fireCounterService;

        [Inject]
        private void Construct(IFireCounterService fireCounterService)
        {
            _fireCounterService = fireCounterService;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (TryInteract(other))
                _fireCounterService.RemoveFire();
        }

        protected abstract bool TryInteract(Collider other);
    }
}
