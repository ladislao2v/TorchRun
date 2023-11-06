using Code.Services.FireCounterService;
using Code.Services.ScoreService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.StatsPanel
{
    public class StatsPanel : MonoBehaviour
    {
        [SerializeField] private Image[] _fireImages;
        [SerializeField] private TextMeshProUGUI _currentScore;

        private int _indexOfLastActive;
        private IFireCounterService _fireCounterService;
        private IScoreService _scoreService;

        [Inject]
        private void Construct(IFireCounterService fireCounterService, IScoreService scoreService)
        {
            _scoreService = scoreService;
            _fireCounterService = fireCounterService;
        }

        private void Awake()
        {
            _indexOfLastActive = _fireImages.Length - 1;
        }

        private void OnEnable()
        {
            _fireCounterService.FireAdded += OnFireAdded;
            _fireCounterService.FireRemoved += OnFireRemoved;
            _scoreService.ScoreChanged += OnScoreChanged;
        }

        private void OnScoreChanged(int value)
        {
            _currentScore.text = "Score: " + value;
        }

        private void OnDisable()
        {
            _fireCounterService.FireAdded -= OnFireAdded;
            _fireCounterService.FireRemoved -= OnFireRemoved;
            _scoreService.ScoreChanged -= OnScoreChanged;
        }

        private void OnFireRemoved()
        {
            _fireImages[_indexOfLastActive--]
                .gameObject
                .SetActive(false);
        }

        private void OnFireAdded()
        {
            _fireImages[++_indexOfLastActive]
                .gameObject
                .SetActive(true);
        }

        public void Reset()
        {
            foreach (var fireImage in _fireImages)
            {
                fireImage.gameObject.SetActive(true);
            }
        }
    }
}