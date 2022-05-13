using System.IO;

namespace Abdt.Babdt.TlShema.Stickers
{
  [TLObject(-2041315650)]
  public class TLRequestAddStickerToSet : TLMethod
  {
    public override int Constructor => -2041315650;

    public TLAbsInputStickerSet Stickerset { get; set; }

    public TLInputStickerSetItem Sticker { get; set; }

    public Messages.TLStickerSet Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Stickerset = (TLAbsInputStickerSet) ObjectUtils.DeserializeObject(br);
      this.Sticker = (TLInputStickerSetItem) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Stickerset, bw);
      ObjectUtils.SerializeObject((object) this.Sticker, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (Messages.TLStickerSet) ObjectUtils.DeserializeObject(br);
  }
}
