using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-599447467)]
  public class TLRequestEditChatTitle : TLMethod
  {
    public override int Constructor => -599447467;

    public int ChatId { get; set; }

    public string Title { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.Title = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      StringUtil.Serialize(this.Title, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
