using System.Diagnostics;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.SessionState;

namespace AsyncTestSite.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class SyncPerfController : ApiController
    {

        [System.Web.Http.Route("api/sync")]
        [System.Web.Http.HttpGet]
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
