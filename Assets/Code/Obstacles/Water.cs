using Code.Player;
using UnityEngine;

namespace Code.Obstacles
{
    public class Water : Obstacle
    {
        protected override bool TryInteract(Collider other)
        {
            if (other.TryGetComponent(out PlayerView playerView))
            {
                if (playerView.IsLosed == false)
                    return true;
            }

            return false;
        }
    }
}