using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(2104790276)]
  public class TLDataJSON : TLObject
  {
    public override int Constructor => 2104790276;

    public string Data { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Data = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Data, bw);
    }
  }
}
