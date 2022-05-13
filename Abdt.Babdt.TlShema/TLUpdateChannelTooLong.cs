using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-352032773)]
  public class TLUpdateChannelTooLong : TLAbsUpdate
  {
    public override int Constructor => -352032773;

    public int Flags { get; set; }

    public int ChannelId { get; set; }

    public int? Pts { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Pts.HasValue ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ChannelId = br.ReadInt32();
      if ((this.Flags & 1) != 0)
        this.Pts = new int?(br.ReadInt32());
      else
        this.Pts = new int?();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.ChannelId);
      if ((this.Flags & 1) == 0)
        return;
      bw.Write(this.Pts.Value);
    }
  }
}
