namespace PublicOffer.Model
{
    public class Offer : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CategoryType Category { get; set; } 
        public LocationType Location { get; set; }
        public string Price { get; set; }
        public string Link { get; set; }
        public ICollection<UserOffer> UserOffers { get; set; }
    }
}
