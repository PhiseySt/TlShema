using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-2132731265)]
  public class TLMessageActionPhoneCall : TLAbsMessageAction
  {
    public override int Constructor => -2132731265;

    public int Flags { get; set; }

    public long CallId { get; set; }

    public TLAbsPhoneCallDiscardReason Reason { get; set; }

    public int? Duration { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Reason != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Duration.HasValue ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.CallId = br.ReadInt64();
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
      bw.Write(this.CallId);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.Reason, bw);
      if ((this.Flags & 2) == 0)
        return;
      bw.Write(this.Duration.Value);
    }
  }
}
