namespace FutureGames.JRPG_Rocket
{

    public interface IState 
    {
        StateMachine Owner { get; set; }

        void Prepare();
        void Update();
        void Destroy();
    }
}
