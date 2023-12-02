using System.Collections;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public GameObject Pooler;
    public float AttackCooldown,MaxCooldown;
    public BossStats Stats;

   
    void Update()
    {
        if (Stats.health / Stats.maxhealth < 0.5f)
        {
            MaxCooldown = 3;
        }
        AttackCooldown -= Time.deltaTime;
        if (AttackCooldown <= 0)
        {
            AttackCooldown = MaxCooldown;
           int skillnumber=Random.Range(1,4);
            if (skillnumber == 1)
            {
                StartCoroutine(skill1());
            }
            else if(skillnumber == 2)
            {
                    StartCoroutine(skill2());
            }
            else if (skillnumber == 3)
            {
                StartCoroutine(skill3());
            }
        }
    }
    public IEnumerator skill1() {
        for (int i = 0; i < 15; i++)
        {
        GameObject Bullet = Pooler.transform.GetChild(0).gameObject;
        Bullet.GetComponent<EnemyBullet>().Pooler = Pooler;
        Bullet.transform.parent = null;
        Bullet.gameObject.SetActive(true);
        Bullet.transform.position = this.transform.position;
        Bullet.transform.rotation = this.transform.rotation;
        Bullet.transform.Rotate(4*i-30, 0, 0);
            Bullet.transform.Rotate(90, 0, 0);
            Bullet.GetComponent<EnemyBullet>().BulletDamage = Stats.damage;
        Bullet.GetComponent<EnemyBullet>().BulletSpeed = Stats.BulletSpeed;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        for (int i = 0; i < 15; i++)
        {
            GameObject Bullet = Pooler.transform.GetChild(0).gameObject;
            Bullet.GetComponent<EnemyBullet>().Pooler = Pooler;
            Bullet.transform.parent = null;
            Bullet.gameObject.SetActive(true);
            Bullet.transform.position = this.transform.position;
            Bullet.transform.rotation = this.transform.rotation;
            Bullet.transform.Rotate(0,4 * i - 30, 0);
            Bullet.transform.Rotate(90, 0, 0);
            Bullet.GetComponent<EnemyBullet>().BulletDamage = Stats.damage;
            Bullet.GetComponent<EnemyBullet>().BulletSpeed = Stats.BulletSpeed;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
    public IEnumerator skill2() {
        for (int i = 0; i < 15; i++)
        {
            GameObject Bullet = Pooler.transform.GetChild(0).gameObject;
            Bullet.GetComponent<EnemyBullet>().Pooler = Pooler;
            Bullet.transform.parent = null;
            Bullet.gameObject.SetActive(true);
            Bullet.transform.position = this.transform.position;
            Bullet.transform.rotation = this.transform.rotation;
            Bullet.transform.Rotate(4 * i - 30, 30-4*i, 0);
            Bullet.transform.Rotate(90, 0, 0);
            Bullet.GetComponent<EnemyBullet>().BulletDamage = Stats.damage;
            Bullet.GetComponent<EnemyBullet>().BulletSpeed = Stats.BulletSpeed;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        for (int i = 0; i < 15; i++)
        {
            GameObject Bullet = Pooler.transform.GetChild(0).gameObject;
            Bullet.GetComponent<EnemyBullet>().Pooler = Pooler;
            Bullet.transform.parent = null;
            Bullet.gameObject.SetActive(true);
            Bullet.transform.position = this.transform.position;
            Bullet.transform.rotation = this.transform.rotation;
            Bullet.transform.Rotate(-4 * i + 30, 30 - 4 * i, 0);
            Bullet.transform.Rotate(90, 0, 0);
            Bullet.GetComponent<EnemyBullet>().BulletDamage = Stats.damage;
            Bullet.GetComponent<EnemyBullet>().BulletSpeed = Stats.BulletSpeed;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
    public IEnumerator skill3() {
        for (int i = 0; i < 30; i++)
        {
            transform.position =new Vector3(Random.Range(-23f,23f), Random.Range(-2f,5f), 20);
            GameObject Bullet = Pooler.transform.GetChild(0).gameObject;
            Bullet.GetComponent<EnemyBullet>().Pooler = Pooler;
            Bullet.transform.parent = null;
            Bullet.gameObject.SetActive(true);
            Bullet.transform.position = this.transform.position;
            Bullet.transform.rotation = this.transform.rotation;
            Bullet.transform.Rotate(-4 * i + 30, 30 - 4 * i, 0);
            Bullet.transform.Rotate(90, 0, 0);
            Bullet.GetComponent<EnemyBullet>().BulletDamage = Stats.damage;
            Bullet.GetComponent<EnemyBullet>().BulletSpeed = Stats.BulletSpeed;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}
