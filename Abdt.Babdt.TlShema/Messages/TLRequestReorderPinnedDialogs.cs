using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1784678844)]
  public class TLRequestReorderPinnedDialogs : TLMethod
  {
    public override int Constructor => -1784678844;

    public int Flags { get; set; }

    public bool Force { get; set; }

    public TLVector<TLAbsInputPeer> Order { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Force ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Force = (uint) (this.Flags & 1) > 0U;
      this.Order = ObjectUtils.DeserializeVector<TLAbsInputPeer>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Order, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
