using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-748155807)]
  public class TLContactStatus : TLObject
  {
    public override int Constructor => -748155807;

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
