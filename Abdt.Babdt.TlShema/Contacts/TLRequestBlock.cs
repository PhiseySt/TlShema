using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(858475004)]
  public class TLRequestBlock : TLMethod
  {
    public override int Constructor => 858475004;

    public TLAbsInputUser Id { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
