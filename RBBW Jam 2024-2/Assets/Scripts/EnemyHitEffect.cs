using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHitEffect : MonoBehaviour
{
    [SerializeField]UnityEvent onSpawn;
    private void Awake()
    {
        onSpawn.Invoke();
        StartCoroutine(destroyAfterTime(2f));
    }

    private IEnumerator destroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
