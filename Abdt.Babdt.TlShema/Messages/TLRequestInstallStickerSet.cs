using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-946871200)]
  public class TLRequestInstallStickerSet : TLMethod
  {
    public override int Constructor => -946871200;

    public TLAbsInputStickerSet Stickerset { get; set; }

    public bool Archived { get; set; }

    public TLAbsStickerSetInstallResult Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Stickerset = (TLAbsInputStickerSet) ObjectUtils.DeserializeObject(br);
      this.Archived = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Stickerset, bw);
      BoolUtil.Serialize(this.Archived, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsStickerSetInstallResult) ObjectUtils.DeserializeObject(br);
  }
}
