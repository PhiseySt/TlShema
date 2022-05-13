using System.IO;

namespace Abdt.Babdt.TlShema.Payments
{
  [TLObject(730364339)]
  public class TLRequestSendPaymentForm : TLMethod
  {
    public override int Constructor => 730364339;

    public int Flags { get; set; }

    public int MsgId { get; set; }

    public string RequestedInfoId { get; set; }

    public string ShippingOptionId { get; set; }

    public TLAbsInputPaymentCredentials Credentials { get; set; }

    public TLAbsPaymentResult Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.RequestedInfoId != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.ShippingOptionId != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.MsgId = br.ReadInt32();
      this.RequestedInfoId = (this.Flags & 1) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.ShippingOptionId = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Credentials = (TLAbsInputPaymentCredentials) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.MsgId);
      if ((this.Flags & 1) != 0)
        StringUtil.Serialize(this.RequestedInfoId, bw);
      if ((this.Flags & 2) != 0)
        StringUtil.Serialize(this.ShippingOptionId, bw);
      ObjectUtils.SerializeObject((object) this.Credentials, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsPaymentResult) ObjectUtils.DeserializeObject(br);
  }
}
