using Code.Services.SaveLoadDataService.Data;
using Code.Services.ScoreService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
    public class LosePanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private TextMeshProUGUI _record;
        [SerializeField] private Button _restartButton;
        
        private IScoreService _scoreService;
        private ProgressData _progressData;

        public Button RestartButton => _restartButton;

        [Inject]
        private void Construct(IScoreService scoreService, ProgressData progressData)
        {
            _progressData = progressData;
            _scoreService = scoreService;
        }

        public void Show()
        {
            _progressData.RecordUpdated += OnRecordUpdated;
            _record.text = "Your Record: " + _progressData.Record;
            _currentScore.text = "Current Score: " + _scoreService.LastScore;

            gameObject.SetActive(true);
        }

        private void OnRecordUpdated(int record)
        {
            _record.text = "Your Record: " + record;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _progressData.RecordUpdated -= OnRecordUpdated;
        }
    }
}