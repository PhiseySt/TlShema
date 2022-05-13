using System.IO;

namespace Abdt.Babdt.TlShema.Payments
{
  [TLObject(1342771681)]
  public class TLPaymentReceipt : TLObject
  {
    public override int Constructor => 1342771681;

    public int Flags { get; set; }

    public int Date { get; set; }

    public int BotId { get; set; }

    public TLInvoice Invoice { get; set; }

    public int ProviderId { get; set; }

    public TLPaymentRequestedInfo Info { get; set; }

    public TLShippingOption Shipping { get; set; }

    public string Currency { get; set; }

    public long TotalAmount { get; set; }

    public string CredentialsTitle { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Info != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Shipping != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Date = br.ReadInt32();
      this.BotId = br.ReadInt32();
      this.Invoice = (TLInvoice) ObjectUtils.DeserializeObject(br);
      this.ProviderId = br.ReadInt32();
      this.Info = (this.Flags & 1) == 0 ? (TLPaymentRequestedInfo) null : (TLPaymentRequestedInfo) ObjectUtils.DeserializeObject(br);
      this.Shipping = (this.Flags & 2) == 0 ? (TLShippingOption) null : (TLShippingOption) ObjectUtils.DeserializeObject(br);
      this.Currency = StringUtil.Deserialize(br);
      this.TotalAmount = br.ReadInt64();
      this.CredentialsTitle = StringUtil.Deserialize(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Date);
      bw.Write(this.BotId);
      ObjectUtils.SerializeObject((object) this.Invoice, bw);
      bw.Write(this.ProviderId);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.Info, bw);
      if ((this.Flags & 2) != 0)
        ObjectUtils.SerializeObject((object) this.Shipping, bw);
      StringUtil.Serialize(this.Currency, bw);
      bw.Write(this.TotalAmount);
      StringUtil.Serialize(this.CredentialsTitle, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
