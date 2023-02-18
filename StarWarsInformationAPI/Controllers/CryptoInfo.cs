using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;

namespace StarWarsInformationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoInfo : ControllerBase
    {
      
        
    
    
    
    

        [HttpGet(Name = "GetCryptoInfo")]
        public ActionResult<List<Commodities>> Get()
            {
                HttpClient client = new HttpClient();
             dynamic? obj = new ExpandoObject();
            string result;

            try
            {
                HttpResponseMessage response = client.GetAsync("https://api.wazirx.com/sapi/v1/tickers/24hr").Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            var list = JsonConvert.DeserializeObject<List<Commodities>>(result);
                return Ok(list);
        }
        
    
    }

    public class Commodities
    {
        public string symbol { get; set; }
        public string baseAsset { get; set; }
        public string quoteAsset { get; set; }
        public string openPrice { get; set; }
        public string lowPrice { get; set; }
        public string highPrice { get; set; }
        public string lastPrice { get; set; }
        public string volume { get; set; }
        public string bidPrice { get; set; }
        public string at { get; set; }


    }
    
}