using Finalv1.Auth;
using Finalv1BLL.ModelDTOs;
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
    public class AdminController : ApiController
    {
      
        [HttpPost]
        [Route("api/Admin/create")]
        public HttpResponseMessage CreateAdmin(AdminDTOs adminDTOs)
        {
            try
            {
                var data = AdminService.Create(adminDTOs);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }
       
        [Logged]
        [RoleAdmin]

        [HttpGet]
        [Route("api/Admin/{id}")]
        public HttpResponseMessage FindAdmin(int id)
        {
            try
            {
                var data = AdminService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

        [Logged]
        [RoleAdmin]
        [HttpPost]
        [Route("api/admin/update")]
        public HttpResponseMessage UpdateAdmin(AdminDTOs adminDTOs)
        {
            try
            {
                var data = AdminService.Update(adminDTOs);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }
    }
}
