using System.IO;

namespace Abdt.Babdt.TlShema.Stickers
{
  [TLObject(-1680314774)]
  public class TLRequestCreateStickerSet : TLMethod
  {
    public override int Constructor => -1680314774;

    public int Flags { get; set; }

    public bool Masks { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public string Title { get; set; }

    public string ShortName { get; set; }

    public TLVector<TLInputStickerSetItem> Stickers { get; set; }

    public Messages.TLStickerSet Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Masks ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Masks = (uint) (this.Flags & 1) > 0U;
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.Title = StringUtil.Deserialize(br);
      this.ShortName = StringUtil.Deserialize(br);
      this.Stickers = ObjectUtils.DeserializeVector<TLInputStickerSetItem>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      StringUtil.Serialize(this.Title, bw);
      StringUtil.Serialize(this.ShortName, bw);
      ObjectUtils.SerializeObject((object) this.Stickers, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (Messages.TLStickerSet) ObjectUtils.DeserializeObject(br);
  }
}
