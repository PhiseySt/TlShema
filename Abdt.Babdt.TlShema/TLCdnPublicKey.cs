using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-914167110)]
  public class TLCdnPublicKey : TLObject
  {
    public override int Constructor => -914167110;

    public int DcId { get; set; }

    public string PublicKey { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.DcId = br.ReadInt32();
      this.PublicKey = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.DcId);
      StringUtil.Serialize(this.PublicKey, bw);
    }
  }
}
