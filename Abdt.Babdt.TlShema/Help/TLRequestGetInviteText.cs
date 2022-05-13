using System.IO;

namespace Abdt.Babdt.TlShema.Help
{
  [TLObject(1295590211)]
  public class TLRequestGetInviteText : TLMethod
  {
    public override int Constructor => 1295590211;

    public TLInviteText Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLInviteText) ObjectUtils.DeserializeObject(br);
  }
}
