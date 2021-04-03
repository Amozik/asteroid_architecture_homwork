namespace General.Player.States
{
    public class FreezeState : State
    {
        public override void Handle(PlayerBase player)
        {
            player.Animator.SetBool("Freeze", true);

            player.State = new FlyState();
        }
    }
}