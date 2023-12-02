using UnityEngine;

public class BorderForEnemies : MonoBehaviour
{
    [SerializeField] int chosenside;
    [SerializeField] GameObject[] enemies;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyMovement>().side=chosenside;
            }
        }
    }
}
