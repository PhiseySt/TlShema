using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1462101002)]
  public class TLCdnConfig : TLObject
  {
    public override int Constructor => 1462101002;

    public TLVector<TLCdnPublicKey> PublicKeys { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.PublicKeys = ObjectUtils.DeserializeVector<TLCdnPublicKey>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.PublicKeys, bw);
    }
  }
}
