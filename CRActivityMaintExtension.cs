using System;
using System.Collections;
using System.Collections.Generic;
using PX.SM;
using PX.Data;
using PX.Objects.EP;
using PX.Objects.CR;

namespace TeamBeta2021
{
    public class CRActivityMaintExtension : PXGraphExtension<CRActivityMaint>
    {
        public PXAction<CRActivity> tBetaInitiate;

        [PXButton]
        [PXUIField(DisplayName = "Start Video", MapEnableRights = PXCacheRights.Select,
            MapViewRights = PXCacheRights.Select)]
        public virtual IEnumerable TBetaInitiate(PXAdapter adapter)
        {
            throw new PXRedirectToUrlException("http://www.SPScommerce.com",PXBaseRedirectException.WindowMode.Same,string.Empty);
            TBetaChat docentry = PXGraph.CreateInstance<TBetaChat>();
            //docentry.Document.Current = docentry.Document.Search<SOInvoice.refNbr>(Invoices.Current.ARInvoiceNbr);
            //throw new PXRedirectRequiredException(docentry, true, null);
        }
    }
}