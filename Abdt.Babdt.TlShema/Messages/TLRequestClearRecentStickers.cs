using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1986437075)]
  public class TLRequestClearRecentStickers : TLMethod
  {
    public override int Constructor => -1986437075;

    public int Flags { get; set; }

    public bool Attached { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Attached ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Attached = (uint) (this.Flags & 1) > 0U;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
