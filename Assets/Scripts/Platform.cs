using UnityEngine;
using System.Collections;

public enum Side {Left, Right};
public enum Axis {X,Y,Z};

public class Platform : MonoBehaviour {
	
	public WeightedObject[] objects;
	
	private float balanceDegree = 0;
	
	private float massLeft = 0;
	private float massRight = 0;
	
	
	private Quaternion initialRotation;
	
	public Axis axisOfRotation = Axis.X; 
	public float rotationSpeed = .001f;
	public float massOfPlatform = 10f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		UpdateBalance();
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(balanceDegree,Vector3.forward), Time.time*rotationSpeed);
	}
	
	private void UpdateBalance() {
		//update mass on each side
		massRight = massLeft = massOfPlatform/2f;
		foreach(WeightedObject obj in objects){
			if(obj.IsGrounded()) {
				float distance = DistanceFromAxisOfRotation(obj);
				if(distance > 0){
					massRight += (Mathf.Abs(distance)/3)*obj.mass;
				}
				else {
					massLeft += (Mathf.Abs(distance)/3)*obj.mass;
				}
			}
		}
		
		if(massRight > massLeft) {
			balanceDegree = -20f*((massRight-massLeft)/massRight);
		}
		if(massRight < massLeft){
			balanceDegree = 20f*((massLeft-massRight)/massLeft);
		}
		if(massRight == massLeft) {
			balanceDegree = 0;
		}
	}
	
	//positive distances are on the right side of balance, negative distances are on the left
	private float DistanceFromAxisOfRotation (WeightedObject obj) {
		float distance;
		switch(axisOfRotation){
			case Axis.X:
				distance = Vector2.Distance(new Vector2(Center().y,Center().z), new Vector2(obj.CenterOfMass().y, obj.CenterOfMass().z));
				if (obj.CenterOfMass().z > Center().z)
					return distance;
				return -distance;
			case Axis.Y:
				distance = Vector2.Distance(new Vector2(Center().x,Center().z), new Vector2(obj.CenterOfMass().x, obj.CenterOfMass().z));
				if (obj.CenterOfMass().x > Center().x)
					return distance;
				return -distance;
			case Axis.Z:
				distance = Vector2.Distance(new Vector2(Center().x,Center().y), new Vector2(obj.CenterOfMass().x, obj.CenterOfMass().y));
				if (obj.CenterOfMass().x > Center().x)
					return distance;
				return -distance;
			default:
				return 999;
		}
		
		
	}
	
	
	
	public Vector3 Center() {
		return transform.position;
	}
	
	public Quaternion Rotation() {
		return transform.rotation;
	}
	
	/*
	void AddWeightedObject(WeightedObject obj) {
		
	}
	*/
}
