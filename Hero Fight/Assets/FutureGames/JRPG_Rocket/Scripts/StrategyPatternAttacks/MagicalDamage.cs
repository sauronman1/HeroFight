using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public class MagicalDamage : IAttack
    {
        public float Damage(float damageAmount)
        {
            return damageAmount * 1.5f;
        }
    }
}
