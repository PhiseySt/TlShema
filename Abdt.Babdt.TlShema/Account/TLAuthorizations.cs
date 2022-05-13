using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(307276766)]
  public class TLAuthorizations : TLObject
  {
    public override int Constructor => 307276766;

    public TLVector<TLAuthorization> Authorizations { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Authorizations = ObjectUtils.DeserializeVector<TLAuthorization>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Authorizations, bw);
    }
  }
}
