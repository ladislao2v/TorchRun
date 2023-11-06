using System;
using System.Collections;
using Code.Services.CoroutineRunner;
using Code.Services.SaveLoadDataService.Data;
using UnityEngine;

namespace Code.Services.ScoreService
{
    public class ScoreService : IScoreService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly ProgressData _progressData;

        private int _score;
        private int _points = 10;
        private Coroutine _coroutine;

        public int LastScore => _score;
        
        public event Action<int> ScoreChanged;

        public ScoreService(ICoroutineRunner coroutineRunner, ProgressData progressData)
        {
            _coroutineRunner = coroutineRunner;
            _progressData = progressData;
        }

        public void Run()
        {
            _score = 0;
            
            _coroutine = _coroutineRunner.StartCoroutine(CountScore());
        }

        public void Stop()
        {
            _coroutineRunner.StopCoroutine(_coroutine);
            
            if(_progressData.Record < _score)
                _progressData.WriteRecord(_score);
        }

        private IEnumerator CountScore()
        {
            while (true)
            {
                for (int i = 0; i < _points; i++)
                    yield return null;

                ScoreChanged?.Invoke(_score += _points / _points);

                yield return null;
            }
        }
    }
}