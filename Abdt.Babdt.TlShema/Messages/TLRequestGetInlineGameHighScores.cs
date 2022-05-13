using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(258170395)]
  public class TLRequestGetInlineGameHighScores : TLMethod
  {
    public override int Constructor => 258170395;

    public TLInputBotInlineMessageID Id { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public TLHighScores Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = (TLInputBotInlineMessageID) ObjectUtils.DeserializeObject(br);
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLHighScores) ObjectUtils.DeserializeObject(br);
  }
}
