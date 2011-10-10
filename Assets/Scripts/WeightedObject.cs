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
    
    bool _isGrounded;
    
    public bool IsGrounded() {
        return _isGrounded;
    }
    
    void OnCollisionEnter(Collision collision) {
        // is on layer for Platform
        if (collision.gameObject && collision.gameObject.layer == 8) {
            _isGrounded = true;
        }
    }
    
    void OnCollisionExit(Collision collision) {
        // is on layer for Platform
        if (collision.gameObject && collision.gameObject.layer == 8) {
            _isGrounded = false;
        }
    }

}
