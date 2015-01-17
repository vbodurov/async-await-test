using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.SessionState;

namespace AsyncTestSite.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class AsyncPerfController : ApiController
    {
        [System.Web.Http.Route("api/async")]
        [System.Web.Http.HttpGet]
        public async Task<string> Get()
        {
            var sw = Stopwatch.StartNew();

            var r =
                await new WebClient()
                    .DownloadStringTaskAsync("http://ma.youvisio.com/api/fake");
            
            sw.Stop();
            r += " ms:" + sw.ElapsedMilliseconds;
            return r;
        }
    }
}