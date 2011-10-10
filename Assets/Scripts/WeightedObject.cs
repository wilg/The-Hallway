using UnityEngine;
using System.Collections;

public class WeightedObject : MonoBehaviour {

    /*
     * @brief The object's mass in kilograms.
     */
    public float mass = 1.0f;
    
    public Vector3 CenterOfMass() {
        return transform.position;
    }
    
    public Bounds PhysicalBounds() {
        return collider.bounds;
    }

}
