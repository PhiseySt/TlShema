using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(865483769)]
  public class TLRequestForwardMessage : TLMethod
  {
    public override int Constructor => 865483769;

    public TLAbsInputPeer Peer { get; set; }

    public int Id { get; set; }

    public long RandomId { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Id = br.ReadInt32();
      this.RandomId = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.Id);
      bw.Write(this.RandomId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
