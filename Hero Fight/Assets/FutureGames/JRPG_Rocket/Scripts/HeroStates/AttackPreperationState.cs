using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public class AttackPreperationState : IState
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
           if (owner.attackInitiated)
          //  {
             //   if (owner.partyObject.transform.GetChild(0).GetComponent<StateMachine>().attackInitiated == false || owner.currentTurnToAttack || owner.gameObject.transform.GetSiblingIndex() == 0)
                    owner.ChangeState(new MoveToEnemyState());
          //  }
        }
    }
}
