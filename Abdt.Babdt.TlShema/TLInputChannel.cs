using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1343524562)]
  public class TLInputChannel : TLAbsInputChannel
  {
    public override int Constructor => -1343524562;

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
