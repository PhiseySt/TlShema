using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-668391402)]
  public class TLInputUser : TLAbsInputUser
  {
    public override int Constructor => -668391402;

    public int UserId { get; set; }

    public long AccessHash { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.AccessHash = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      bw.Write(this.AccessHash);
    }
  }
}
