namespace SocialMediaPlatform.Domain
{
    internal class Reel : BasePost
    {
        public int durationInSeconds { get; set; }
        public Reel(int ownerUserId , string content , int durationInSeconds ) : base(ownerUserId , content)
        {
            this.durationInSeconds = durationInSeconds;
        }
    }
}
