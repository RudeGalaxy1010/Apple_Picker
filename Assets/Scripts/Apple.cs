using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Apple : MonoBehaviour
{
    public float Force = 3f;
    private Rigidbody2D Rigidbody;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.AddForce(Vector3.up * Force, ForceMode2D.Impulse);
    }
}
