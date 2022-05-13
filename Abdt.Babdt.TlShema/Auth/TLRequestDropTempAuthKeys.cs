using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(-1907842680)]
  public class TLRequestDropTempAuthKeys : TLMethod
  {
    public override int Constructor => -1907842680;

    public TLVector<long> ExceptAuthKeys { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.ExceptAuthKeys = ObjectUtils.DeserializeVector<long>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.ExceptAuthKeys, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
