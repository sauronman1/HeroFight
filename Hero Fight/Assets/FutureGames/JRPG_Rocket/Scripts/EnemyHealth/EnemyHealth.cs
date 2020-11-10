using System;
using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public class EnemyHealth : MonoBehaviour
    {
        public static Action OnDamaged = delegate { };

        public void Damaged()
        {
            OnDamaged();
        }
    }
}