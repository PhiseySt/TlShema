using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(623001124)]
  public class TLRequestGetWebPagePreview : TLMethod
  {
    public override int Constructor => 623001124;

    public string Message { get; set; }

    public TLAbsMessageMedia Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Message = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Message, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsMessageMedia) ObjectUtils.DeserializeObject(br);
  }
}
