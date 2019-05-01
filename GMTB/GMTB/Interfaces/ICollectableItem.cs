namespace GMTB.Interfaces
{ 
    /// <summary>
    /// Interface for a collidable Item
    /// </summary>
    public interface ICollectableItem
    {
        /// <summary>
        /// Set the door to unlock
        /// </summary>
        /// <param name="_target">Door to unlock</param>
        void SetTarget(ILockedDoor _target);
    }
}