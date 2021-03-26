namespace Lesson5.Bridge
{
    internal sealed class Enemy
    {
        private readonly IAttack _attack;
        private readonly IMove _move;

        public Enemy(IAttack attack, IMove move)
        {
            _attack = attack;
            _move = move;
        }

        public void Attack()
        {
            _attack.Attack();
        }
        
        public void Move()
        {
            _move.Move();
        }
    }
}
