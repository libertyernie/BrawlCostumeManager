using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrawlCostumeManager {
	public class Constants {
		public static string[] KirbyHats = {
			"donkey", "falco", "mewtwo", "pikmin", "purin", "snake"
		};

		public class Fighter {
			public string Name { get; private set; }
			public byte CharBustTexIndex { get; private set; }

			public Fighter(string Name, byte CharBustTexIndex) {
				this.Name = Name;
				this.CharBustTexIndex = CharBustTexIndex;
			}
		}

		public static Fighter[] KnownFighters = {
			new Fighter("mario", 0),
			new Fighter("donkey", 1),
			new Fighter("link", 2),
			new Fighter("samus", 3),
			new Fighter("yoshi", 4),
			new Fighter("kirby", 5),
			new Fighter("fox", 6),
			new Fighter("pikachu", 7),
			new Fighter("luigi", 8),
			new Fighter("captain", 9),
			new Fighter("ness", 10),
			new Fighter("koopa", 11),
			new Fighter("peach", 12),
			new Fighter("zelda", 13),
			new Fighter("sheik", 14),
			new Fighter("popo", 15),
			new Fighter("marth", 16),
			new Fighter("gamewatch", 17),
			new Fighter("falco", 18),
			new Fighter("ganon", 19),
			new Fighter("metaknight", 21),
			new Fighter("pit", 22),
			new Fighter("szerosuit", 23),
			new Fighter("pikmin", 24),
			new Fighter("lucas", 25),
			new Fighter("diddy", 26),
			new Fighter("mewtwo", 27), // PM 3.0
			new Fighter("poketrainer", 27),
			new Fighter("pokelizardon", 28),
			new Fighter("pokezenigame", 29),
			new Fighter("pokefushigisou", 30),
			new Fighter("dedede", 31),
			new Fighter("lucario", 32),
			new Fighter("ike", 33),
			new Fighter("robot", 34),
			new Fighter("purin", 36),
			new Fighter("wario", 37),
			new Fighter("roy", 39), // PM 3.0
			new Fighter("toonlink", 40),
			new Fighter("wolf", 43),
			new Fighter("snake", 45),
			new Fighter("sonic", 46),
			new Fighter("cloud", 111),
		};

		public static int CharBustTexFor(string name) {
			return (from f in KnownFighters
					where f.Name == name
					select f.CharBustTexIndex).FirstOrDefault();
		}

		public static Dictionary<int, int[]> PortraitToCostumeMappings = new Dictionary<int, int[]>() {
			{0, new int[] {0,6,3,4,5,2}},
			{1, new int[] {0,4,1,3,2,5}},
			{2, new int[] {0,1,3,5,6,4}},
			{3, new int[] {0,3,1,5,4,2}},
			{4, new int[] {0,1,3,4,5,6}},
			{5, new int[] {0,4,3,1,2,5}},
			{6, new int[] {0,4,1,2,3,5}},
			{7, new int[] {0,1,2,3}},
			{8, new int[] {0,5,1,3,4,6}},
			{9, new int[] {0,4,1,2,3,5}},
			{10, new int[] {0,5,4,2,3,6}},
			{11, new int[] {0,4,1,3,5,6}},
			{12, new int[] {0,5,1,3,2,4}},
			{13, new int[] {0,1,3,5,2,4}},
			{14, new int[] {0,1,3,5,2,4}},
			{15, new int[] {0,1,3,4,2,5}},
			{16, new int[] {0,1,2,4,5,3}},
			{17, new int[] {0,1,2,3,4,5}},
			{18, new int[] {0,5,3,1,2,4}},
			{19, new int[] {0,4,3,2,1,5}},
			{21, new int[] {0,4,1,2,3,5}},
			{22, new int[] {0,4,1,2,3,5}},
			{23, new int[] {0,3,1,5,4,2}},
			{24, new int[] {0,4,1,5,2,3}},
			{25, new int[] {0,4,1,3,2,5}},
			{26, new int[] {0,5,4,6,2,3}},
			{27, new int[] {0,1,2,3,4}},
			{28, new int[] {0,1,2,3,4}},
			{29, new int[] {0,1,2,3,4}},
			{30, new int[] {0,1,2,3,4}},
			{31, new int[] {0,6,2,5,3,4}},
			{32, new int[] {0,1,4,5,2}},
			{33, new int[] {0,5,1,3,2,4}},
			{34, new int[] {0,6,5,4,3,2}},
			{36, new int[] {0,1,4,3,2}},
			{37, new int[] {0,1,5,2,4,3,6,7,9,8,10,11}},
			{40, new int[] {0,1,3,4,5,6}},
			{43, new int[] {0,1,4,2,3,5}},
			{45, new int[] {0,1,3,4,2,5}},
			{46, new int[] {0,5,4,2,1}},
		};

		public static Dictionary<int, int[]> PM30Mappings = new Dictionary<int, int[]>() {
			{0, new int[] {0,6,3,2,5,7,11,8,9,10}},
			{1, new int[] {0,4,1,3,2,5,6}},
			{2, new int[] {0,1,3,5,6,4,7,8,9}},
			{4, new int[] {0,1,3,4,5,6,7,8,9,10}},
			{6, new int[] {0,4,1,2,3,5,6,7,8,9}},
			{7, new int[] {0,1,2,3,4,5}},
			{8, new int[] {0,5,1,3,4,6,7}},
			{10, new int[] {0,5,4,2,3,6,7}},
			{11, new int[] {0,4,1,3,5,6,7}},
			{12, new int[] {0,5,1,3,2,4,7,6}},
			{18, new int[] {0,5,3,1,2,4,6,7,8,9}},
			{21, new int[] {0,4,1,2,3,5,6}},
			{24, new int[] {0,4,1,5,2,3,6}},
			{25, new int[] {0,4,1,3,2,5,6}},
			{27, new int[] {0,1,2,3,4,5,6}},
			{28, new int[] {0,1,2,3,4,5}},
			{29, new int[] {0,1,2,3,4,5}},
			{30, new int[] {0,1,2,3,4,5}},
			{32, new int[] {0,1,4,5,2,6}},
			{34, new int[] {0,6,5,4,3,2,7}},
			{36, new int[] {0,1,4,3,2,5,6}},
			{37, new int[] {6,7,10,8,11,9,0,1,3,2,5,4}},
			{40, new int[] {0,1,3,4,5,6,7}},
			{43, new int[] {0,1,4,2,3,5,6}},
		};
	}
}
