using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(-113456221)]
  public class TLRequestResolveUsername : TLMethod
  {
    public override int Constructor => -113456221;

    public string Username { get; set; }

    public TLResolvedPeer Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Username = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Username, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLResolvedPeer) ObjectUtils.DeserializeObject(br);
  }
}
