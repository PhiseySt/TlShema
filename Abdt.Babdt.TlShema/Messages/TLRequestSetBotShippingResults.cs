using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-436833542)]
  public class TLRequestSetBotShippingResults : TLMethod
  {
    public override int Constructor => -436833542;

    public int Flags { get; set; }

    public long QueryId { get; set; }

    public string Error { get; set; }

    public TLVector<TLShippingOption> ShippingOptions { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Error != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.ShippingOptions != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.QueryId = br.ReadInt64();
      this.Error = (this.Flags & 1) == 0 ? (string) null : StringUtil.Deserialize(br);
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
      bw.Write(this.QueryId);
      if ((this.Flags & 1) != 0)
        StringUtil.Serialize(this.Error, bw);
      if ((this.Flags & 2) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.ShippingOptions, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
