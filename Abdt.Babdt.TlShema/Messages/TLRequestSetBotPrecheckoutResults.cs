using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(163765653)]
  public class TLRequestSetBotPrecheckoutResults : TLMethod
  {
    public override int Constructor => 163765653;

    public int Flags { get; set; }

    public bool Success { get; set; }

    public long QueryId { get; set; }

    public string Error { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Success ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Error != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Success = (uint) (this.Flags & 2) > 0U;
      this.QueryId = br.ReadInt64();
      if ((this.Flags & 1) != 0)
        this.Error = StringUtil.Deserialize(br);
      else
        this.Error = (string) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.QueryId);
      if ((this.Flags & 1) == 0)
        return;
      StringUtil.Serialize(this.Error, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
