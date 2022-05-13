using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(-1902823612)]
  public class TLRequestDeleteContact : TLMethod
  {
    public override int Constructor => -1902823612;

    public TLAbsInputUser Id { get; set; }

    public TLLink Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLLink) ObjectUtils.DeserializeObject(br);
  }
}
