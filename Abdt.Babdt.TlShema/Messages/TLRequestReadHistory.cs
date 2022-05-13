using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(238054714)]
  public class TLRequestReadHistory : TLMethod
  {
    public override int Constructor => 238054714;

    public TLAbsInputPeer Peer { get; set; }

    public int MaxId { get; set; }

    public TLAffectedMessages Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.MaxId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.MaxId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAffectedMessages) ObjectUtils.DeserializeObject(br);
  }
}
