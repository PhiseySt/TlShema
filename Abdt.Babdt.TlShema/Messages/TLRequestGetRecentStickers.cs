using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1587647177)]
  public class TLRequestGetRecentStickers : TLMethod
  {
    public override int Constructor => 1587647177;

    public int Flags { get; set; }

    public bool Attached { get; set; }

    public int Hash { get; set; }

    public TLAbsRecentStickers Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Attached ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Attached = (uint) (this.Flags & 1) > 0U;
      this.Hash = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Hash);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsRecentStickers) ObjectUtils.DeserializeObject(br);
  }
}
