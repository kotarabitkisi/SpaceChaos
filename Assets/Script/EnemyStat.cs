using UnityEngine;

public class EnemyStat : MonoBehaviour
{

    GameObject Player;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject Pooler,LevelManager,DieParticle;
    bool canShoot = true;
    
    public int Type,level;
    public float speed, damage, health, maxhealth, BulletSpeed, AttackSpeed, MaxShootCooldown, CurrentShootCooldown,GainExp;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        CurrentShootCooldown -= AttackSpeed * Time.deltaTime;
        if (CurrentShootCooldown <= 0&&canShoot)
        {
        CurrentShootCooldown =MaxShootCooldown;
        Shoot(damage, BulletSpeed);
        }
    }
    public void Shoot(float damage, float speed)
    {
        GameObject ShootedBullet = Pooler.transform.GetChild(0).gameObject;
        ShootedBullet.transform.parent = null;
        ShootedBullet.GetComponent<EnemyBullet>().Pooler = Pooler.gameObject;
        ShootedBullet.gameObject.SetActive(true);
        ShootedBullet.transform.position = transform.position;
        ShootedBullet.transform.rotation = transform.rotation;
        if (Type == 3)
        {
            ShootedBullet.transform.rotation = transform.rotation;
           ShootedBullet.transform.Rotate(Random.Range(-15, 15), 0, Random.Range(-15, 15));
        }
        ShootedBullet.transform.Rotate(90,0,0);
        ShootedBullet.GetComponent<EnemyBullet>().BulletDamage = damage;
        ShootedBullet.GetComponent<EnemyBullet>().BulletSpeed = speed;
    }
    public void Takedamage(float BulletDamage)
    {
        health -= BulletDamage;
        if (health <= 0) { Die();  }
    }
    public void Die()
    {
        DieParticle.SetActive(true);
        Player.GetComponent<Stats>().Exp +=GainExp;
        Player.GetComponent<Stats>().ControlExp();
       canShoot = false;
        rb.useGravity = true;
        rb.AddTorque(new Vector3(15, Random.Range(-15f, 15f), Random.Range(-15f, 15f)), ForceMode.Impulse);
        Invoke("Destroy", 5);
    }
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
