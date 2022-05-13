using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(469850889)]
  public class TLRequestDeleteHistory : TLMethod
  {
    public override int Constructor => 469850889;

    public int Flags { get; set; }

    public bool JustClear { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public int MaxId { get; set; }

    public TLAffectedHistory Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.JustClear ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.JustClear = (uint) (this.Flags & 1) > 0U;
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.MaxId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.MaxId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAffectedHistory) ObjectUtils.DeserializeObject(br);
  }
}
