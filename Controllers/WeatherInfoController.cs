using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WeatherManager.Models;

namespace WeatherManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherInfoController : ControllerBase
    {
        public IWeatherInfoInterface Weather { get; set; }
        public WeatherInfoController(IWeatherInfoInterface weather)
        {
            Weather = weather;
        }

        public IEnumerable<WeatherInfo> GetAll()
        {
            return Weather.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = Weather.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] WeatherInfo item)
        {
            var weatheritem = Weather.Find(item.Id);
            if (weatheritem == null)
            {
                Weather.Add(item);
            }
            else
            {
                if (item == null)
                {
                    return BadRequest();
                }
                else if (item.Id == weatheritem.Id)
                {
                    return Conflict();
                }
            }

            return CreatedAtRoute("", new { id = item.Id, temp = item.Temp, data = item.Date });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] WeatherInfo item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }
            var weatheritem = Weather.Find(id);
            if (weatheritem == null)
            {
                return NotFound();
            }
            Weather.Update(item);
            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] WeatherInfo item, int id)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var weatheritem = Weather.Find(id);
            if (weatheritem == null)
            {
                return NotFound();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var weatheritem = Weather.Find(id);
            if (weatheritem == null)
            {
                return NotFound();
            }
            Weather.Remove(id);
            return new NoContentResult();
        }
    }
}
