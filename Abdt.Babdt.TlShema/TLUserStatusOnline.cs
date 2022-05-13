using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-306628279)]
  public class TLUserStatusOnline : TLAbsUserStatus
  {
    public override int Constructor => -306628279;

    public int Expires { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Expires = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Expires);
    }
  }
}
