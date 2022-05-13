using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1232070311)]
  public class TLUpdateChatParticipantAdmin : TLAbsUpdate
  {
    public override int Constructor => -1232070311;

    public int ChatId { get; set; }

    public int UserId { get; set; }

    public bool IsAdmin { get; set; }

    public int Version { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.UserId = br.ReadInt32();
      this.IsAdmin = BoolUtil.Deserialize(br);
      this.Version = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      bw.Write(this.UserId);
      BoolUtil.Serialize(this.IsAdmin, bw);
      bw.Write(this.Version);
    }
  }
}
