﻿using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(928101534)]
  public class TLInputMessagesFilterMusic : TLAbsMessagesFilter
  {
    public override int Constructor => 928101534;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
