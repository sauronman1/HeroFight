
using FutureGames.Lib.Extensions;
using UnityEngine;

namespace FutureGames.JRPG_Rocket
{
    public class MonoHeroCapsule : MonoBehaviour
    {
        HeroCapsule          hero  = null;
        private StateMachine owner = null;
        public  GameObject   buttons;

        private void Start()
        {
            owner = GetComponent<StateMachine>();
            hero = new HeroCapsule(gameObject);
        }

        private void Update()
        {
            
            if (hero.heroState == HeroState.Selected && transform != Hero.trSelect)
            {
                hero.heroState = HeroState.Active;
                GetComponent<Renderer>().material.color = Color.white;
            }
        }

        private void OnMouseDown()
        {
            hero.ChangeState(HeroState.Selected);
            Hero.trSelect = transform;
            GetComponent<Renderer>().material.color = Color.green;
            buttons.SetActive(true);
        }

        public void FinishCommand()
        {
            if (hero.heroState == HeroState.Selected)
            {
                hero.AddCommand(new CommandAttack());
                hero.ChangeState(HeroState.Active);
                GetComponent<Renderer>().material.color = Color.white;
            }
        }

        public void EndTurn()
        {
            hero.ExecuteCommands();
        }

        public void SwitchDamageType(int weaponID)
        {
            if (hero.heroState == HeroState.Selected)
            {
                switch (weaponID)
                {
                    case 0:
                        owner.damageType = StateMachine.DamageType.Magic;
                        break;
                    case 1:
                        owner.damageType = StateMachine.DamageType.Physical;
                        break;
                    default:
                        break;
                }

                hero.SwitchWeapons();
            }
        }
    }
}
