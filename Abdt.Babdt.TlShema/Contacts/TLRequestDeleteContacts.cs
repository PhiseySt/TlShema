using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(1504393374)]
  public class TLRequestDeleteContacts : TLMethod
  {
    public override int Constructor => 1504393374;

    public TLVector<TLAbsInputUser> Id { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = ObjectUtils.DeserializeVector<TLAbsInputUser>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
