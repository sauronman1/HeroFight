using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public class AttackState : IState
    {
        StateMachine owner = null;

        StateMachine IState.Owner
        {
            get => owner;
            set => owner = value;
        }

        void IState.Destroy()
        {
        }

        void IState.Prepare()
        {
            
        }

        void IState.Update()
        {
            owner.damageFactory.ShowDamage(owner.damage, owner.heroPosition);
            if (owner.gameObject.transform.GetSiblingIndex() + 1 < owner.partyObject.transform.childCount)
                owner.partyObject.transform.GetChild(owner.gameObject.transform.GetSiblingIndex() + 1)
                    .GetComponent<StateMachine>().currentTurnToAttack = true;
            owner.enemyHealthBar.damageTaken = owner.damage;
            owner.enemyHealth.Damaged();
            owner.ChangeState(new ReturnToPositionState());
        }
    }
}
