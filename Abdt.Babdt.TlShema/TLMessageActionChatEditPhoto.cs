using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(2144015272)]
  public class TLMessageActionChatEditPhoto : TLAbsMessageAction
  {
    public override int Constructor => 2144015272;

    public TLAbsPhoto Photo { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Photo = (TLAbsPhoto) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
    }
  }
}
