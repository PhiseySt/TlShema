using System.IO;

namespace Abdt.Babdt.TlShema
{
    [TLObject(1730456516)]
    public class TLTextBold : TLAbsRichText
    {
        public override int Constructor => 1730456516;

        public TLAbsRichText Text { get; set; }

        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br) => this.Text = (TLAbsRichText)ObjectUtils.DeserializeObject(br);

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(this.Constructor);
            ObjectUtils.SerializeObject((object)this.Text, bw);
        }
    }
}
