using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1817183516)]
  public class TLRequestImportChatInvite : TLMethod
  {
    public override int Constructor => 1817183516;

    public string Hash { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Hash = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Hash, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
