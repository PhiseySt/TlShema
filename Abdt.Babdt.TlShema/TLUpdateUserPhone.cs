using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(314130811)]
  public class TLUpdateUserPhone : TLAbsUpdate
  {
    public override int Constructor => 314130811;

    public int UserId { get; set; }

    public string Phone { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.Phone = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      StringUtil.Serialize(this.Phone, bw);
    }
  }
}
