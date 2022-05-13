using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1227598250)]
  public class TLUpdateChannel : TLAbsUpdate
  {
    public override int Constructor => -1227598250;

    public int ChannelId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.ChannelId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChannelId);
    }
  }
}
