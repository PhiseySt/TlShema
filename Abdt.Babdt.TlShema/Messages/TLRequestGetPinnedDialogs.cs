using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-497756594)]
  public class TLRequestGetPinnedDialogs : TLMethod
  {
    public override int Constructor => -497756594;

    public TLPeerDialogs Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLPeerDialogs) ObjectUtils.DeserializeObject(br);
  }
}
