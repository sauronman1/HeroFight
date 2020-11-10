using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public class ReturnToPositionState : IState
    {
        Vector3 target = Vector3.zero;

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
            owner.currentTurnToAttack = false;
            owner.attackInitiated = false;
            target = owner.heroPosition;
        }

        void IState.Update()
        {
            Vector3 direction = target - owner.transform.position;
            if (direction.magnitude > 1f)
                direction = direction.normalized;

            owner.Move(direction);

            if (direction.magnitude < 0.1f)
            {
                owner.ChangeState(new AttackPreperationState());
                
            }
        }
    }
}
