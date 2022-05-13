using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(239663460)]
  public class TLUpdateBotInlineSend : TLAbsUpdate
  {
    public override int Constructor => 239663460;

    public int Flags { get; set; }

    public int UserId { get; set; }

    public string Query { get; set; }

    public TLAbsGeoPoint Geo { get; set; }

    public string Id { get; set; }

    public TLInputBotInlineMessageID MsgId { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Geo != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.MsgId != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.UserId = br.ReadInt32();
      this.Query = StringUtil.Deserialize(br);
      this.Geo = (this.Flags & 1) == 0 ? (TLAbsGeoPoint) null : (TLAbsGeoPoint) ObjectUtils.DeserializeObject(br);
      this.Id = StringUtil.Deserialize(br);
      if ((this.Flags & 2) != 0)
        this.MsgId = (TLInputBotInlineMessageID) ObjectUtils.DeserializeObject(br);
      else
        this.MsgId = (TLInputBotInlineMessageID) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.UserId);
      StringUtil.Serialize(this.Query, bw);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.Geo, bw);
      StringUtil.Serialize(this.Id, bw);
      if ((this.Flags & 2) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.MsgId, bw);
    }
  }
}
