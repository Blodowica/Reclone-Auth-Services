using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Reclone_Auth_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly HttpClient _httpClient;
        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("UserMicroservice");
        }

        [HttpGet("getUserService Reponse")]
        public async Task<string> Get()
        {
            var response = await _httpClient.GetAsync("/api/auth/sendUserServiceResponse");
            return await response.Content.ReadAsStringAsync();
        }



        //THIS FUNCTION CAN ALSO BE IN A DIFFERENT CONTROLLER THIS IS ONLY FOR TEST   

        [HttpGet("sendAuthServiceResponse")]
        public string sendResponse()
        {
            return "Hello from the Auth microservice";
        }
    }
}
