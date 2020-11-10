namespace FutureGames.JRPG_Rocket
{
    public class CommandSwitchWeapon : Command
    {
        public override void Execute(Hero hero)
        {
            hero.SwitchWeapons();
        }
    }
}
