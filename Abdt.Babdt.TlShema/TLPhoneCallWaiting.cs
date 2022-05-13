using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(462375633)]
  public class TLPhoneCallWaiting : TLAbsPhoneCall
  {
    public override int Constructor => 462375633;

    public int Flags { get; set; }

    public long Id { get; set; }

    public long AccessHash { get; set; }

    public int Date { get; set; }

    public int AdminId { get; set; }

    public int ParticipantId { get; set; }

    public TLPhoneCallProtocol Protocol { get; set; }

    public int? ReceiveDate { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.ReceiveDate.HasValue ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Id = br.ReadInt64();
      this.AccessHash = br.ReadInt64();
      this.Date = br.ReadInt32();
      this.AdminId = br.ReadInt32();
      this.ParticipantId = br.ReadInt32();
      this.Protocol = (TLPhoneCallProtocol) ObjectUtils.DeserializeObject(br);
      if ((this.Flags & 1) != 0)
        this.ReceiveDate = new int?(br.ReadInt32());
      else
        this.ReceiveDate = new int?();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
      bw.Write(this.Date);
      bw.Write(this.AdminId);
      bw.Write(this.ParticipantId);
      ObjectUtils.SerializeObject((object) this.Protocol, bw);
      if ((this.Flags & 1) == 0)
        return;
      bw.Write(this.ReceiveDate.Value);
    }
  }
}
