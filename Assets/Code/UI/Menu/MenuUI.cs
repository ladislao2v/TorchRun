using System;
using Code.Services.SaveLoadDataService.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Menu
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private TextMeshProUGUI _record;
        
        private ProgressData _progress;

        public event Action StartButtonClicked;

        [Inject]
        private void Construct(ProgressData progress)
        {
            _progress = progress;
        }
        
        public void Show()
        {
            _startButton.onClick.AddListener(OnStartButtonClick);
            _record.text = "Your Record: " + _progress.Record;

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            
            _startButton.onClick.RemoveListener(OnStartButtonClick);
        }

        private void OnStartButtonClick()
        {
            StartButtonClicked?.Invoke();
        }
    }
}