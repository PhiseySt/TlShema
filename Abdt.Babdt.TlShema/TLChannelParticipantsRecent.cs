﻿using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-566281095)]
  public class TLChannelParticipantsRecent : TLAbsChannelParticipantsFilter
  {
    public override int Constructor => -566281095;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}