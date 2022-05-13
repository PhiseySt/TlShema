using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(583445000)]
  public class TLRequestGetContacts : TLMethod
  {
    public override int Constructor => 583445000;

    public string Hash { get; set; }

    public TLAbsContacts Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Hash = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Hash, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsContacts) ObjectUtils.DeserializeObject(br);
  }
}
