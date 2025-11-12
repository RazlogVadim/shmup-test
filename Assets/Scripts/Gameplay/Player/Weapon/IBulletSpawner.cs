using UnityEngine;

namespace Gameplay.Player.Weapon
{
    public interface IBulletSpawner
    {
        void SpawnBullet(Vector3 origin);
    }
}