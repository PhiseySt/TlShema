using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-2074799289)]
  public class TLMessageMediaInvoice : TLAbsMessageMedia
  {
    public override int Constructor => -2074799289;

    public int Flags { get; set; }

    public bool ShippingAddressRequested { get; set; }

    public bool Test { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public TLWebDocument Photo { get; set; }

    public int? ReceiptMsgId { get; set; }

    public string Currency { get; set; }

    public long TotalAmount { get; set; }

    public string StartParam { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.ShippingAddressRequested ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Test ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Photo != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.ReceiptMsgId.HasValue ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ShippingAddressRequested = (uint) (this.Flags & 2) > 0U;
      this.Test = (uint) (this.Flags & 8) > 0U;
      this.Title = StringUtil.Deserialize(br);
      this.Description = StringUtil.Deserialize(br);
      this.Photo = (this.Flags & 1) == 0 ? (TLWebDocument) null : (TLWebDocument) ObjectUtils.DeserializeObject(br);
      this.ReceiptMsgId = (this.Flags & 4) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Currency = StringUtil.Deserialize(br);
      this.TotalAmount = br.ReadInt64();
      this.StartParam = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Title, bw);
      StringUtil.Serialize(this.Description, bw);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.Photo, bw);
      if ((this.Flags & 4) != 0)
        bw.Write(this.ReceiptMsgId.Value);
      StringUtil.Serialize(this.Currency, bw);
      bw.Write(this.TotalAmount);
      StringUtil.Serialize(this.StartParam, bw);
    }
  }
}
