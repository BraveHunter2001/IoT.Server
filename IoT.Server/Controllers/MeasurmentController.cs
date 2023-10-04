using IoT.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace IoT.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MeasurmentController : ControllerBase
    {
        private static List<Measurement> measurements = new();
        const int len_copasity = 10;

        [HttpPost]
        public IActionResult Add([FromBody] Measurement meas) 
        {
            measurements.Add(meas);
            if (measurements.Count > len_copasity) measurements.RemoveAt(0);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(measurements);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                aX = measurements.Sum(m=>m.aX) / measurements.Count,
                aY = measurements.Sum(m => m.aY) / measurements.Count,
                aZ = measurements.Sum(m => m.aZ) / measurements.Count,

                tmp = Math.Round(measurements.Sum(m => m.tmp) / measurements.Count,2),

                gX = measurements.Sum(m => m.gX) / measurements.Count,
                gY = measurements.Sum(m => m.gY) / measurements.Count,
                gZ = measurements.Sum(m => m.aZ) / measurements.Count,
            });
        }
    }
}
