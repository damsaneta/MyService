using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyService.Application.Respositories;

namespace MyService.WebApi.Controllers
{
    public class PromotionsController : ApiController
    {
        private readonly IPromotionRepository promotionRepository = new PromotionRepository();

        public IHttpActionResult Get()
        {
            var result = this.promotionRepository.GetAll();
            return this.Ok(result);
        }
    }
}
