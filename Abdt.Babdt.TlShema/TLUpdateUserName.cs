using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1489818765)]
  public class TLUpdateUserName : TLAbsUpdate
  {
    public override int Constructor => -1489818765;

    public int UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.FirstName = StringUtil.Deserialize(br);
      this.LastName = StringUtil.Deserialize(br);
      this.Username = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      StringUtil.Serialize(this.FirstName, bw);
      StringUtil.Serialize(this.LastName, bw);
      StringUtil.Serialize(this.Username, bw);
    }
  }
}
