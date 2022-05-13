using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-686710068)]
  public class TLUpdateDialogPinned : TLAbsUpdate
  {
    public override int Constructor => -686710068;

    public int Flags { get; set; }

    public bool Pinned { get; set; }

    public TLAbsPeer Peer { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Pinned ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Pinned = (uint) (this.Flags & 1) > 0U;
      this.Peer = (TLAbsPeer) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
    }
  }
}
