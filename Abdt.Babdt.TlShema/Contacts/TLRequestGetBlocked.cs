using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(-176409329)]
  public class TLRequestGetBlocked : TLMethod
  {
    public override int Constructor => -176409329;

    public int Offset { get; set; }

    public int Limit { get; set; }

    public TLAbsBlocked Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Offset = br.ReadInt32();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Offset);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsBlocked) ObjectUtils.DeserializeObject(br);
  }
}
