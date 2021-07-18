using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using OpenTokSDK;
using PX.SM;
using PX.Data;
using PX.Objects.CR;

namespace TeamBeta2021
{
    public class TBetaChat : PXGraph<TBetaChat>
    {

        public PXSelect<CRActivity> Activities;
        public PXSetup<TBetaCred> Settings;

        public void  OpenTokService()
        {
            TBetaCred mysettings = Settings.Select();
            string apiKey = mysettings.Apikey;
            string apiSecret = mysettings.VSecret;


                if (string.IsNullOrEmpty(apiKey) || apiSecret == null)
                {
                    Console.WriteLine(
                        "The OpenTok API Key and API Secret were not set in the application configuration. " +
                        "Set the values in App.config and try again. (apiKey = {0}, apiSecret = {1})", apiKey, apiSecret);
                    Console.ReadLine();
                    Environment.Exit(-1);
                }
            

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //this.OpenTok = new OpenTok(apiKey.ToString(), apiSecret);

            //this.Session = this.OpenTok.CreateSession();
        }
    }
}