using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public class MoveToEnemyState : IState
    {
        Vector3 target = Vector3.zero;

        StateMachine        owner = null;
        StateMachine IState.Owner { get => owner; set => owner = value; }

        void IState.Destroy()
        {
            
        }

        void IState.Prepare()
        {
            target = GameObject.Find("Enemy").transform.position;
        }
        void IState.Update()
        {
            Vector3 direction = target - owner.transform.position;
            if (direction.magnitude > 1f)
                direction = direction.normalized;
            
            owner.Move(direction);

            if (direction.magnitude < 0.2f)
                owner.ChangeState(new AttackState());
        }
    }
}
