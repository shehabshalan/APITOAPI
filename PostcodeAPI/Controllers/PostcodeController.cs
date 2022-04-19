using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.IO;
namespace PostcodeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostcodeController : ControllerBase
{

    private readonly IHttpClientFactory _httpClientFactory;

    public PostcodeController(IHttpClientFactory httpClientFactory)
    {

        _httpClientFactory = httpClientFactory;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<PostCode>> GetPostcodeById(int id)
    {
        var URL = $"https://localhost:7034/PostcodeSource/{id}";
        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync(URL);
        if (!response.IsSuccessStatusCode)
        {
            return NotFound("Postcode not found");
        }
        var responeContent = await response.Content.ReadAsStringAsync();
        var resultToClass = JsonConvert.DeserializeObject<PostCode>(responeContent);
        return resultToClass;
    }
    [HttpGet]
    public async Task<ActionResult<List<PostCode>>> GetPostcodes()
    {
        var URL = "https://localhost:7034/PostcodeSource";
        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync(URL);
        if (!response.IsSuccessStatusCode)
        {
            return NotFound("Postcode not found");
        }
        var responeContent = await response.Content.ReadAsStringAsync();
        var resultToClass = JsonConvert.DeserializeObject<List<PostCode>>(responeContent);
        return Ok(resultToClass);
    }
    [HttpPost]
    public async Task<ActionResult<PostCode>> CreatePostcode(PostCode request)
    {
        var URL = "https://localhost:7034/PostcodeSource";
        var httpClient = _httpClientFactory.CreateClient();
        var newPost = new PostCode { Id = request.Id, Code = request.Code, Country = request.Country };
        var requestContent = await httpClient.PostAsJsonAsync(URL, newPost);
        if (!requestContent.IsSuccessStatusCode)
            return BadRequest(requestContent);
        var responeContent = await requestContent.Content.ReadAsStringAsync();

        return Ok(responeContent);
    }
    [HttpPut]
    public async Task<ActionResult<PostCode>> UpdatePostcode(PostCode request)
    {
        var URL = "https://localhost:7034/PostcodeSource";
        var httpClient = _httpClientFactory.CreateClient();
        var requestContent = await httpClient.PutAsJsonAsync(URL, request);
        if (!requestContent.IsSuccessStatusCode)
            return BadRequest(requestContent);
        var responeContent = await requestContent.Content.ReadAsStringAsync();

        return Ok(responeContent);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePostcode(int id)
    {
        var URL = $"https://localhost:7034/PostcodeSource/{id}";
        var httpClient = _httpClientFactory.CreateClient();
        var requestContent = await httpClient.DeleteAsync(URL);
        if (!requestContent.IsSuccessStatusCode)
            return BadRequest(requestContent);
        var responeContent = await requestContent.Content.ReadAsStringAsync();

        return Ok(responeContent);
    }
}