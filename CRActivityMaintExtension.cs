using PX.Api;
using PX.Data;
using PX.Objects.CR;
using PX.Objects.EP;
using PX.SM;
using PX.SmsProvider;
using PX.SmsProvider.SM.DAC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Newtonsoft.Json;
using PX.SmsProvider.SM;

namespace TeamBeta2021
{
    public class CRActivityMaintExtension : PXGraphExtension<CRActivityMaint>
    {
        public PXSelect<SmsPluginParameter, Where<SmsPluginParameter.pluginName, Equal<Current<SmsPlugin.name>>>,
            OrderBy<Asc<SmsPluginParameter.lineNumber>>> Details;

        public PXSetup<TBetaCred> Creds;
        [InjectDependency] public IReadOnlyDictionary<string, ISmsProviderFactory> ProviderFactories { get; set; }


        public PXAction<CRActivity> tBetaInitiate;

        [PXButton]
        [PXUIField(DisplayName = "Start Video", MapEnableRights = PXCacheRights.Select,
            MapViewRights = PXCacheRights.Select)]
        public virtual IEnumerable TBetaInitiate(PXAdapter adapter)
        {
            Base.Actions.PressSave();
            CRCase myCase =
                PXSelect<CRCase, Where<CRCase.noteID, Equal<Required<CRCase.noteID>>>>.Select(Base,
                    Base.CurrentActivity.Current.RefNoteID);


            Contact mycontact =
                PXSelect<Contact, Where<Contact.contactID, Equal<Required<Contact.contactID>>>>.Select(Base,
                    myCase.ContactID ?? 0);
            if (mycontact == null)
                throw new PXException("No Contact!!!");

            //PXDatabase.SelectDataFields<>();

            string apikey = Creds.Current.Apikey;


            var srurl = "https://hackathon.acumatica.com/Beta/Frames/vnr.html?key=" + apikey + "&nid=" + Base.CurrentActivity.Current.NoteID.ToString();

            var request = new SendMessageRequest()
            {
                RecepientPhoneNbr = (mycontact.Phone1 == null) ? mycontact.Phone2 : mycontact.Phone1,
                RecepientSMSMessage = ""+ srurl
            };
            request.RecepientPhoneNbr = request.RecepientPhoneNbr.Replace("(", "");
            request.RecepientPhoneNbr = request.RecepientPhoneNbr.Replace(")", "");
            PXTrace.WriteInformation(mycontact.DisplayName + " " + request.RecepientPhoneNbr);

            try
            {
                Guid guid = Guid.Parse("A18E155A-7CBF-E911-8173-DAB1842B9396");
                var pluginParameters = SmsPluginMaint.Def[guid];
                var plugin = ProviderFactories[pluginParameters.typeName].Create(pluginParameters.parameters);
                plugin.SendMessageAsync(request, CancellationToken.None).Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            var surl = "https://hackathon.acumatica.com/Beta/Frames/vnl.html?key=" + apikey + "&nid=" +
                Base.CurrentActivity.Current.NoteID.ToString();


            throw new PXRedirectToUrlException(surl, PXBaseRedirectException.WindowMode.Same,
                string.Empty);

        }

    }
}