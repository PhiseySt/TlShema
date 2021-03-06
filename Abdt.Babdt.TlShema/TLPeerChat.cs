using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1160714821)]
  public class TLPeerChat : TLAbsPeer
  {
    public override int Constructor => -1160714821;

    public int ChatId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.ChatId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
    }
  }
}
