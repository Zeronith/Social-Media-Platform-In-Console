using SocialMediaPlatform.Helper;

namespace SocialMediaPlatform.Domain
{
    /// <summary>
    /// Reaction төрөл.
    /// Хэрэглэгч пост дээр өгч болох reaction-ийн enum тодорхойлолт.
    /// </summary>
    public enum ReactionType
    {
        /// <summary>Like reaction.</summary>
        LIKE,

        /// <summary>Love reaction.</summary>
        LOVE,

        /// <summary>Haha reaction.</summary>
        HAHA,

        /// <summary>Care reaction.</summary>
        CARE,

        /// <summary>Wow reaction.</summary>
        WOW,

        /// <summary>Sad reaction.</summary>
        SAD,

        /// <summary>Angry reaction.</summary>
        ANGRY
    }

    /// <summary>
    /// Reaction entity.
    /// Хэрэглэгч тодорхой пост дээр reaction өгсөн мэдээллийг илэрхийлнэ.
    /// </summary>
    internal class Reaction
    {
        /// <summary>
        /// Integer → ReactionType mapping.
        /// Console input (1–7) → ReactionType хөрвүүлэх зориулалттай.
        /// </summary>
        public static Dictionary<int, ReactionType> IntToReaction = new Dictionary<int, ReactionType>
        {
            {1, ReactionType.LIKE},
            {2, ReactionType.LOVE},
            {3, ReactionType.HAHA},
            {4, ReactionType.CARE},
            {5, ReactionType.WOW},
            {6, ReactionType.SAD},
            {7, ReactionType.ANGRY},
        };

        /// <summary>
        /// Constructor.
        /// Reaction entity үүсгэнэ.
        /// Id автоматаар үүснэ.
        /// CreatedAt автоматаар тохируулагдана.
        /// </summary>
        /// <param name="ownerId">Reaction өгсөн хэрэглэгчийн Id.</param>
        /// <param name="postId">Reaction өгсөн постын Id.</param>
        /// <param name="type">Reaction төрөл.</param>
        public Reaction(int ownerId, int postId, ReactionType type)
        {
            Id = IdGenerator.NextId();
            OwnerId = ownerId;
            PostId = postId;
            Type = type;
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Reaction unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Reaction өгсөн хэрэглэгчийн Id.
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Reaction өгсөн постын Id.
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Reaction төрөл.
        /// </summary>
        public ReactionType Type { get; set; }

        /// <summary>
        /// Reaction үүссэн цаг.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}