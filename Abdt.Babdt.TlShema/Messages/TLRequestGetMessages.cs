using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1109588596)]
  public class TLRequestGetMessages : TLMethod
  {
    public override int Constructor => 1109588596;

    public TLVector<int> Id { get; set; }

    public TLAbsMessages Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = ObjectUtils.DeserializeVector<int>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsMessages) ObjectUtils.DeserializeObject(br);
  }
}
