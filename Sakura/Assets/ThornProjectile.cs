using UnityEngine;
using System.Collections;

public class ThornProjectile : MonoBehaviour {

	public float speed = 15;

	private Vector3 goal;
	public Vector3 Goal {
				set { 
						goal = value;
						Debug.Log (value);
						gameObject.rigidbody.velocity = (value - gameObject.transform.position).normalized * speed;
				}
				get{
						return goal;
				}
	}

	// Use this for initialization
	void Start () {
		transform.position += new Vector3(0, 0.4f, 0);
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.transform.position == this.goal) { //hit the next in line
				// Ispovredjuj (col.gameObject);
				Destroy(gameObject);
			}
		}	
	}

