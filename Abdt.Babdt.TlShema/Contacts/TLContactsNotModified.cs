using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(-1219778094)]
  public class TLContactsNotModified : TLAbsContacts
  {
    public override int Constructor => -1219778094;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
