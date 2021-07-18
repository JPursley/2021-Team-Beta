using System;
using PX.Data;
using PX.Objects.CR;

namespace TeamBeta2021
{
  public class TBetaCredSetup : PXGraph<TBetaCredSetup>
  {

    public PXSelect<TBetaCred> Creds;
    public PXSave<TBetaCred> Save;
    public PXCancel<TBetaCred> Cancel;

    public PXSelectReadonly<CRActivity,Where<CRActivity.type,Equal<TBetaVideo>>> Log;

    public class TBetaVideo: PX.Data.BQL.BqlString.Constant<TBetaVideo>
    {
        public TBetaVideo() : base("P") {; }
    }

  }
}