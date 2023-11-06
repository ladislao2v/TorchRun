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
                Hide();
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
