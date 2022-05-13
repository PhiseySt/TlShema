using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(673687578)]
  public class TLInputMediaVenue : TLAbsInputMedia
  {
    public override int Constructor => 673687578;

    public TLAbsInputGeoPoint GeoPoint { get; set; }

    public string Title { get; set; }

    public string Address { get; set; }

    public string Provider { get; set; }

    public string VenueId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.GeoPoint = (TLAbsInputGeoPoint) ObjectUtils.DeserializeObject(br);
      this.Title = StringUtil.Deserialize(br);
      this.Address = StringUtil.Deserialize(br);
      this.Provider = StringUtil.Deserialize(br);
      this.VenueId = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.GeoPoint, bw);
      StringUtil.Serialize(this.Title, bw);
      StringUtil.Serialize(this.Address, bw);
      StringUtil.Serialize(this.Provider, bw);
      StringUtil.Serialize(this.VenueId, bw);
    }
  }
}
