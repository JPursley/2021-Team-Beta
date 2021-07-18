using Newtonsoft.Json;
using PX.Common;
using PX.Data;
using PX.Data.Webhooks;
using PX.DbServices;
using PX.Objects;
using PX.Objects.CR;
using PX.Objects.IN;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using OpenTokSDK;
using System.Net.Http.Headers;
using System.Net;
using System.Text;

using Newtonsoft;

namespace TeamBeta2021
{
    public class TBetaWebhookHandler : IWebhookHandler
    {
		/*
		 *     (POST) {webhook_url}?role=[local/remote]&action=getToken 
				(GET) {webhook_url}?role=[local/remote]&action=getSession&id=[id] 
				(POST) {webhook_url}?role=[local/remote]&action=startRecording&id=[id] 
				(POST) {webhook_url}?role=[local/remote]&action=stopRecording&id=[id] 
		*/
		
		public async Task<System.Web.Http.IHttpActionResult> ProcessRequestAsync(
		  HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var _queryParameters = HttpUtility.ParseQueryString(request.RequestUri.Query);
			string action = _queryParameters.Get("action");

			switch (action)
                { 
				case "getToken":
					return await getToken(request);
			
				case "getSession":
					return await getSession(request);

				case "startRecording":
					return new OkResult(request); // startRecording(request);

				case "stopRecording":
					return new OkResult(request); //stopRecording(request);
				default:
					return new OkResult(request);
			}

		}

		public HttpResponseMessage buildResponse(System.Net.HttpStatusCode status, string content)
        {
			var response = new HttpResponseMessage( status);
			response.Content = new StringContent(content);
			response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			return response;
		}

		public class JsonTextActionResult : IHttpActionResult
		{

			public HttpRequestMessage Request { get; }

			public string JsonText { get; }

			public JsonTextActionResult(HttpRequestMessage request, string jsonText)
			{
				Request = request;
				JsonText = jsonText;
			}

			public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
			{
				return Task.FromResult(Execute());
			}

			public HttpResponseMessage Execute()
			{
				var response = this.Request.CreateResponse(HttpStatusCode.OK);
				response.Content = new StringContent(JsonText, Encoding.UTF8, "application/json");
				return response;
			}
		}

		public class InvalidHttpActionResult : IHttpActionResult
		{

			private readonly string _message;
			private readonly HttpStatusCode _statusCode;


			public InvalidHttpActionResult(HttpStatusCode statusCode, string message)
			{
				_statusCode = statusCode;
				_message = message;
			}


			public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)

			{

				HttpResponseMessage response = new HttpResponseMessage(_statusCode)
				{
					Content = new StringContent(_message)
				};

				return Task.FromResult(response);
			}
		}

		private OpenTok getOpenTok()
		{
			using (var scope = GetUserScope())
			{
				var graph = PXGraph.CreateInstance<TBetaCredSetup>();
				TBetaCred creds = graph.Creds.Select();
				return new OpenTok(Convert.ToInt32(creds.Apikey), creds.VSecret);
			}
		}

		private void saveSessionId(string id, string sessionId)
		{
			using (var scope = GetUserScope())
			{
				Guid noteID = Guid.Parse(id);

				PXDatabase.Update<CRActivity>(
					new PXDataFieldAssign<CRActivity.body>(sessionId),
					new PXDataFieldRestrict<CRActivity.noteID>(PXDbType.UniqueIdentifier, 16, noteID, PXComp.EQ)
					);
			}
		}

		private string getSessionId(string id)
		{
			using (var scope = GetUserScope())
			{
				Guid noteID = Guid.Parse(id);

				PXDataRecord rec = PXDatabase.SelectSingle<CRActivity>(
					new PXDataField<CRActivity.body>(),
					new PXDataFieldValue<CRActivity.noteID>(PXDbType.UniqueIdentifier, 16, noteID)
					);

				return rec.GetString(0);
			}
		}


		public class TokenOptions
        {
			public string sessionID { get; set; }
			public string role { get; set; }
			public string data { get; set; }
		}

		private async Task<System.Web.Http.IHttpActionResult> getToken(HttpRequestMessage request)
        {

			var _queryParameters = HttpUtility.ParseQueryString(request.RequestUri.Query);
			string client = _queryParameters.Get("role");

			var body = await request.Content.ReadAsStringAsync();

			var options = JsonConvert.DeserializeObject<TokenOptions>(body);

			var openTok = getOpenTok();
			var token = openTok.GenerateToken(options.sessionID, role: Role.PUBLISHER, data: options.data);

			return new JsonTextActionResult(request, token); ;
		}

		private async Task<System.Web.Http.IHttpActionResult> getSession(HttpRequestMessage request)
        {
			var openTok = getOpenTok();

			var _queryParameters = HttpUtility.ParseQueryString(request.RequestUri.Query);
			string client = _queryParameters.Get("role");
			string id = _queryParameters.Get("nid");

			string sessionId = null;

			switch (client)
            {
				case "local":
					// Create session, turn on automatic recording
					var session = openTok.CreateSession(mediaMode: MediaMode.ROUTED, archiveMode: ArchiveMode.ALWAYS);
					sessionId = session.Id;

					saveSessionId(id, sessionId);
					break;

				case "remote":
					sessionId = getSessionId(id);
					break;
			}

			return new JsonTextActionResult(request, sessionId);
		}

		//private string StartRecording(HttpRequestMessage request)
  //      {
		//	string noteId = System.Web.HttpContext.Current.Request.QueryString["id"];

		//	// Load the sessionID
		//	PXDataRecord rec = PXDatabase.SelectSingle<CRActivity>(
		//				new PXDataField<TBetaCRActivityExtension.sessionID>(),
		//				new PXDataFieldValue<CRActivity.noteID>(PXDbType.UniqueIdentifier, 6, id)
		//				);

		//	string sessionId = rec.GetString(0);

		//	var openTokService = new OpenTokService();
		//	var archive = openTokService.OpenTok.StartArchive(sessionId, "Archiving Video", true, true, OpenTokSDK.OutputMode.COMPOSED);

		//	return archive.Id.ToString();
		//}

		//private string StopRecording(HttpRequestMessage request)
  //      {

		//	string noteId = System.Web.HttpContext.Current.Request.QueryString["id"];
		//	var openTokService = new OpenTokService();
		//	var archive = openTokService.OpenTok.StopArchive(noteId);

		//	return archive.Id.ToString();

		//}


		/// <summary>
		/// Defines the LoginScope to be used for the WebHooks
		/// </summary>
		/// <returns></returns>
		private IDisposable GetUserScope()
		{
			//todo: For now we will use admin but we will want to throttle back to a 
			//      user with restricted access as to reduce any risk of attack.
			//      perhaps this can be configured in the Surveys Preferences/Setup page.
			var userName = "admin";
			if (PXDatabase.Companies.Length > 0)
			{
				var company = PXAccess.GetCompanyName();
				if (string.IsNullOrEmpty(company))
				{
					company = PXDatabase.Companies[0];
				}
				userName = userName + "@" + company;
			}
			return new PXLoginScope(userName);
		}
	}
}


