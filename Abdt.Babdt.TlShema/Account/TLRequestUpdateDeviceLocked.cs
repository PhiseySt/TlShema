using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(954152242)]
  public class TLRequestUpdateDeviceLocked : TLMethod
  {
    public override int Constructor => 954152242;

    public int Period { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Period = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Period);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
