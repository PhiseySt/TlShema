﻿using System.IO;

namespace Abdt.Babdt.TlShema.Storage
{
  [TLObject(276907596)]
  public class TLFileWebp : TLAbsFileType
  {
    public override int Constructor => 276907596;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
