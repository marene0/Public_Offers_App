using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicOffer.Interfaces;
using PublicOffer.Model;
using PublicOffer.DTO;
using HtmlAgilityPack;
using System.Threading.Tasks;

namespace PublicOffer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly HtmlWeb _web;

        public OfferController(IOfferService offerService, HtmlWeb web)
        {
            _offerService = offerService;
            _web = web;
        }

        [HttpGet("title")]
        public async Task<string> GetTitleAsync(string url)
        {
            return await _offerService.GetTitleAsync(url);
        }


        //[HttpGet("name")]
        //public async Task<string> GetNameAsync(string url)
        //{
        //    return await _jobService.GetNameAsync(url);
        //}

        [HttpGet("description")]
        public async Task<string> GetDescriptionAsync(string url)
        {
            return await _offerService.GetDescriptionAsync(url);
        }

        //[HttpGet("price")]
        //public async Task<string> GetPriceAsync(string url)
        //{
        //    return await _jobService.GetPriceAsync(url);
        //}
    }
}
