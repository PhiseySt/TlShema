using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1259113487)]
  public class TLRequestReportEncryptedSpam : TLMethod
  {
    public override int Constructor => 1259113487;

    public TLInputEncryptedChat Peer { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Peer = (TLInputEncryptedChat) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
