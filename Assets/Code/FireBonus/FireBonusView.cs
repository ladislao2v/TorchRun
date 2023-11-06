using System;
using Code.Player;
using Code.Services.FireCounterService;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Zenject;

namespace Code.FireBonus
{
    public class FireBonusView : MonoBehaviour
    {
        private IFireCounterService _fireCounterService;

        [Inject]
        private void Construct(IFireCounterService fireCounterService)
        {
            _fireCounterService = fireCounterService;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerView playerView))
            {   
                _fireCounterService.AddFire();
                gameObject.SetActive(false);
            }
        }

        private void Reset(Vector3 position)
        {
            transform.position = position;
        }

        public class Pool : MemoryPool<Vector3, FireBonusView>
        {
            protected override void Reinitialize(Vector3 position, FireBonusView item)
            {
                item.Reset(position);
            }
        }
    }
}
