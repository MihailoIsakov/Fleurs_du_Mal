using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HexMap : MonoBehaviour {

	//shift vectors. Move along.
	static Vector3 shiftY = new Vector3 (0, 0, Mathf.Sqrt (3));
	static Vector3 shiftX = new Vector3 (1.5f, 0, Mathf.Sqrt(3) / 2.0f);

	public float pondChance = 0.05f;

	public GameObject selected = null;

	public Dictionary<Vector2, GameObject> map = new Dictionary<Vector2, GameObject>();
	
	public static HexMap Instance { get; private set;}	
	
	void Awake() { //singleton
		if (Instance != null && Instance != this) {
			Destroy(gameObject);		
		}
		Instance = this;
		createMap();

//		GameObject prvi = map [new Vector2(5, 0)];		//Testiranje distance
//		GameObject drugi = map [new Vector2(2,3)];
//		prvi.GetComponent<MeshRenderer> ().material = Resources.Load ("Materials/ruza") as Material;
//		drugi.GetComponent<MeshRenderer> ().material = Resources.Load ("Materials/korov") as Material;
//		float daljina = AssemblyCSharp.HexMath.distance (prvi,drugi);
//		Debug.Log(daljina);
//
//		List<GameObject> listaKomsija = AssemblyCSharp.HexMath.neighbours ( (int) prvi.GetComponent<Tile>().position.x , (int)prvi.GetComponent<Tile>().position.y, 2 );
//
//		foreach (GameObject g in listaKomsija)
//		{
//			Debug.Log( g.GetComponent<Tile>().position.x + "," + g.GetComponent<Tile>().position.y );
//
//		}
	}
	
	void createMap () {
		Object landTile = Resources.Load("Prefabs/EarthTile");
		Object pondTile = Resources.Load("Prefabs/PondTile");
		
		GameObject tile;

		int Dim = 5; //Dimenzija terena
		int UpperOff = 0;
		int LowerOff = 0;


	for (int y = -Dim ; y <= Dim; y++)
		{
			for (int x = 0-LowerOff; x <= Dim-UpperOff; x++)
			{ 
				if (pondChance > Random.value) 
					tile = Instantiate (pondTile, transform.position + x * shiftX + y * shiftY, transform.rotation) as GameObject;
				else
					tile = Instantiate (landTile, transform.position + x * shiftX + y * shiftY, transform.rotation) as GameObject;
			
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

