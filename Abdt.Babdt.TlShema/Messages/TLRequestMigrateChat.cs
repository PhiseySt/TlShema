using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(363051235)]
  public class TLRequestMigrateChat : TLMethod
  {
    public override int Constructor => 363051235;

    public int ChatId { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.ChatId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
