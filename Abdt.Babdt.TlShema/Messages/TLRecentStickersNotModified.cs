﻿using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(186120336)]
  public class TLRecentStickersNotModified : TLAbsRecentStickers
  {
    public override int Constructor => 186120336;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
