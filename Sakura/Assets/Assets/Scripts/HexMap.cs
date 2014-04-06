using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HexMap : MonoBehaviour {

	//shift vectors. Move along.
	static Vector3 SHIFTX = new Vector3 (0, 0, Mathf.Sqrt (3));
	static Vector3 SHIFTY = new Vector3 (1.5f, 0, Mathf.Sqrt(3) / 2.0f);

	const float PONDCHANCE = 0.05f;

	public GameObject selected = null;

	public Dictionary<Vector2, GameObject> map = new Dictionary<Vector2, GameObject>();
	
	public static HexMap Instance { get; private set;}	
	
	void Awake() { //singleton
		if (Instance != null && Instance != this) {
			Destroy(gameObject);		
		}
		Instance = this;
		createMap();
	}
	
	void createMap () {
		HexMath.readNeighbourLists();
	
		Object landTile = Resources.Load("Prefabs/EarthTile");
		Object pondTile = Resources.Load("Prefabs/PondTile");
		
		GameObject tile;

		int Dim = 10; //Dimenzija terena
		int UpperOff = 0;
		int LowerOff = 0;


	for (int y = -Dim ; y <= Dim; y++)
		{
			for (int x = 0-LowerOff; x <= Dim-UpperOff; x++)
			{ 
				if (x == 0 && y == 0)
				{
					tile = Instantiate (landTile, transform.position + x * SHIFTX + y * SHIFTY, transform.rotation) as GameObject;
					tile.AddComponent("Root");
				}
				else if (PONDCHANCE > Random.value) 
					tile = Instantiate (pondTile, transform.position + x * SHIFTX + y * SHIFTY, transform.rotation) as GameObject;
				else
					tile = Instantiate (landTile, transform.position + x * SHIFTX + y * SHIFTY, transform.rotation) as GameObject;
			
				Vector2 position = new Vector2(x, y);
				Tile tileComponent = tile.GetComponent<Tile>();
				tileComponent.position = position;
				tileComponent.height = 0;


				tile.transform.parent = transform;
				map.Add(position, tile);
			}
			if (LowerOff < Dim)
			LowerOff++;
			else if ( UpperOff < Dim )
			UpperOff++;
		}

	
}
}

