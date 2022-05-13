using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(847887978)]
  public class TLRequestToggleDialogPin : TLMethod
  {
    public override int Constructor => 847887978;

    public int Flags { get; set; }

    public bool Pinned { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Pinned ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Pinned = (uint) (this.Flags & 1) > 0U;
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
