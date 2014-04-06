using System;
using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour {
	
	public enum TileType {earth, pond, desert};
	public TileType tileType;
	public Material material;

	public Vector2 position; //must be integers
	public float height; 
	public float sunAvailable;
	public float waterAvailable;
	
	void Awake() {
		setTileType(tileType);	
	}

	public Tile (TileType tile, Vector3 pos) {
		tileType = tile;
		position = pos;
		sunAvailable = 1.0f;
		
		switch (tileType) {
			case TileType.earth:
				waterAvailable = 1.0f;
				break;
			case TileType.pond:
				waterAvailable = 1.0f;
				break;
			case TileType.desert:
				waterAvailable = 1.0f;
				break;
			default:
				waterAvailable = 1.0f;
				break;
		}
	}
	
	public void setTileType(TileType type) {
		tileType = type;
		sunAvailable = 1;
		switch(type) {
			case TileType.pond:
				waterAvailable = 5;
				break;
			case TileType.earth:
				waterAvailable = 1;
				break;
			case TileType.desert:
				waterAvailable = 0;
				break;
			default:
				waterAvailable = 1;	
				break;
		}		
	}
}
