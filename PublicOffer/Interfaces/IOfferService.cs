using Azure;
using PublicOffer.Model;
using PublicOffer.DTO;

namespace PublicOffer.Interfaces
{
    public interface IOfferService
    {
        Task<string> GetTitleAsync (string url);
        Task<string> GetDescriptionAsync(string url);
    }
}
