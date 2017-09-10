using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyService.Application.Model;
using MyService.Application.Respositories;

namespace MyService.WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IOrderRepository orderRepository = new OrderRepository();

        public IHttpActionResult Post(Order order)
        {
            this.orderRepository.Add(order);
            return this.Ok();
        }
    }
}
