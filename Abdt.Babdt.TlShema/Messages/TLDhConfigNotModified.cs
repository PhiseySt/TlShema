using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1058912715)]
  public class TLDhConfigNotModified : TLAbsDhConfig
  {
    public override int Constructor => -1058912715;

    public byte[] Random { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Random = BytesUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.Random, bw);
    }
  }
}
