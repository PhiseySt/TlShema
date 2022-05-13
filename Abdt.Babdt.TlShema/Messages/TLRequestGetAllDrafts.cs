using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1782549861)]
  public class TLRequestGetAllDrafts : TLMethod
  {
    public override int Constructor => 1782549861;

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
