using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGame.Contracts;
using MyGame.Services;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using MyGame.Models;
using Microsoft.AspNetCore.Authorization;

namespace MyGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {

        private readonly ICharacterService service;
        public CharactersController(ICharacterService _service)
        {
            service = _service;
        }

        [Route("player")]
        [HttpGet]
        public async Task<IActionResult> Player(int id)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new
            CamelCasePropertyNamesContractResolver();
            var result = await service.Player(id);
            return Ok(JsonConvert.SerializeObject(result, serializerSettings));
        }

        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new
            CamelCasePropertyNamesContractResolver();
            var result = await service.All();
            return Ok(JsonConvert.SerializeObject(result, serializerSettings));
        }
        [Route("add")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddChar(CharacterViewModel character)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new
            CamelCasePropertyNamesContractResolver();
            var result = await service.AddChar(character);
            return Ok(JsonConvert.SerializeObject(result, serializerSettings));
        }

        [Route("edit")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditChar(int id, CharacterViewModel? character)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new
            CamelCasePropertyNamesContractResolver();
            var result = await service.EditChar(id, character);
            return Ok(JsonConvert.SerializeObject(result, serializerSettings));
        }
    }
}
