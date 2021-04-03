namespace General.Player
{
    public abstract class State
    {
        public abstract void Handle(PlayerBase player);
    }
}