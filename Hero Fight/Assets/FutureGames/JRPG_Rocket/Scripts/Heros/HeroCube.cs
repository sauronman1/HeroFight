using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public class HeroCube : Hero
    {
        float moveAmount = 2f;

        public HeroCube(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public override void AddCommand(Command command)
        {
            commands.Enqueue(command);
        }

        public override void ChangeState(HeroState newState)
        {
            heroState = newState;
        }

        public override void ExecuteCommands()
        {
            foreach (Command t in commands)
            {
                t.Execute(this);
            }
            commands.Clear();
        }

        public override void Attack()
        {
            gameObject.GetComponent<StateMachine>().attackInitiated = true;
        }

        public override void SwitchWeapons()
        {
            switch (gameObject.GetComponent<StateMachine>().damageType)
            {
                case StateMachine.DamageType.Physical:
                    gameObject.GetComponent<StateMachine>().damage = gameObject.GetComponent<StateMachine>().pDamage.Damage(3);
                    break;
                case StateMachine.DamageType.Magic:
                    gameObject.GetComponent<StateMachine>().damage = gameObject.GetComponent<StateMachine>().mDamage.Damage(3);
                    break;
            }
            
        }
    }
}