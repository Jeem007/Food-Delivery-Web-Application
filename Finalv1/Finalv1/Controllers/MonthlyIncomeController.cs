using Finalv1.Auth;
using Finalv1BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Finalv1.Controllers
{
    [EnableCors("*", "*", "*")]
    
    public class MonthlyIncomeController : ApiController
    {
        [Logged]
        [RoleAdmin]
        [HttpGet]
        [Route("api/monthlyincomes")]
        public HttpResponseMessage AllMonthlyIncomes()
        {
            try
            {
                var data = MonthlyIncomeService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/monthlyincomes/create")]
        public HttpResponseMessage NewMonthlyIncome()
        {
            try
            {
                var data = MonthlyIncomeService.TotalIncomeofMonthCreate();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
