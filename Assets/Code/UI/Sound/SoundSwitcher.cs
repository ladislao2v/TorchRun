using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Sound
{
    [RequireComponent(typeof(Toggle))]
    public class SoundSwitcher : MonoBehaviour
    {
        private Toggle _toggle;
        private AudioListener _audioListener;
        
        [Inject]
        private void Construct(AudioListener audioListener)
        {
            _audioListener = audioListener;
        }

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
        }

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(OnValueSwitcher);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(OnValueSwitcher);
        }

        private void OnValueSwitcher(bool isActive)
        {
            _audioListener.enabled = isActive;
        }
    }
}
