using Newtonsoft.Json;
using PX.Common;
using PX.Data;
using PX.Data.Webhooks;
using PX.Objects;
using PX.Objects.IN;
using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace TeamBeta2021
{
    public class TBetaWebhookHandler : IWebhookHandler
    {
		public async Task<System.Web.Http.IHttpActionResult> ProcessRequestAsync(
		  HttpRequestMessage request, CancellationToken cancellationToken)
		{
            var ok = new OkResult(request);

			return ok;
		}

	}
}