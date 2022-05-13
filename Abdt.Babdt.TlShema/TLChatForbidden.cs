using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(120753115)]
  public class TLChatForbidden : TLAbsChat
  {
    public override int Constructor => 120753115;

    public int Id { get; set; }

    public string Title { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt32();
      this.Title = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      StringUtil.Serialize(this.Title, bw);
    }
  }
}
