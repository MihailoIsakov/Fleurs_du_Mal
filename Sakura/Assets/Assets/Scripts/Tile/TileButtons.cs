using UnityEngine;
using System.Collections;

public class TileButtons : MonoBehaviour {
	
	enum Side {LEFT, RIGHT, ABOVE, BELOW};
	
	private GUIStyle style = new GUIStyle();
	
	public int iconSize = 50;
	public int hmargin = 70;
	public int vmargin = 60;
	private GameObject Daisy;
	private GameObject Dandeilon;
	private GameObject Fruit;
	private GameObject Leaf;
	private GameObject Lotus;
	private GameObject Mushroom;
	private GameObject Root;
	private GameObject Rose;
	private GameObject Thorn;
	
	void OnGUI() {
		GameObject selected = HexMap.Instance.selected;
		if (selected != null) { //check if selected exists
			Vector3 screenPos = Camera.main.WorldToScreenPoint(HexMap.Instance.selected.transform.position);
			
			Plant plant = selected.transform.GetComponentInChildren<Plant>(); //get the first plant that comes up.
			setupButtons(screenPos, selected.GetComponent<Tile>() as Tile, plant); 
		}
	}
	
	void setupButtons(Vector3 screenPos, Tile tile, Plant plant) {
		if (plant == null) {//empty tile		
			GameObject selected = HexMap.Instance.selected;
			switch (tile.tileType) {
				case Tile.TileType.earth: //just land
					if (Button(screenPos, Side.LEFT, Plant.PlantType.belarada))
						(Instantiate(Daisy, selected.transform.position, selected.transform.rotation) as GameObject).transform.parent = selected.transform;
						//Instantiate a daisy at the coordinates of the selected transform, and set its parent to be the transform.		
					if (Button(screenPos, Side.ABOVE, Plant.PlantType.leaf))
						(Instantiate(Leaf, selected.transform.position, selected.transform.rotation) as GameObject).transform.parent = selected.transform;
					if (Button(screenPos, Side.RIGHT, Plant.PlantType.ruza))
						(Instantiate(Rose, selected.transform.position, selected.transform.rotation) as GameObject).transform.parent = selected.transform;
					if (Button(screenPos, Side.BELOW, Plant.PlantType.trnje))
						(Instantiate(Thorn, selected.transform.position, selected.transform.rotation) as GameObject).transform.parent = selected.transform;
					break;
				case Tile.TileType.pond: //just water
					if (Button(screenPos, Side.ABOVE, Plant.PlantType.lokvanj))
						(Instantiate(Lotus, selected.transform.position, selected.transform.rotation) as GameObject).transform.parent = selected.transform;
					break;
				default:
					break;
			}
		}
	}
	

	bool Button(Vector3 pos, Side side, Plant.PlantType plantType)  {
		Texture2D tex = getTextureFromType(plantType);
		
		switch (side) {
			case Side.LEFT:
				return (GUI.Button(new Rect(pos.x - iconSize/2 - hmargin, Screen.height - pos.y - iconSize/2, iconSize, iconSize), tex, style));
			case Side.RIGHT:
				return (GUI.Button(new Rect(pos.x - iconSize/2 + hmargin, Screen.height - pos.y - iconSize/2, iconSize, iconSize), tex, style));
			case Side.ABOVE:
				return (GUI.Button(new Rect(pos.x - iconSize/2, Screen.height - pos.y - iconSize/2 - vmargin, iconSize, iconSize), tex, style));
			case Side.BELOW:
				return (GUI.Button(new Rect(pos.x - iconSize/2, Screen.height - pos.y - iconSize/2 + vmargin, iconSize, iconSize), tex, style));
			default:
				return false;
		}
	}
	
	Texture2D getTextureFromType(Plant.PlantType type) {
		Texture2D tex;
		switch (type) {
			case Plant.PlantType.belarada:
				tex = Resources.Load("Textures/belarada_mini") as Texture2D;
				break;
			case Plant.PlantType.leaf:
				tex = Resources.Load ("Textures/list_mini") as Texture2D;
				break;
			case Plant.PlantType.lokvanj:
				tex = Resources.Load ("Textures/lokvanj_mini") as Texture2D;
				break;
			case Plant.PlantType.maslacak:
				tex = Resources.Load ("Textures/maslacak_mini") as Texture2D;
				break;
			case Plant.PlantType.pecurka:
				tex = Resources.Load ("Textures/pecurka_mini") as Texture2D;
				break;
			case Plant.PlantType.ruza:
				tex = Resources.Load ("Textures/ruza_mini") as Texture2D;
				break;
			case Plant.PlantType.trnje:
				tex = Resources.Load ("Textures/trnje_mini") as Texture2D;
				break;
			case Plant.PlantType.vockica:
				tex = Resources.Load ("Textures/vockica_mini") as Texture2D;
				break;		
			default:
				tex = null;
				break;
		}
		return tex;
	}

	void Awake () {
		Daisy = Resources.Load("Prefabs/Plants/DaisyTile") as GameObject;
		Dandeilon = Resources.Load("Prefabs/Plants/DandelionTile") as GameObject;
		Fruit = Resources.Load("Prefabs/Plants/FruitTile") as GameObject;
		Leaf = Resources.Load("Prefabs/Plants/LeafTile") as GameObject;
		Lotus = Resources.Load("Prefabs/Plants/LotusTile") as GameObject;
		Mushroom = Resources.Load("Prefabs/Plants/MushroomTile") as GameObject;
		Root = Resources.Load("Prefabs/Plants/RootTile") as GameObject;
		Rose = Resources.Load("Prefabs/Plants/RoseTile") as GameObject;
		Thorn = Resources.Load("Prefabs/Plants/ThornTile") as GameObject;
		
		style.border = new RectOffset(0, 0, 0, 0);
		
	}

}
