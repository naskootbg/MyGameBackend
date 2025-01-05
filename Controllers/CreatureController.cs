using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGame.Contracts;
using MyGame.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace MyGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatureController : ControllerBase
    {
        private readonly ICreatureService creatureService;
        public CreatureController(ICreatureService _creatureService)
        {
            creatureService = _creatureService;
        }

        

        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> All(int limit = 0 , int start = 0)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new
            CamelCasePropertyNamesContractResolver();
            var result = await creatureService.All(limit, start);
            return Ok(JsonConvert.SerializeObject(result, serializerSettings));
        }
    }
}
