using UnityEngine;

public class Movement2D : MonoBehaviour {
    // Serializing non-public type
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;           // 3D vectors (0, 0, 0)

    public float MoveSpeed => moveSpeed; 

    private void Update() {
        // Move "transform position" by coordiante * Velocity * T
        transform.position += moveDirection * moveSpeed * Time.deltaTime;    
    }

    public void MoveTo(Vector3 direction) {
        // Called from external to set direction
        moveDirection = direction;
    }
}