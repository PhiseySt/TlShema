using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1661770481)]
  public class TLInputMediaUploadedPhoto : TLAbsInputMedia
  {
    public override int Constructor => 1661770481;

    public int Flags { get; set; }

    public TLAbsInputFile File { get; set; }

    public string Caption { get; set; }

    public TLVector<TLAbsInputDocument> Stickers { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Stickers != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.File = (TLAbsInputFile) ObjectUtils.DeserializeObject(br);
      this.Caption = StringUtil.Deserialize(br);
      if ((this.Flags & 1) != 0)
        this.Stickers = ObjectUtils.DeserializeVector<TLAbsInputDocument>(br);
      else
        this.Stickers = (TLVector<TLAbsInputDocument>) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.File, bw);
      StringUtil.Serialize(this.Caption, bw);
      if ((this.Flags & 1) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.Stickers, bw);
    }
  }
}
