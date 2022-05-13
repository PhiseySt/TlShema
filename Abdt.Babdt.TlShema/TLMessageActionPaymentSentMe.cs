using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1892568281)]
  public class TLMessageActionPaymentSentMe : TLAbsMessageAction
  {
    public override int Constructor => -1892568281;

    public int Flags { get; set; }

    public string Currency { get; set; }

    public long TotalAmount { get; set; }

    public byte[] Payload { get; set; }

    public TLPaymentRequestedInfo Info { get; set; }

    public string ShippingOptionId { get; set; }

    public TLPaymentCharge Charge { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Info != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.ShippingOptionId != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Currency = StringUtil.Deserialize(br);
      this.TotalAmount = br.ReadInt64();
      this.Payload = BytesUtil.Deserialize(br);
      this.Info = (this.Flags & 1) == 0 ? (TLPaymentRequestedInfo) null : (TLPaymentRequestedInfo) ObjectUtils.DeserializeObject(br);
      this.ShippingOptionId = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Charge = (TLPaymentCharge) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Currency, bw);
      bw.Write(this.TotalAmount);
      BytesUtil.Serialize(this.Payload, bw);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.Info, bw);
      if ((this.Flags & 2) != 0)
        StringUtil.Serialize(this.ShippingOptionId, bw);
      ObjectUtils.SerializeObject((object) this.Charge, bw);
    }
  }
}
