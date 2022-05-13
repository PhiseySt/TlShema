using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(-634342611)]
  public class TLRequestImportContacts : TLMethod
  {
    public override int Constructor => -634342611;

    public TLVector<TLInputPhoneContact> Contacts { get; set; }

    public bool Replace { get; set; }

    public TLImportedContacts Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Contacts = ObjectUtils.DeserializeVector<TLInputPhoneContact>(br);
      this.Replace = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Contacts, bw);
      BoolUtil.Serialize(this.Replace, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLImportedContacts) ObjectUtils.DeserializeObject(br);
  }
}
