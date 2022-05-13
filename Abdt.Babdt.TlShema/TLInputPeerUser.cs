using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(2072935910)]
  public class TLInputPeerUser : TLAbsInputPeer
  {
    public override int Constructor => 2072935910;

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
