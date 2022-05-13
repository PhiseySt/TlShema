using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1218642516)]
  public class TLReplyInlineMarkup : TLAbsReplyMarkup
  {
    public override int Constructor => 1218642516;

    public TLVector<TLKeyboardButtonRow> Rows { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Rows = ObjectUtils.DeserializeVector<TLKeyboardButtonRow>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Rows, bw);
    }
  }
}
