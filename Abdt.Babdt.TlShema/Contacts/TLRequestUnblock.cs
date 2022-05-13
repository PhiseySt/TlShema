using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(-448724803)]
  public class TLRequestUnblock : TLMethod
  {
    public override int Constructor => -448724803;

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
