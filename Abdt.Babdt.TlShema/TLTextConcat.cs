using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(2120376535)]
  public class TLTextConcat : TLAbsRichText
  {
    public override int Constructor => 2120376535;

    public TLVector<TLAbsRichText> Texts { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Texts = ObjectUtils.DeserializeVector<TLAbsRichText>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Texts, bw);
    }
  }
}
