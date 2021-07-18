using System;
using System.Collections;
using System.Collections.Generic;
using PX.SM;
using PX.Data;
using PX.Data.Automation;


namespace TeamBeta2021
{
    using System;
    using PX.Data;
    using PX.Objects.CR;

    [System.SerializableAttribute()]
    [PXTable(typeof(CRActivity.noteID), IsOptional = false)]
    public sealed class TBetaCRActivityExtension : PXCacheExtension<CRActivity>
    {
        public static bool IsActive() => true;
        #region CreatedAt
        [PXDBLong()]
        [PXUIField(DisplayName = "Created At")]
        public  long? CreatedAt { get; set; }
        public abstract class createdAt : PX.Data.BQL.BqlLong.Field<createdAt> { }
        #endregion

        #region Duration
        [PXDBInt()]
        [PXUIField(DisplayName = "Duration")]
        public  int? Duration { get; set; }
        public abstract class duration : PX.Data.BQL.BqlInt.Field<duration> { }
        #endregion

        #region Resolution
        [PXDBString(20, InputMask = "")]
        [PXUIField(DisplayName = "Resolution")]
        public  string Resolution { get; set; }
        public abstract class resolution : PX.Data.BQL.BqlString.Field<resolution> { }
        #endregion

        #region Url
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Url")]
        public  string Url { get; set; }
        public abstract class url : PX.Data.BQL.BqlString.Field<url> { }
        #endregion

        #region SessionID
        [PXDBString(80, InputMask = "")]
        [PXUIField(DisplayName = "Session ID")]
        public  string SessionID { get; set; }
        public abstract class sessionID : PX.Data.BQL.BqlString.Field<sessionID> { }
        #endregion

        #region Hosttoken
        [PXDBString(InputMask = "")]
        [PXUIField(DisplayName = "Hosttoken")]
        public  string Hosttoken { get; set; }
        public abstract class hosttoken : PX.Data.BQL.BqlString.Field<hosttoken> { }
        #endregion

        #region Participanttoken
        [PXDBString(InputMask = "")]
        [PXUIField(DisplayName = "Participanttoken")]
        public  string Participanttoken { get; set; }
        public abstract class participanttoken : PX.Data.BQL.BqlString.Field<participanttoken> { }
        #endregion
        #region TBetaLastModifiedDateTime
        
        [PXDBLastModifiedDateTime()]
        [PXUIField(DisplayName = "TBeta Last Modified Date Time")]
        public  DateTime? TBetaLastModifiedDateTime { get; set; }
        public abstract class tBetaLastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<tBetaLastModifiedDateTime> { }
        #endregion
    }
}