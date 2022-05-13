using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1217033015)]
  public class TLMessageActionChatAddUser : TLAbsMessageAction
  {
    public override int Constructor => 1217033015;

    public TLVector<int> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Users = ObjectUtils.DeserializeVector<int>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
