using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(639215886)]
  public class TLRequestGetStickerSet : TLMethod
  {
    public override int Constructor => 639215886;

    public TLAbsInputStickerSet Stickerset { get; set; }

    public TLStickerSet Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Stickerset = (TLAbsInputStickerSet) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Stickerset, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLStickerSet) ObjectUtils.DeserializeObject(br);
  }
}
