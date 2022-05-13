using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1355435489)]
  public class TLPhoneCallDiscarded : TLAbsPhoneCall
  {
    public override int Constructor => 1355435489;

    public int Flags { get; set; }

    public bool NeedRating { get; set; }

    public bool NeedDebug { get; set; }

    public long Id { get; set; }

    public TLAbsPhoneCallDiscardReason Reason { get; set; }

    public int? Duration { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.NeedRating ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.NeedDebug ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Reason != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Duration.HasValue ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.NeedRating = (uint) (this.Flags & 4) > 0U;
      this.NeedDebug = (uint) (this.Flags & 8) > 0U;
      this.Id = br.ReadInt64();
      this.Reason = (this.Flags & 1) == 0 ? (TLAbsPhoneCallDiscardReason) null : (TLAbsPhoneCallDiscardReason) ObjectUtils.DeserializeObject(br);
      if ((this.Flags & 2) != 0)
        this.Duration = new int?(br.ReadInt32());
      else
        this.Duration = new int?();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.Reason, bw);
      if ((this.Flags & 2) == 0)
        return;
      bw.Write(this.Duration.Value);
    }
  }
}
