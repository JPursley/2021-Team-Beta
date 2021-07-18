using System;
using PX.Data;

namespace TeamBeta2021
{
  [Serializable]
  [PXCacheName("TBetaLog")]
  public class TBetaLog : IBqlTable
  {
    #region Logid
    [PXDBIdentity(IsKey = true)]
    public virtual int? Logid { get; set; }
    public abstract class logid : PX.Data.BQL.BqlInt.Field<logid> { }
    #endregion

    #region ActionCode
    [PXDBString(150, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Action Code")]
    public virtual string ActionCode { get; set; }
    public abstract class actionCode : PX.Data.BQL.BqlString.Field<actionCode> { }
    #endregion

    #region Accesstoken
    [PXDBString(1500, InputMask = "")]
    [PXUIField(DisplayName = "Accesstoken")]
    public virtual string Accesstoken { get; set; }
    public abstract class accesstoken : PX.Data.BQL.BqlString.Field<accesstoken> { }
    #endregion

    #region TokenType
    [PXDBString(10, InputMask = "")]
    [PXUIField(DisplayName = "Token Type")]
    public virtual string TokenType { get; set; }
    public abstract class tokenType : PX.Data.BQL.BqlString.Field<tokenType> { }
    #endregion

    #region ConnectSuccess
    [PXDBBool()]
    [PXUIField(DisplayName = "Connect Success")]
    public virtual bool? ConnectSuccess { get; set; }
    public abstract class connectSuccess : PX.Data.BQL.BqlBool.Field<connectSuccess> { }
    #endregion

    #region Casecd
    [PXDBString(10, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Casecd")]
    public virtual string Casecd { get; set; }
    public abstract class casecd : PX.Data.BQL.BqlString.Field<casecd> { }
    #endregion

    #region CustomerID
    [PXDBInt()]
    [PXUIField(DisplayName = "Customer ID")]
    public virtual int? CustomerID { get; set; }
    public abstract class customerID : PX.Data.BQL.BqlInt.Field<customerID> { }
    #endregion

    #region ContractID
    [PXDBInt()]
    [PXUIField(DisplayName = "Contract ID")]
    public virtual int? ContractID { get; set; }
    public abstract class contractID : PX.Data.BQL.BqlInt.Field<contractID> { }
    #endregion

    #region LocationID
    [PXDBInt()]
    [PXUIField(DisplayName = "Location ID")]
    public virtual int? LocationID { get; set; }
    public abstract class locationID : PX.Data.BQL.BqlInt.Field<locationID> { }
    #endregion

    #region RouteID
    [PXDBInt()]
    [PXUIField(DisplayName = "Route ID")]
    public virtual int? RouteID { get; set; }
    public abstract class routeID : PX.Data.BQL.BqlInt.Field<routeID> { }
    #endregion

    #region Error
    [PXDBString(100, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Error")]
    public virtual string Error { get; set; }
    public abstract class error : PX.Data.BQL.BqlString.Field<error> { }
    #endregion

    #region Duration
    [PXDBLong()]
    [PXUIField(DisplayName = "Duration")]
    public virtual long? Duration { get; set; }
    public abstract class duration : PX.Data.BQL.BqlLong.Field<duration> { }
    #endregion

    #region RefNoteID
    [PXDBGuid()]
    [PXUIField(DisplayName = "Ref Note ID")]
    public virtual Guid? RefNoteID { get; set; }
    public abstract class refNoteID : PX.Data.BQL.BqlGuid.Field<refNoteID> { }
    #endregion

    #region CreatedByID
    [PXDBCreatedByID()]
    public virtual Guid? CreatedByID { get; set; }
    public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
    #endregion

    #region CreatedByScreenID
    [PXDBCreatedByScreenID()]
    public virtual string CreatedByScreenID { get; set; }
    public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
    #endregion

    #region CreatedDateTime
    [PXDBCreatedDateTime()]
    public virtual DateTime? CreatedDateTime { get; set; }
    public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
    #endregion

    #region LastModifiedByID
    [PXDBLastModifiedByID()]
    public virtual Guid? LastModifiedByID { get; set; }
    public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
    #endregion

    #region LastModifiedByScreenID
    [PXDBLastModifiedByScreenID()]
    public virtual string LastModifiedByScreenID { get; set; }
    public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
    #endregion

    #region LastModifiedDateTime
    [PXDBLastModifiedDateTime()]
    public virtual DateTime? LastModifiedDateTime { get; set; }
    public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
    #endregion

    #region Tstamp
    [PXDBTimestamp()]
    [PXUIField(DisplayName = "Tstamp")]
    public virtual byte[] Tstamp { get; set; }
    public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
    #endregion

    #region Noteid
    [PXNote()]
    public virtual Guid? Noteid { get; set; }
    public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
    #endregion
  }
}