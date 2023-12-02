using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject Pooler;
    private Stats stat;
    private void Start()
    {
        stat= GetComponent<Stats>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.F)&& stat.CurrentShootCooldown<=0)
        {
            
            stat.CurrentShootCooldown = stat.MaxShootCooldown;
            Shoot(stat.damage, stat.BulletSpeed);
        }
    }
    public void Shoot(float damage,float speed)
    {
        GameObject Bullet = Pooler.transform.GetChild(0).gameObject;
        Bullet.GetComponent<Bullet>().Pooler = Pooler;
     Bullet.transform.parent=null;
        Bullet.gameObject.SetActive(true);
        Bullet.transform.position = this.transform.position;
        Bullet.transform.rotation = this.transform.rotation;
        Bullet.transform.Rotate(90,0,0);
        Bullet.GetComponent<Bullet>().BulletDamage = damage;
        Bullet.GetComponent<Bullet>().BulletSpeed = speed;
    }
}
