using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1343122938)]
  public class TLPrivacyKeyChatInvite : TLAbsPrivacyKey
  {
    public override int Constructor => 1343122938;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
