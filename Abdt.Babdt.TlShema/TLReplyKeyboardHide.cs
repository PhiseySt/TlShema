using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1606526075)]
  public class TLReplyKeyboardHide : TLAbsReplyMarkup
  {
    public override int Constructor => -1606526075;

    public int Flags { get; set; }

    public bool Selective { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Selective ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Selective = (uint) (this.Flags & 4) > 0U;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
    }
  }
}
