using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-110209570)]
  public class TLRequestUninstallStickerSet : TLMethod
  {
    public override int Constructor => -110209570;

    public TLAbsInputStickerSet Stickerset { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Stickerset = (TLAbsInputStickerSet) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Stickerset, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
