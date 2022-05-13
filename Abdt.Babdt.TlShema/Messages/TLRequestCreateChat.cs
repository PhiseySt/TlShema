using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(164303470)]
  public class TLRequestCreateChat : TLMethod
  {
    public override int Constructor => 164303470;

    public TLVector<TLAbsInputUser> Users { get; set; }

    public string Title { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Users = ObjectUtils.DeserializeVector<TLAbsInputUser>(br);
      this.Title = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Users, bw);
      StringUtil.Serialize(this.Title, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
