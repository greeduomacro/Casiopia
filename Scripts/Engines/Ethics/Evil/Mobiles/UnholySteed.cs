using System;
using Server;
using Server.Mobiles;
using Server.Ethics;

namespace Server.Mobiles
{
	[CorpseName( "an unholy corpse" )]
	public class UnholySteed : BaseMount
	{
		public override bool IsDispellable { get { return true; } }
		public override bool IsBondable { get { return false; } }

		public override bool HasBreath { get { return false; } }
		public override bool CanBreath { get { return false; } }

		public override string DefaultName{ get{ return "a dark steed"; } }

		[Constructable]
		public UnholySteed()
			: base( 0x74, 0x3EA7, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			SetStr( 496, 525 );
			SetDex( 86, 105 );
			SetInt( 86, 125 );

			SetHits( 298, 315 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 80.5, 92.5 );

			Fame = 7000;
			Karma = -7000;

			VirtualArmor = 60;

			Tamable = false;
			ControlSlots = 1;
		}

		public override FoodType FavoriteFood { get { return FoodType.FruitsAndVeggies | FoodType.GrainsAndHay; } }

		public UnholySteed( Serial serial )
			: base( serial )
		{
		}

		public override string ApplyNameSuffix( string suffix )
		{
			if ( suffix.Length == 0 )
				suffix = Ethic.Evil.Definition.NPCAdjunct.String;
			else
				suffix = String.Concat( suffix, " ", Ethic.Evil.Definition.NPCAdjunct.String );

			return base.ApplyNameSuffix( suffix );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Ethic.Find( from ) != Ethic.Evil )
				from.SendMessage( "You may not ride this steed." );
			else
				base.OnDoubleClick( from );
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