using System.Diagnostics;
using System.Net;
using System.Web.Http;

namespace AsyncTestSite.Controllers
{
    public class SyncPerfController : ApiController
    {

        [Route("api/sync")]
        [HttpGet]
        public string Get()
        {
            var sw = Stopwatch.StartNew();

            var r = 
                new WebClient()
                    .DownloadString("http://ma.youvisio.com/api/fake");

            sw.Stop();
            r += " ms:" + sw.ElapsedMilliseconds;
            return r; 
        }

    }
}
