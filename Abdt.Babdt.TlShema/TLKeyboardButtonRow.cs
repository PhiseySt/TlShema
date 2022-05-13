using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(2002815875)]
  public class TLKeyboardButtonRow : TLObject
  {
    public override int Constructor => 2002815875;

    public TLVector<TLAbsKeyboardButton> Buttons { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Buttons = ObjectUtils.DeserializeVector<TLAbsKeyboardButton>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Buttons, bw);
    }
  }
}
