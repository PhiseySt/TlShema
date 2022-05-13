using System.IO;

namespace Abdt.Babdt.TlShema.Users
{
  [TLObject(227648840)]
  public class TLRequestGetUsers : TLMethod
  {
    public override int Constructor => 227648840;

    public TLVector<TLAbsInputUser> Id { get; set; }

    public TLVector<TLAbsUser> Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = ObjectUtils.DeserializeVector<TLAbsInputUser>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = ObjectUtils.DeserializeVector<TLAbsUser>(br);
  }
}
