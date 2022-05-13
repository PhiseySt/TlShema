using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(889353612)]
  public class TLReplyKeyboardMarkup : TLAbsReplyMarkup
  {
    public override int Constructor => 889353612;

    public int Flags { get; set; }

    public bool Resize { get; set; }

    public bool SingleUse { get; set; }

    public bool Selective { get; set; }

    public TLVector<TLKeyboardButtonRow> Rows { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Resize ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.SingleUse ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Selective ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Resize = (uint) (this.Flags & 1) > 0U;
      this.SingleUse = (uint) (this.Flags & 2) > 0U;
      this.Selective = (uint) (this.Flags & 4) > 0U;
      this.Rows = ObjectUtils.DeserializeVector<TLKeyboardButtonRow>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Rows, bw);
    }
  }
}
