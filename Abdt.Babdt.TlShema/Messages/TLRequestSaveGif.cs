using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(846868683)]
  public class TLRequestSaveGif : TLMethod
  {
    public override int Constructor => 846868683;

    public TLAbsInputDocument Id { get; set; }

    public bool Unsave { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = (TLAbsInputDocument) ObjectUtils.DeserializeObject(br);
      this.Unsave = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
      BoolUtil.Serialize(this.Unsave, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
