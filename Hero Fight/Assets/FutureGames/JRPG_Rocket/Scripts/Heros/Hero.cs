using System.Collections.Generic;
using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public enum HeroState
    {
        Sleeping,
        Selected,
        Active,
    }
    
  

    public abstract class Hero
    {
        public HeroState heroState = HeroState.Sleeping;

        protected GameObject gameObject = null;

        protected Queue<Command> commands = new Queue<Command>();

        public abstract void AddCommand(Command command);

        public abstract void ExecuteCommands();

        public abstract void Attack();
        public abstract void SwitchWeapons();

        public static   Transform trSelect = null;
        public abstract void      ChangeState(HeroState newState);

        protected void Move(Vector3 amount)
        {
            gameObject.transform.Translate(amount);
        }
    }
}