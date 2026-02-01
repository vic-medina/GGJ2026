using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public EnemyClass enemyClass;
    public MaskManager maskManager;
    public EnemyAttack enemyAttack;

    public int maskToIgnore;
    public bool checkMask;

    public void Awake()
    {

    }

    private void Update()
    {
        if (!checkMask)
        { return; }

        CheckMask();

    }

    private void CheckMask()
    {
        if (maskManager != null && maskManager.currentMask != maskToIgnore)
        {
            enemyClass.chasingPlayer = true;
            enemyClass.playerTf = maskManager.transform;
            enemyAttack.isAttacking = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("Entro");
        maskManager = collision.GetComponent<MaskManager>();
        checkMask = true;
        //CheckMask(); 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.LogWarning("Salio");
        checkMask = false;
        enemyClass.chasingPlayer = false;
        enemyClass.playerTf = null;
        enemyAttack.isAttacking = false;
    }
}
