using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(9203775)]
  public class TLUserStatusOffline : TLAbsUserStatus
  {
    public override int Constructor => 9203775;

    public int WasOnline { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.WasOnline = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.WasOnline);
    }
  }
}
