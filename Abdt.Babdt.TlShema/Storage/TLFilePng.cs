// Decompiled with JetBrains decompiler
// Type: TLSchema.Storage.TLFilePng
// Assembly: TLSchema, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C06F87F1-3918-4B54-A01D-D785E8CA2AA9
// Assembly location: C:\Users\FiseyskiySV\.nuget\packages\tlschema\1.1.0\lib\netstandard2.0\TLSchema.dll

using System.IO;

namespace Abdt.Babdt.TlShema.Storage
{
  [TLObject(172975040)]
  public class TLFilePng : TLAbsFileType
  {
    public override int Constructor => 172975040;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
