namespace General.Player.States
{
    public class FlyState : State
    {
        public override void Handle(PlayerBase player)
        {
            player.Animator.SetBool("Fire", false);
            player.Animator.SetBool("Freeze", false);
        }
    }
}