using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(2016638777)]
  public class TLRequestReorderStickerSets : TLMethod
  {
    public override int Constructor => 2016638777;

    public int Flags { get; set; }

    public bool Masks { get; set; }

    public TLVector<long> Order { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Masks ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Masks = (uint) (this.Flags & 1) > 0U;
      this.Order = ObjectUtils.DeserializeVector<long>(br);
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
