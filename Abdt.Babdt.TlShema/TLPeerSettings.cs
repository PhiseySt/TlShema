using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-2122045747)]
  public class TLPeerSettings : TLObject
  {
    public override int Constructor => -2122045747;

    public int Flags { get; set; }

    public bool ReportSpam { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.ReportSpam ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ReportSpam = (uint) (this.Flags & 1) > 0U;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
    }
  }
}
