using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-847783593)]
  public class TLChannelMessagesFilter : TLAbsChannelMessagesFilter
  {
    public override int Constructor => -847783593;

    public int Flags { get; set; }

    public bool ExcludeNewMessages { get; set; }

    public TLVector<TLMessageRange> Ranges { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.ExcludeNewMessages ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ExcludeNewMessages = (uint) (this.Flags & 2) > 0U;
      this.Ranges = ObjectUtils.DeserializeVector<TLMessageRange>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Ranges, bw);
    }
  }
}
