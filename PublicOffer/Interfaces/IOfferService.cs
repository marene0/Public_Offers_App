using Azure;
using PublicOffer.Model;
using PublicOffer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace PublicOffer.Interfaces
{
    public interface IOfferService
    {
        Task<string> GetTitleAsync (string url);
        Task<string> GetDescriptionAsync(string url);
        Task<string> GetPriceAsync(string url);
        Task<ActionResult<List<GetOfferByTypeDTO>>> GetAllInformationAsync(string url);
    }
}
