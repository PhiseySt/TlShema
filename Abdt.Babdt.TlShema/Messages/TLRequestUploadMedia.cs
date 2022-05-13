using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1369162417)]
  public class TLRequestUploadMedia : TLMethod
  {
    public override int Constructor => 1369162417;

    public TLAbsInputPeer Peer { get; set; }

    public TLAbsInputMedia Media { get; set; }

    public TLAbsMessageMedia Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Media = (TLAbsInputMedia) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      ObjectUtils.SerializeObject((object) this.Media, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsMessageMedia) ObjectUtils.DeserializeObject(br);
  }
}
