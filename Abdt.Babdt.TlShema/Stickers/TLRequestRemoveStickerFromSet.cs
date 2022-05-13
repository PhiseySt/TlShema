using System.IO;

namespace Abdt.Babdt.TlShema.Stickers
{
  [TLObject(69556532)]
  public class TLRequestRemoveStickerFromSet : TLMethod
  {
    public override int Constructor => 69556532;

    public TLAbsInputDocument Sticker { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Sticker = (TLAbsInputDocument) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Sticker, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
