using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(451113900)]
  public class TLRequestResetTopPeerRating : TLMethod
  {
    public override int Constructor => 451113900;

    public TLAbsTopPeerCategory Category { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Category = (TLAbsTopPeerCategory) ObjectUtils.DeserializeObject(br);
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Category, bw);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
