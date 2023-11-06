using Code.Services.FireCounterService;
using UnityEngine;
using Zenject;

namespace Code.Light
{
    [RequireComponent(typeof(UnityEngine.Light))]
    public class LevelLight : MonoBehaviour
    {
        [SerializeField] private int _maxFireImages = 5;
        
        private UnityEngine.Light _light;
        private IFireCounterService _fireCounterService;
        private float _maxIntencivity;

        [Inject]
        private void Contruct(IFireCounterService fireCounterService)
        {
            _fireCounterService = fireCounterService;
        }

        private void Awake()
        {
            _light = GetComponent<UnityEngine.Light>();
            _maxIntencivity = _light.intensity;
        }

        private void OnEnable()
        {
            _fireCounterService.FireAdded += OnFireAdded;
            _fireCounterService.FireRemoved += OnFireRemomed;
        }

        private void OnDisable()
        {
            _fireCounterService.FireAdded -= OnFireAdded;
            _fireCounterService.FireRemoved -= OnFireRemomed;
        }

        private void OnFireAdded()
        {
            if(_maxIntencivity == _light.intensity)
                return;

            _light.intensity += _maxIntencivity/ _maxFireImages;
        }

        private void OnFireRemomed()
        {
            if(_light.intensity == 0)
                return;
            
            _light.intensity -= _maxIntencivity/ _maxFireImages;
        }

        public void TurnOff()
        {
            _light.intensity = 0;
        }
    }
}
