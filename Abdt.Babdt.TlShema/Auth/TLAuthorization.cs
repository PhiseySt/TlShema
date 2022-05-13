using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(-855308010)]
  public class TLAuthorization : TLObject
  {
    public override int Constructor => -855308010;

    public int Flags { get; set; }

    public int? TmpSessions { get; set; }

    public TLAbsUser User { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.TmpSessions.HasValue ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.TmpSessions = (this.Flags & 1) == 0 ? new int?() : new int?(br.ReadInt32());
      this.User = (TLAbsUser) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) != 0)
        bw.Write(this.TmpSessions.Value);
      ObjectUtils.SerializeObject((object) this.User, bw);
    }
  }
}
