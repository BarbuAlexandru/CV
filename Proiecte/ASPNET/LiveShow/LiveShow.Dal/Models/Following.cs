using System;

namespace LiveShow.Dal.Models
{
    // Alternatively, this class could be called Relationship.
    public class Following
    {
        public Guid FollowerId { get; set; }

        public Guid FolloweeId { get; set; }

        public User Follower { get; set; }

        public User Followee { get; set; }
    }
}