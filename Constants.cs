using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrawlCharacterManager {
	public class Constants {
		public static string[] KirbyHats = {
			"donkey", "falco", "pikmin", "purin", "snake"
		};

		public static string[] CharactersByCSSOrder = {
			"mario",
			"donkey",
			"link",
			"samus",
			"yoshi",
			"kirby",
			"fox",
			"pikachu",
			"luigi",
			"captain",
			"ness",
			"koopa",
			"peach",
			"zelda",
			"sheik",
			"popo",
			"marth",
			"gamewatch",
			"falco",
			"ganon",
			null,
			"metaknight",
			"pit",
			"szerosuit",
			"pikmin",
			"lucas",
			"diddy",
			"poketrainer",
			"pokelizardon",
			"pokezenigame",
			"pokefushigisou",
			"dedede",
			"lucario",
			"ike",
			"robot",
			null,
			"purin",
			"wario",
			null,
			null,
			"toonlink",
			null,
			null,
			"wolf",
			null,
			"snake",
			"sonic",
		};

		public static string[] TexturesToDisable = {
			"SamusRef", "SamusTexASpc", "SamusTexBSpc", "SamusTexC", "SamusTexD", "SamusTexDSpc", "Spe",
			"Yoshi_Egg",
			"PlyKirby5KEyeYellow.1",
			"Pikachu_eyesYellow.00",
			"FitSonicBodyMask", "FitSonicHeadMask", "FitSonicEnv01", "FitSonicEnv04", "FitSonicSphere",
		};

		public static Dictionary<string,int[]> PolygonsToDisable = new Dictionary<string,int[]> {
			{"ness", new int[] {1,2,5,6}},
		};
	}
}
