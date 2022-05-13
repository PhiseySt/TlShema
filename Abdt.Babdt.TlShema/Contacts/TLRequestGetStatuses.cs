using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(-995929106)]
  public class TLRequestGetStatuses : TLMethod
  {
    public override int Constructor => -995929106;

    public TLVector<TLContactStatus> Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = ObjectUtils.DeserializeVector<TLContactStatus>(br);
  }
}
