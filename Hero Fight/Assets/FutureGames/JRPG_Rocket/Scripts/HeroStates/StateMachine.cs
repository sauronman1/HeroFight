using System;
using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public class StateMachine : MonoBehaviour
    {
        private IState    currentState = null;
        private Rigidbody body         = null;

        [NonSerialized] public Vector3     heroPosition;
        [NonSerialized] public bool        currentTurnToAttack = false;
        [NonSerialized] public bool        attackInitiated     = false;
        public                 GameObject  partyObject;
        public                 Factory     damageFactory;
        public                 EnemyHealth enemyHealth;
        public                 HealthBar   enemyHealthBar;
        public                 float       moveSpeed = 10f;
        public                 float       damage    = 0;

        public enum DamageType
        {
            Physical, 
            Magic
        }

        public DamageType damageType;
        
        public MagicalDamage mDamage = new MagicalDamage();
        public PhysicalDamage pDamage = new PhysicalDamage();

        Rigidbody Rigidbody
        {
            get
            {
                if (body == null)
                {
                    body = gameObject.AddComponent<Rigidbody>();
                    body.isKinematic = true;
                }

                return body;
            }
        }

        private void Start()
        {
            ChangeState(new AttackPreperationState());
            heroPosition = transform.position;
            switch (damageType)
            {
                case DamageType.Physical:
                    gameObject.GetComponent<StateMachine>().damage = gameObject.GetComponent<StateMachine>().pDamage.Damage(damage);
                    break;
                case DamageType.Magic:
                    gameObject.GetComponent<StateMachine>().damage = gameObject.GetComponent<StateMachine>().mDamage.Damage(damage);
                    break;
            }
        }

        private void Update()
        {
            UpdateState();
        }

        private void UpdateState()
        {
            if(currentState == null)
                return;
            
            currentState.Update();
        }

        public void ChangeState(IState newState)
        {
            if (currentState != null)
            {
                currentState.Destroy();
            }

            currentState = newState;

            if (currentState != null)
            {
                currentState.Owner = this;
                currentState.Prepare();
                
            }
        }

        public void Move(Vector3 direction)
        {
            Vector3 dampenedSpeed = direction * moveSpeed * Time.deltaTime;
            Rigidbody.MovePosition(Rigidbody.position + dampenedSpeed);
        }
    }
}
