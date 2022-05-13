using System.IO;

namespace Abdt.Babdt.TlShema
{
  public abstract class TLObject
  {
    public abstract int Constructor { get; }

    public abstract void SerializeBody(BinaryWriter bw);

    public abstract void DeserializeBody(BinaryReader br);

    public byte[] Serialize()
    {
      using (MemoryStream output = new MemoryStream())
      {
        using (BinaryWriter writer = new BinaryWriter((Stream) output))
        {
          this.Serialize(writer);
          writer.Close();
          output.Close();
          return output.ToArray();
        }
      }
    }

    public void Serialize(BinaryWriter writer)
    {
      writer.Write(this.Constructor);
      this.SerializeBody(writer);
    }

    public void Deserialize(BinaryReader reader)
    {
      if (reader.ReadInt32() != this.Constructor)
        throw new InvalidDataException("Constructor Invalid");
      this.DeserializeBody(reader);
    }
  }
}
