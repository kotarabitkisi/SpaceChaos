using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public GameObject GameManager;
    [SerializeField] Rigidbody rb;
    public Image healthbar,Expbar,Shootbar;
    public int level;
    public float speed,damage,health,maxhealth,BulletSpeed,AttackSpeed,MaxShootCooldown,CurrentShootCooldown,Exp,MaxExp;

    void Update()
    {
        CurrentShootCooldown -= AttackSpeed*Time.deltaTime;
        Shootbar.fillAmount = (MaxShootCooldown-CurrentShootCooldown)/MaxShootCooldown;
        healthbar.fillAmount = health / maxhealth;
        Expbar.fillAmount = Exp / MaxExp;
    }
    public void Takedamage(float BulletDamage)
    {
        health -= BulletDamage;
        if (health <= 0) { Die(); }
    }
    public void Die()
    {
        GameManager.GetComponent<LevelManager>().Losing();
        rb.useGravity = true;
        rb.AddTorque(new Vector3(1, Random.Range(-1f, 1f), Random.Range(-1f, 1f)), ForceMode.Impulse);
        Invoke("Destroy", 5);

    }
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
    public void ControlExp()
    {
        if (Exp >= MaxExp)
        {
            Exp = 0;
            level++;
            speed = 5 * level * (level - 1);
            maxhealth = level * (level - 1) * 5;
            health = level * (level - 1) * 5;
            MaxExp = level * (level - 1) * 5;
            damage = level * (level - 1) * 5;
            AttackSpeed = (level + 2) * 5;
            BulletSpeed= level * 5;
        }
    }
}
