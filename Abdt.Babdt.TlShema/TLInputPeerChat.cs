using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(396093539)]
  public class TLInputPeerChat : TLAbsInputPeer
  {
    public override int Constructor => 396093539;

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
