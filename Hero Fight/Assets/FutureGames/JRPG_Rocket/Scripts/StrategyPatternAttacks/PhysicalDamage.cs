using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public class PhysicalDamage : IAttack
    {
        public float Damage(float damageAmount)
        {
            return damageAmount;
        }
    }
}
