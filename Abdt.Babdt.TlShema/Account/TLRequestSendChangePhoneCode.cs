using System.IO;
using Abdt.Babdt.TlShema.Auth;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(149257707)]
  public class TLRequestSendChangePhoneCode : TLMethod
  {
    public override int Constructor => 149257707;

    public int Flags { get; set; }

    public bool AllowFlashcall { get; set; }

    public string PhoneNumber { get; set; }

    public bool? CurrentNumber { get; set; }

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
      if ((this.Flags & 1) != 0)
        this.CurrentNumber = new bool?(BoolUtil.Deserialize(br));
      else
        this.CurrentNumber = new bool?();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.PhoneNumber, bw);
      if ((this.Flags & 1) == 0)
        return;
      BoolUtil.Serialize(this.CurrentNumber.Value, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLSentCode) ObjectUtils.DeserializeObject(br);
  }
}
