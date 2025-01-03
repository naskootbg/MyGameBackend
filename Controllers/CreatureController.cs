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

        [Route("enemies")]
        [HttpGet]
        public JsonResult AllCreatures()

        {

            var jsonData = creatureService.AllCreatures().Where(t => t.Id > 0).ToArray();


            return new JsonResult(jsonData);
        }

        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new
            CamelCasePropertyNamesContractResolver();
            var result = await creatureService.All();
            return Ok(JsonConvert.SerializeObject(result, serializerSettings));
        }
    }
}
