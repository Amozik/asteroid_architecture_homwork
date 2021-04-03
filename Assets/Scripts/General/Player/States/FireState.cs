namespace General.Player.States
{
    public class FireState : State
    {
        public override void Handle(PlayerBase player)
        {
            player.Animator.SetBool("Fire", true);
            
            player.State = new FlyState();
        }
    }
}