using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-866424884)]
  public class TLRequestGetAttachedStickers : TLMethod
  {
    public override int Constructor => -866424884;

    public TLAbsInputStickeredMedia Media { get; set; }

    public TLVector<TLAbsStickerSetCovered> Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Media = (TLAbsInputStickeredMedia) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Media, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = ObjectUtils.DeserializeVector<TLAbsStickerSetCovered>(br);
  }
}
