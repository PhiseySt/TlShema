using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-2131957734)]
  public class TLUpdateUserBlocked : TLAbsUpdate
  {
    public override int Constructor => -2131957734;

    public int UserId { get; set; }

    public bool Blocked { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.Blocked = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      BoolUtil.Serialize(this.Blocked, bw);
    }
  }
}
