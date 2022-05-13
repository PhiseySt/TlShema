using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(1998331287)]
  public class TLRequestSendInvites : TLMethod
  {
    public override int Constructor => 1998331287;

    public TLVector<string> PhoneNumbers { get; set; }

    public string Message { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneNumbers = ObjectUtils.DeserializeVector<string>(br);
      this.Message = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.PhoneNumbers, bw);
      StringUtil.Serialize(this.Message, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
