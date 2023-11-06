using Code.Services.FireCounterService;
using UnityEngine;
using Zenject;

namespace Code.Torch
{
    public class TorchView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _fireEffect;
        [SerializeField] private UnityEngine.Light _light;
        [SerializeField] private int _maxFireImages = 5;

        private float _maxLifetime;
        private IFireCounterService _fireCounterService;

        [Inject]
        private void Construct(IFireCounterService fireCounterService)
        {
            _fireCounterService = fireCounterService;
        }

        private void Awake()
        {
            _maxLifetime = _fireEffect.startLifetime;
        }

        private void OnEnable()
        {
            _fireCounterService.FireAdded += OnFireAdded;
            _fireCounterService.FireRemoved += OnFireRemoved;
        }

        private void OnDisable()
        {
            _fireCounterService.FireAdded -= OnFireAdded;
            _fireCounterService.FireRemoved -= OnFireRemoved;
        }

        private void OnFireAdded()
        {
            if(_fireEffect.startLifetime == _maxLifetime)
                return;

            _fireEffect.startLifetime = _fireEffect.startLifetime + _maxLifetime / _maxFireImages;
        }

        private void OnFireRemoved()
        {
            if(_fireEffect.startLifetime == 0)
                return;
            
            _fireEffect.startLifetime = _fireEffect.startLifetime - _maxLifetime / _maxFireImages;
        }

        public void TurnOff()
        {
            _light.gameObject.SetActive(false);
            _fireEffect.gameObject.SetActive(false);
        }
    }
}