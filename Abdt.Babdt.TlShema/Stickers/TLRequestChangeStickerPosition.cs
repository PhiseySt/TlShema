using System.IO;

namespace Abdt.Babdt.TlShema.Stickers
{
  [TLObject(1322714570)]
  public class TLRequestChangeStickerPosition : TLMethod
  {
    public override int Constructor => 1322714570;

    public TLAbsInputDocument Sticker { get; set; }

    public int Position { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Sticker = (TLAbsInputDocument) ObjectUtils.DeserializeObject(br);
      this.Position = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Sticker, bw);
      bw.Write(this.Position);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
