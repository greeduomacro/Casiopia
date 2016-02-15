using System;
using Server;

namespace Server.Items
{
	public class Brimstone : BaseReagent, ICommodity
	{
		bool ICommodity.IsDeedable { get { return true; } }
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }

		[Constructable]
		public Brimstone() : this( 1 )
		{
		}

		[Constructable]
		public Brimstone( int amount ) : base( 0xf7f, amount )
		{
		}

		public Brimstone( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}