using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] EnemyStat stat;
    [SerializeField] Rigidbody rb;
  public int side;
    [SerializeField] float speed, Xrot, Zrot, RotSpeed;

    private void FixedUpdate()
    {


        if (stat.health > 0) {
        if (side==1)
            {
            rb.AddForce(new Vector3(1, 0, 0) * speed);
            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -3, 3), Mathf.Clamp(rb.velocity.y, -3, 3), 0);
            Zrot -= 1 * RotSpeed;
            }
            else if (side==2)
            {
            rb.AddForce(new Vector3(-1, 0, 0) * speed);
            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -3, 3), Mathf.Clamp(rb.velocity.y, -3, 3), 0);
            Zrot += 1 * RotSpeed;
            }
        
        Xrot = Mathf.Clamp(Xrot, -30, 30);
        Zrot = Mathf.Clamp(Zrot, -30, 30);
        transform.rotation = Quaternion.Euler(Xrot, 0, Zrot);
        }
            
        

    }
}
