namespace PublicOffer.Model
{
    public class UserOffer
    {
        public Guid UserId { get; set; }
        public Guid OfferId { get; set; }
        public User User { get; set; }
        public Offer Offer { get; set; }
    }
}
