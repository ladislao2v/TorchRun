using Code.Player;
using UnityEngine;

namespace Code.Obstacles
{
    public class Tap : Obstacle
    {
        protected override bool TryInteract(Collider other)
        {
            if (other.TryGetComponent(out PlayerView playerView))
            {
                if (playerView.IsLosed == false && playerView.IsCrouch == false)
                {
                    return true;
                }
            }

            return false;
        }
    }
}