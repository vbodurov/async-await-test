using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace AsyncTestSite.Controllers
{
    public class AsyncPerfController : ApiController
    {
        [Route("api/async")]
        [HttpGet]
        public async Task<string> Get()
        {
            var sw = Stopwatch.StartNew();

            var r =
                await new WebClient()
                    .DownloadStringTaskAsync("http://ma.youvisio.com/api/version?os=android");
            
            sw.Stop();
            r += " ms:" + sw.ElapsedMilliseconds;
            return r;
        }
    }
}