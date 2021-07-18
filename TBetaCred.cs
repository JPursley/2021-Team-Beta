using System;
using PX.Data;

namespace TeamBeta2021
{
  [Serializable]
  [PXCacheName("TBetaCred")]
  public class TBetaCred : IBqlTable
  {
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

    #region Apikey
    [PXDBString(25, InputMask = "")]
    [PXUIField(DisplayName = "Apikey")]
    public virtual string Apikey { get; set; }
    public abstract class apikey : PX.Data.BQL.BqlString.Field<apikey> { }
    #endregion

    #region VSecret
    [PXDBString(125, InputMask = "")]
    
    [PXUIField(DisplayName = "Secret")]
    public virtual string VSecret { get; set; }
    public abstract class vSecret : PX.Data.BQL.BqlString.Field<vSecret> { }
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