using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	
	public WeightedObject[] objects;
	
	private int balanceDegree = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void UpdateBalance() {
		foreach(WeightedObject obj in objects){
			
		}
	}
	
	Vector3 Center() {
		return transform.position;
	}
	
	Quaternion Rotation() {
		return transform.rotation;
	}
	
	/*
	void AddWeightedObject(WeightedObject obj) {
		
	}
	*/
}
