using PublicOffer.Data;
using PublicOffer.DTO;
using PublicOffer.Interfaces;
using HtmlAgilityPack;
using PublicOffer.Controllers;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Mvc;

namespace PublicOffer.Service
{
    public class OfferService : IOfferService
    {
        private readonly DataContext _context;
        private readonly HtmlWeb _web;

        public OfferService(DataContext context, HtmlWeb web)
        {
            _context = context;
            _web = web;
        }

        public async Task<string> GetTitleAsync(string url)
        {
            try
            {
                var document = await _web.LoadFromWebAsync(url);

                var titleNode = document.DocumentNode.SelectSingleNode("//title");

                if (titleNode != null)
                {
                    return titleNode.InnerText.Trim();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<string> GetDescriptionAsync(string url)
        {
            try
            {
                var document = await _web.LoadFromWebAsync(url);

                var titleNode = document.DocumentNode.SelectSingleNode("//*[@id=\"container\"]/div[2]/div/div[2]/div[1]/div/div[4]/div[2]/p");

                if (titleNode != null)
                {
                    return titleNode.InnerText.Trim();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> GetPriceAsync(string url)
        {
            try
            {
                var document = await _web.LoadFromWebAsync(url);

                var titleNode = document.DocumentNode.SelectSingleNode("//span[@class='salary']");

                if (titleNode != null)
                {
                    return titleNode.InnerText.Trim();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ActionResult<List<GetAllInformationOfferDTO>>> GetAllInformationAsync(string url)
        {
            try
            {
                var document = await _web.LoadFromWebAsync(url);

                var titleNode = document.DocumentNode.SelectSingleNode("//title");

                var descriptionNode = document.DocumentNode.SelectSingleNode("//*[@id=\"container\"]/div[2]/div/div[2]/div[1]/div/div[4]/div[2]/p");

                var salaryNode = document.DocumentNode.SelectSingleNode("//span[@class='salary']");

                var getOfferByTypeDTO = new GetAllInformationOfferDTO
                {
                    Title = titleNode.InnerText,
                    Description = descriptionNode.InnerText,
                    Price = salaryNode.InnerText,
                };

                if (titleNode != null && descriptionNode != null && salaryNode != null)
                {
                    var result = new List<GetAllInformationOfferDTO> { getOfferByTypeDTO };
                    return result;
                }
                else
                {
                    return new List<GetAllInformationOfferDTO>();
                }
            }
            catch (Exception ex)
            {
                return new List<GetAllInformationOfferDTO>();
            }
        }




    }

}
