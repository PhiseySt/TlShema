using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-657787251)]
  public class TLUpdatePinnedDialogs : TLAbsUpdate
  {
    public override int Constructor => -657787251;

    public int Flags { get; set; }

    public TLVector<TLAbsPeer> Order { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Order != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      if ((this.Flags & 1) != 0)
        this.Order = ObjectUtils.DeserializeVector<TLAbsPeer>(br);
      else
        this.Order = (TLVector<TLAbsPeer>) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.Order, bw);
    }
  }
}
