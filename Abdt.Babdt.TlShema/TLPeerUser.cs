using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1649296275)]
  public class TLPeerUser : TLAbsPeer
  {
    public override int Constructor => -1649296275;

    public int UserId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.UserId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
    }
  }
}
