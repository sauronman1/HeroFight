using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public class WaitState : IState
    {
        private float        waitTime = 2f;
        StateMachine owner    = null;
        StateMachine IState. Owner { get => owner; set => owner = value; }

        public IState nextState;
        
        void IState.Destroy()
        {}

        void IState.Prepare()
        {}

        void IState.Update()
        {
            waitTime -= Time.deltaTime;

            if (waitTime < 0f)
            {
                owner.ChangeState(nextState);
            }
        }
    }
}