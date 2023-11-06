using System.Collections;
using System.Collections.Generic;
using Code.Section;
using Code.Services.CoroutineRunner;
using Code.Services.GameDataService;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Code.Services.MapGeneratorService
{
    public class MapGeneratorService : MonoBehaviour, IMapGeneratorService
    {
        [SerializeField] private List<SectionView> _sections;
        [SerializeField] private float _duration = 5f;

        private ICoroutineRunner _coroutineRunner;
        private Coroutine _coroutine;
        private List<Vector3> _positions;
        private WaitForSeconds _waitForSeconds;
        private int _index;

        [Inject]
        private void Construct(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _positions = new List<Vector3>();
            _waitForSeconds = new WaitForSeconds(_duration);
        }
        
        public void Run()
        {
            foreach(var section in _sections)
                _positions.Add(section.Position);
            
            _coroutine = _coroutineRunner.StartCoroutine(Generate());
        }

        public void Stop()
        {
            _coroutineRunner.StopCoroutine(_coroutine);
            DOTween.Clear();
        }

        private IEnumerator Generate()
        {
            while (true)
            {
                for (int i = 0; i < _sections.Count; i++)
                {
                    _sections[i].Move(i + 1, _positions[_positions.Count - 1]);
                }
                
                var section = _sections[0];
                _sections.RemoveAt(0);
                _sections.Add(section);

                yield return _waitForSeconds;
            }
        }
    }
}