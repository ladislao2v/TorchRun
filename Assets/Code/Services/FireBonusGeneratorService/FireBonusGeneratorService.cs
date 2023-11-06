using System.Collections;
using System.Collections.Generic;
using Code.FireBonus;
using Code.Services.CoroutineRunner;
using UnityEngine;

namespace Code.Services.FireBonusGeneratorService
{
    public class FireBonusGeneratorService : IFireBonusGeneratorService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly FireBonusView.Pool _pool;
        private readonly List<FireBonusView> _fireBonuses;

        private Coroutine _coroutine;
        private WaitForSeconds _delay = new WaitForSeconds(5);

        public FireBonusGeneratorService(ICoroutineRunner coroutineRunner, FireBonusView.Pool pool)
        {
            _coroutineRunner = coroutineRunner;
            _pool = pool;
            _fireBonuses = new();
        }
        
        public void Start()
        {
            _coroutine = _coroutineRunner.StartCoroutine(SpawnBonuses());
        }

        private IEnumerator SpawnBonuses()
        {
            while (true)
            {
                yield return _delay;
            }
        }

        public void Stop()
        {
            foreach (var bonus in _fireBonuses)
            {
                bonus.gameObject.SetActive(false);
            }
            
            _coroutineRunner.StopCoroutine(_coroutine);
        }
    }
}