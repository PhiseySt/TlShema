using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(469489699)]
  public class TLUpdateUserStatus : TLAbsUpdate
  {
    public override int Constructor => 469489699;

    public int UserId { get; set; }

    public TLAbsUserStatus Status { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.Status = (TLAbsUserStatus) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      ObjectUtils.SerializeObject((object) this.Status, bw);
    }
  }
}
