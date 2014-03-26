using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public static class HexMath	{

		
		public static float distance(float x1, float y1, float x2, float y2) { //returns the distance between two hexes
			return (Mathf.Abs(x1 - x2) + Mathf.Abs(y1 - y2) + Mathf.Abs(x2 + y2 - x1 - y1)) / 2;		
		}

		public static float distance(Tile t1, Tile t2) {
			return distance(t1.position.x, t1.position.y, t2.position.x, t2.position.y);
		}
		
		public static float distance(GameObject t1, GameObject t2) {
			return distance(t1.GetComponent<Tile>(), t2.GetComponent<Tile>());
		}

		public static List<GameObject> neighbours(int cx, int cy, int range) { //gets the neighbouring tiles of the field at coordinates x,y 
						List<GameObject> neighbourList = new List<GameObject> ();
						int UpperOff = 0;
						int LowerOff = 0;
			
				for (int y = cy-range; y <= cy+range; y++) 
					{
						for (int x = cx-LowerOff; x <= cx+range-UpperOff; x++)
							{ 
								if (!(cx == x && cy == y)) { // Da ne bi stavio samog sebe
										// Ovde implementirati sta se smatra korisnim susedom
										try
										{
										neighbourList.Add( HexMap.Instance.map[new Vector2 (x, y)] );
										}
										catch (KeyNotFoundException e)
											{
											}
										}
							}
								if (LowerOff < range)
										LowerOff++;
								else if (UpperOff < range)
										UpperOff++;
						}
			return neighbourList;
		}
		public static List<GameObject> neighbours(GameObject g, int range)
		{
			return neighbours((int)g.GetComponent<Tile> ().position.x,(int) g.GetComponent<Tile> ().position.y, range);	
		}


	}
}



