using System.IO;

namespace Abdt.Babdt.TlShema.Payments
{
  [TLObject(-784000893)]
  public class TLValidatedRequestedInfo : TLObject
  {
    public override int Constructor => -784000893;

    public int Flags { get; set; }

    public string Id { get; set; }

    public TLVector<TLShippingOption> ShippingOptions { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Id != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.ShippingOptions != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Id = (this.Flags & 1) == 0 ? (string) null : StringUtil.Deserialize(br);
      if ((this.Flags & 2) != 0)
        this.ShippingOptions = ObjectUtils.DeserializeVector<TLShippingOption>(br);
      else
        this.ShippingOptions = (TLVector<TLShippingOption>) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) != 0)
        StringUtil.Serialize(this.Id, bw);
      if ((this.Flags & 2) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.ShippingOptions, bw);
    }
  }
}
