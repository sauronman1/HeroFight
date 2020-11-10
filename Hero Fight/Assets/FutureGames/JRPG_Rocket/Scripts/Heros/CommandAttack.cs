namespace FutureGames.JRPG_Rocket
{
    public class CommandAttack : Command
    {
        public override void Execute(Hero hero)
        {
            hero.Attack();
        }
    }
}
