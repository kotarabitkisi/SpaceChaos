using UnityEngine;
using UnityEngine.UI;

public class BossStats : MonoBehaviour
{
    public Image BossHealthBar;
    GameObject Player;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject Pooler, LevelManager;
    bool canShoot = true;

    public int Type, level;
    public float speed, damage, health, maxhealth, BulletSpeed, AttackSpeed, MaxShootCooldown, CurrentShootCooldown, GainExp;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        BossHealthBar.fillAmount = health / maxhealth;
    }
    public void Takedamage(float BulletDamage)
    {
        health -= BulletDamage;
        if (health <= 0) { Die(); }
    }
    public void Die()
    {
        Player.GetComponent<Stats>().Exp += GainExp;
        Player.GetComponent<Stats>().ControlExp();
        canShoot = false;
        rb.useGravity = true;
        rb.AddTorque(new Vector3(1, Random.Range(-1f, 1f), Random.Range(-1f, 1f)), ForceMode.Impulse);
        Invoke("Destroy", 5);
    }
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
