using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(209668535)]
  public class TLPrivacyValueDisallowUsers : TLAbsPrivacyRule
  {
    public override int Constructor => 209668535;

    public TLVector<int> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Users = ObjectUtils.DeserializeVector<int>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
