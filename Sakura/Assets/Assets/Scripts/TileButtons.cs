using UnityEngine;
using System.Collections;

public class TileButtons : MonoBehaviour {
	
	private Texture2D belarada, leaf, lokvanj, maslacak, pecurka, ruza, trnje, vockica;
	private bool bool_belarada, bool_leaf, bool_lokvanj, bool_maslacak, bool_pecurka, bool_ruza, bool_trnje, bool_vockica;
	private GUIStyle style = new GUIStyle();
	
	enum Side {LEFT, RIGHT, ABOVE, BELOW};
	
	public int iconSize = 30;
	public int hmargin = 70;
	public int vmargin = 60;

	void OnGUI() {
		GameObject selected = HexMap.Instance.selected;
		if (selected != null) { //check if selected exists
			Vector3 screenPos = Camera.main.WorldToScreenPoint(HexMap.Instance.selected.transform.position);
			
			setupButtons(screenPos, selected.GetComponent<Tile>() as Tile, selected.GetComponent<Plant>() as Plant); 
		}
	}
	
	void setupButtons(Vector3 screenPos, Tile tile, Plant plant) {
		if (plant == null) //empty tile		
			switch (tile.tileType) {
				case Tile.TileType.earth: //just land
					if (Button(screenPos, Side.LEFT, Plant.PlantType.belarada))
						HexMap.Instance.selected.AddComponent("Belarada");			
					if (Button(screenPos, Side.ABOVE, Plant.PlantType.leaf))
						HexMap.Instance.selected.AddComponent("Leaf");
					if (Button(screenPos, Side.RIGHT, Plant.PlantType.ruza))
						HexMap.Instance.selected.AddComponent("Ruza");
					if (Button(screenPos, Side.BELOW, Plant.PlantType.trnje))
						HexMap.Instance.selected.AddComponent("Trnje");						
					break;
				case Tile.TileType.pond: //just water
					if (Button(screenPos, Side.ABOVE, Plant.PlantType.lokvanj))
						HexMap.Instance.selected.AddComponent("Lokvanj");
					break;
				default:
					break;
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

	void Start () {
		style.border = new RectOffset(0, 0, 0, 0);
	}
}
