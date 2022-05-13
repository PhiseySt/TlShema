using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(-545786948)]
  public class TLRequestResetAuthorization : TLMethod
  {
    public override int Constructor => -545786948;

    public long Hash { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Hash = br.ReadInt64();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Hash);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
