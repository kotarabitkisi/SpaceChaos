using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Pooler;
    public float BulletDamage, BulletSpeed;
    private void OnEnable()
    {
        Invoke("Disable",5);
    }
    void Update()
    {
        transform.Translate(BulletSpeed*Vector3.up*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyStat>().Takedamage(BulletDamage);
            Disable();
        }
        if (other.gameObject.tag == "Boss")
        {
            other.gameObject.GetComponent<BossStats>().Takedamage(BulletDamage);
            Disable();
        }
    }
    void Disable()
    {
        this.gameObject.transform.parent = Pooler.transform;
        gameObject.SetActive(false);
    }
}
