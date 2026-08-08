using UnityEngine;

public class LadyBug : MonoBehaviour, ITakeLaserDamagable
{
    public void TakeLaserDamage()
    {

        Destroy(gameObject);
    }
}
