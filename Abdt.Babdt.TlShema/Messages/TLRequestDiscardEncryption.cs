using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-304536635)]
  public class TLRequestDiscardEncryption : TLMethod
  {
    public override int Constructor => -304536635;

    public int ChatId { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.ChatId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
