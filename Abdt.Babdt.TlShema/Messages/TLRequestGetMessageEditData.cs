using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-39416522)]
  public class TLRequestGetMessageEditData : TLMethod
  {
    public override int Constructor => -39416522;

    public TLAbsInputPeer Peer { get; set; }

    public int Id { get; set; }

    public TLMessageEditData Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Id = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.Id);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLMessageEditData) ObjectUtils.DeserializeObject(br);
  }
}
