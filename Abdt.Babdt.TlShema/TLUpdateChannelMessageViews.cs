using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1734268085)]
  public class TLUpdateChannelMessageViews : TLAbsUpdate
  {
    public override int Constructor => -1734268085;

    public int ChannelId { get; set; }

    public int Id { get; set; }

    public int Views { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChannelId = br.ReadInt32();
      this.Id = br.ReadInt32();
      this.Views = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChannelId);
      bw.Write(this.Id);
      bw.Write(this.Views);
    }
  }
}
