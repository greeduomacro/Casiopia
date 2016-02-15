using System;
using Server;

namespace Server.Items
{
	public class TravestysCollectionOfShells : Item
	{
		public override int LabelNumber{ get{ return 1072090; } } // Travesty's Collection of Shells

		[Constructable( AccessLevel.Owner )]
		public TravestysCollectionOfShells() : base( 0xFD3 )
		{
		}

		public TravestysCollectionOfShells( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}

