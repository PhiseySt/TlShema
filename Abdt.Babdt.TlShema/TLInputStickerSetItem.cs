using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-6249322)]
  public class TLInputStickerSetItem : TLObject
  {
    public override int Constructor => -6249322;

    public int Flags { get; set; }

    public TLAbsInputDocument Document { get; set; }

    public string Emoji { get; set; }

    public TLMaskCoords MaskCoords { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.MaskCoords != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Document = (TLAbsInputDocument) ObjectUtils.DeserializeObject(br);
      this.Emoji = StringUtil.Deserialize(br);
      if ((this.Flags & 1) != 0)
        this.MaskCoords = (TLMaskCoords) ObjectUtils.DeserializeObject(br);
      else
        this.MaskCoords = (TLMaskCoords) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Document, bw);
      StringUtil.Serialize(this.Emoji, bw);
      if ((this.Flags & 1) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.MaskCoords, bw);
    }
  }
}
