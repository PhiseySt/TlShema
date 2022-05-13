using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(922273905)]
  public class TLDocumentEmpty : TLAbsDocument
  {
    public override int Constructor => 922273905;

    public long Id { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = br.ReadInt64();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
    }
  }
}
