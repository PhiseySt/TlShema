using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(301470424)]
  public class TLRequestSearch : TLMethod
  {
    public override int Constructor => 301470424;

    public string Q { get; set; }

    public int Limit { get; set; }

    public TLFound Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Q = StringUtil.Deserialize(br);
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Q, bw);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLFound) ObjectUtils.DeserializeObject(br);
  }
}
