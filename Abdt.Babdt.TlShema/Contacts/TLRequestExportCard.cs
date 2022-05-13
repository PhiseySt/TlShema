using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(-2065352905)]
  public class TLRequestExportCard : TLMethod
  {
    public override int Constructor => -2065352905;

    public TLVector<int> Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = ObjectUtils.DeserializeVector<int>(br);
  }
}
