using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(1340184318)]
  public class TLRequestImportCard : TLMethod
  {
    public override int Constructor => 1340184318;

    public TLVector<int> ExportCard { get; set; }

    public TLAbsUser Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.ExportCard = ObjectUtils.DeserializeVector<int>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.ExportCard, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUser) ObjectUtils.DeserializeObject(br);
  }
}
