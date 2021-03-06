using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(2031269663)]
  public class TLMessageMediaVenue : TLAbsMessageMedia
  {
    public override int Constructor => 2031269663;

    public TLAbsGeoPoint Geo { get; set; }

    public string Title { get; set; }

    public string Address { get; set; }

    public string Provider { get; set; }

    public string VenueId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Geo = (TLAbsGeoPoint) ObjectUtils.DeserializeObject(br);
      this.Title = StringUtil.Deserialize(br);
      this.Address = StringUtil.Deserialize(br);
      this.Provider = StringUtil.Deserialize(br);
      this.VenueId = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Geo, bw);
      StringUtil.Serialize(this.Title, bw);
      StringUtil.Serialize(this.Address, bw);
      StringUtil.Serialize(this.Provider, bw);
      StringUtil.Serialize(this.VenueId, bw);
    }
  }
}
