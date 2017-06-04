using GlammyStore.Service;
using GlammyStore.Web.Infrastructure.Core;
using System.Web.Http;
using System.Net.Http;
using GlammyStore.Web.Models;
using System.Linq;
using GlammyStore.Web.App_Start;
using System.Net;

namespace GlammyStore.Web.API
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        private IErrorService _errorService;
        private IOrderService _orderService;
        private IProductService _productService;
        private ApplicationUserManager _userManager;
        private IFeedbackService _feedbackService;

        public HomeController(IErrorService errorService,
            IOrderService orderService, IProductService productService,
            ApplicationUserManager userManager, IFeedbackService feedbackService)
            : base(errorService)
        {
            _errorService = errorService;
            _orderService = orderService;
            _productService = productService;
            _userManager = userManager;
            _feedbackService = feedbackService;
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Xin chào thành viên GlammyStore";
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("gettotalitem")]
        public HttpResponseMessage GetItemCount(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var dashBoardVm = new DashBoardViewModel()
                {
                    TotalProducts = _productService.GetAll().Count(),
                    TotalUsers = _userManager.Users.Count(),
                    TotalOrders = _orderService.GetAll("").Count(),
                    TotalFeedbacks = _feedbackService.GetAll("").Count()
                };
                response = request.CreateResponse(HttpStatusCode.OK, dashBoardVm);
                return response;
            });
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("getlatestusers")]
        public HttpResponseMessage GetLatestUsers(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var users = _userManager.Users.OrderByDescending(x => x.CreatedDate).Take(8);
                response = request.CreateResponse(HttpStatusCode.OK, users);
                return response;
            });
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("getlatestproducts")]
        public HttpResponseMessage GetLatestProducts(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var products = _productService.GetAll().OrderByDescending(x => x.CreatedDate).Take(5);
                response = request.CreateResponse(HttpStatusCode.OK, products);
                return response;
            });
        }

    }
}