using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(-2035355412)]
  public class TLRequestSendCode : TLMethod
  {
    public override int Constructor => -2035355412;

    public int Flags { get; set; }

    public bool AllowFlashcall { get; set; }

    public string PhoneNumber { get; set; }

    public bool? CurrentNumber { get; set; }

    public int ApiId { get; set; }

    public string ApiHash { get; set; }

    public TLSentCode Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.AllowFlashcall ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.CurrentNumber.HasValue ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.AllowFlashcall = (uint) (this.Flags & 1) > 0U;
      this.PhoneNumber = StringUtil.Deserialize(br);
      this.CurrentNumber = (this.Flags & 1) == 0 ? new bool?() : new bool?(BoolUtil.Deserialize(br));
      this.ApiId = br.ReadInt32();
      this.ApiHash = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.PhoneNumber, bw);
      if ((this.Flags & 1) != 0)
        BoolUtil.Serialize(this.CurrentNumber.Value, bw);
      bw.Write(this.ApiId);
      StringUtil.Serialize(this.ApiHash, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLSentCode) ObjectUtils.DeserializeObject(br);
  }
}
