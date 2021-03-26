namespace General.Player
{
    public sealed class LockedWeapon
    {
        public bool IsLocked { get; set; }
    
        public LockedWeapon(bool isLocked)
        {
            IsLocked = isLocked;
        }
    }
}