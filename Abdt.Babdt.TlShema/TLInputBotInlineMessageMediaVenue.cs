using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1431327288)]
  public class TLInputBotInlineMessageMediaVenue : TLAbsInputBotInlineMessage
  {
    public override int Constructor => -1431327288;

    public int Flags { get; set; }

    public TLAbsInputGeoPoint GeoPoint { get; set; }

    public string Title { get; set; }

    public string Address { get; set; }

    public string Provider { get; set; }

    public string VenueId { get; set; }

    public TLAbsReplyMarkup ReplyMarkup { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.ReplyMarkup != null ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.GeoPoint = (TLAbsInputGeoPoint) ObjectUtils.DeserializeObject(br);
      this.Title = StringUtil.Deserialize(br);
      this.Address = StringUtil.Deserialize(br);
      this.Provider = StringUtil.Deserialize(br);
      this.VenueId = StringUtil.Deserialize(br);
      if ((this.Flags & 4) != 0)
        this.ReplyMarkup = (TLAbsReplyMarkup) ObjectUtils.DeserializeObject(br);
      else
        this.ReplyMarkup = (TLAbsReplyMarkup) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.GeoPoint, bw);
      StringUtil.Serialize(this.Title, bw);
      StringUtil.Serialize(this.Address, bw);
      StringUtil.Serialize(this.Provider, bw);
      StringUtil.Serialize(this.VenueId, bw);
      if ((this.Flags & 4) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.ReplyMarkup, bw);
    }
  }
}
