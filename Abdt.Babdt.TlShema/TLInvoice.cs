using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1022713000)]
  public class TLInvoice : TLObject
  {
    public override int Constructor => -1022713000;

    public int Flags { get; set; }

    public bool Test { get; set; }

    public bool NameRequested { get; set; }

    public bool PhoneRequested { get; set; }

    public bool EmailRequested { get; set; }

    public bool ShippingAddressRequested { get; set; }

    public bool Flexible { get; set; }

    public string Currency { get; set; }

    public TLVector<TLLabeledPrice> Prices { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Test ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.NameRequested ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.PhoneRequested ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.EmailRequested ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.ShippingAddressRequested ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.Flexible ? this.Flags | 32 : this.Flags & -33;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Test = (uint) (this.Flags & 1) > 0U;
      this.NameRequested = (uint) (this.Flags & 2) > 0U;
      this.PhoneRequested = (uint) (this.Flags & 4) > 0U;
      this.EmailRequested = (uint) (this.Flags & 8) > 0U;
      this.ShippingAddressRequested = (uint) (this.Flags & 16) > 0U;
      this.Flexible = (uint) (this.Flags & 32) > 0U;
      this.Currency = StringUtil.Deserialize(br);
      this.Prices = ObjectUtils.DeserializeVector<TLLabeledPrice>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Currency, bw);
      ObjectUtils.SerializeObject((object) this.Prices, bw);
    }
  }
}
