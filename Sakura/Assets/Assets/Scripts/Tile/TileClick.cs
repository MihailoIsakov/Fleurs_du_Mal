using UnityEngine;
using System.Collections;

public class TileClick : MonoBehaviour {

	private Material oldMaterial;
	private Material hover;
	
	private float doubleClickStart = 0;
	
	void Start() {
		hover = (Material) Resources.Load("Materials/hover");
	}
	
	void OnMouseUp() {
	
		if ((Time.time - doubleClickStart) < 0.3f)
		{
			this.OnDoubleClick();
			doubleClickStart = -1;
			HexMap.Instance.selected = gameObject;
		}
		else
		{
			doubleClickStart = Time.time;
			HexMap.Instance.selected = null;			
		}
	}
	
	void OnDoubleClick()
	{	}

	void OnMouseEnter() {
		oldMaterial = (Material) ((MeshRenderer) GetComponent<MeshRenderer>()).material;
		GetComponent<MeshRenderer> ().material = hover;
	}

	void OnMouseExit() {
		((MeshRenderer) GetComponent<MeshRenderer>()).material = oldMaterial;
	}

}
