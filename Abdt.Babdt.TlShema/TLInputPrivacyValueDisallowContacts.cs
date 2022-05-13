﻿using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(195371015)]
  public class TLInputPrivacyValueDisallowContacts : TLAbsInputPrivacyRule
  {
    public override int Constructor => 195371015;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
