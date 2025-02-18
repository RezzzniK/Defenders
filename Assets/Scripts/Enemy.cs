
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Explosion;
    [SerializeField] int enemyHitPoints=8;
    [SerializeField] int scoreValue=10;
    ScoreBoard score;
    
    void Start (){
        score=FindFirstObjectByType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        hitingEnemy();
    }

    private void hitingEnemy()
    {
        enemyHitPoints -= 1;
        if (enemyHitPoints <= 0)
        {
            
            Instantiate(Explosion, transform.position, Quaternion.identity/*0,0,0*/);
            Destroy(this.gameObject);
            score.updateScore(scoreValue);
            
        }
    }


}
