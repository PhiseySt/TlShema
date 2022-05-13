using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-299124375)]
  public class TLUpdateDraftMessage : TLAbsUpdate
  {
    public override int Constructor => -299124375;

    public TLAbsPeer Peer { get; set; }

    public TLAbsDraftMessage Draft { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsPeer) ObjectUtils.DeserializeObject(br);
      this.Draft = (TLAbsDraftMessage) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      ObjectUtils.SerializeObject((object) this.Draft, bw);
    }
  }
}
