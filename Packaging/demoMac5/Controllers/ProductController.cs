using demoMac5.Models;
using demoMac5.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace demoMac5.Controllers
{
    public class ProductController : ApiController
    {
        public HttpResponseMessage GetAllProduct()
        {
            string errMsg = "";
            Result resData = new Result();
            ProductData stg = new ProductData();
            var ls = new List<STK>();

            stg.GetAllProduct(out ls);

            if (errMsg != "")
            {
                resData.StatusCode = (int)(StatusCodes.Error);
                resData.Messages = errMsg;
            }
            else
            {
                resData.StatusCode = (int)(StatusCodes.Succuss);
                resData.Messages = (String)EnumString.GetStringValue(StatusCodes.Succuss);
            }
            resData.Results = ls;
            return Request.CreateResponse(HttpStatusCode.OK, resData);
        }

        public HttpResponseMessage GetAllCustomer()
        {
            string errMsg = "";
            Result resData = new Result();
            CustomerData stg = new CustomerData();
            var ls = new List<DEB>();

            stg.GetAllCustomer(out ls);

            if (errMsg != "")
            {
                resData.StatusCode = (int)(StatusCodes.Error);
                resData.Messages = errMsg;
            }
            else
            {
                resData.StatusCode = (int)(StatusCodes.Succuss);
                resData.Messages = (String)EnumString.GetStringValue(StatusCodes.Succuss);
            }
            resData.Results = ls;
            return Request.CreateResponse(HttpStatusCode.OK, resData);
        }

        public HttpResponseMessage GetAllCustomerGroup()
        {
            string errMsg = "";
            Result resData = new Result();
            CustomerData stg = new CustomerData();
            var ls = new List<DEG>();

            stg.GetAllCustomerGroup(out ls);

            if (errMsg != "")
            {
                resData.StatusCode = (int)(StatusCodes.Error);
                resData.Messages = errMsg;
            }
            else
            {
                resData.StatusCode = (int)(StatusCodes.Succuss);
                resData.Messages = (String)EnumString.GetStringValue(StatusCodes.Succuss);
            }
            resData.Results = ls;
            return Request.CreateResponse(HttpStatusCode.OK, resData);
        }
    }
}