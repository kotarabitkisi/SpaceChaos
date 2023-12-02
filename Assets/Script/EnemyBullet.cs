using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject Pooler;
    public float BulletDamage, BulletSpeed;
    private void OnEnable()
    {
        Invoke("Disable", 5);
    }
    void Update()
    {
        transform.Translate(BulletSpeed*Vector3.down*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Stats>().Takedamage(BulletDamage);
            Disable();
        }
    }
    void Disable()
    {
        transform.parent = Pooler.transform;
        gameObject.SetActive(false);
    }
}
