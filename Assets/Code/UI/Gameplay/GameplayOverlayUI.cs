using UnityEngine;

namespace Code.UI.Gameplay
{
    public class GameplayOverlayUI : MonoBehaviour
    {
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
