using FutureGames.JRPG_Rocket;
using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public class HealthBar : MonoBehaviour
    {
        public float         damageTaken = 5;
        public float         health      = 30;
        public RectTransform fillBar;

        private void OnEnable()
        {
            EnemyHealth.OnDamaged += EnemyDamaged;
        }

        private void OnDisable()
        {
            EnemyHealth.OnDamaged -= EnemyDamaged;
        }

        private void EnemyDamaged()
        {
            ReduceHealth();
        }

        private void ReduceHealth()
        {
            float damageEqualTo1Health = 1 / health;
            damageTaken = damageEqualTo1Health * damageTaken;
            Debug.Log(damageTaken);
            float z = fillBar.localScale.x - damageTaken;
            z = Mathf.Clamp(z, 0f, 1f);
            fillBar.localScale = new Vector3(z, fillBar.localScale.y,
                    fillBar.localScale.z);
            

        }
    }
}
