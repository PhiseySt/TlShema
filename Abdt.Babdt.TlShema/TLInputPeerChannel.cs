using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(548253432)]
  public class TLInputPeerChannel : TLAbsInputPeer
  {
    public override int Constructor => 548253432;

    public int ChannelId { get; set; }

    public long AccessHash { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChannelId = br.ReadInt32();
      this.AccessHash = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChannelId);
      bw.Write(this.AccessHash);
    }
  }
}
