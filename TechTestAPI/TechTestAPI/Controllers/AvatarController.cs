namespace TechTestAPI.Controllers;

using AvatarService;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AvatarController(IHttpClientFactory httpClientFactory, IImageBuilder imageBuilder) : Controller
{
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string userIdentifier)
    {
        try
        {            
            var image = imageBuilder.GetImage(userIdentifier);
            if (image.ReturnType == "json") 
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, image.Url);
                var httpClient = httpClientFactory.CreateClient();

                var response = await httpClient.SendAsync(requestMessage);
                if (response != null && response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return Ok(result);
                }
            }
            else
            {
                return Ok(image);
            }
             
            
            return BadRequest();
        }
        catch
        {
            return StatusCode(500);
        }
    }
}
