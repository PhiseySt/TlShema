using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1877932953)]
  public class TLInputPrivacyValueDisallowUsers : TLAbsInputPrivacyRule
  {
    public override int Constructor => -1877932953;

    public TLVector<TLAbsInputUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Users = ObjectUtils.DeserializeVector<TLAbsInputUser>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
