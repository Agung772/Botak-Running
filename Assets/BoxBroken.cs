using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBroken : MonoBehaviour
{
    bool destroy;
    public new BoxCollider[] collider;

    void Update()
    {
        if (destroy)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 1.5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayScaleCoroutine());
            IEnumerator DelayScaleCoroutine()
            {
                collider[0].isTrigger = false;
                collider[1].isTrigger = false;
                yield return new WaitForSeconds(0.1f);
                collider[0].isTrigger = true;
                collider[1].isTrigger = true;
                yield return new WaitForSeconds(1f);
                destroy = true;
                yield return new WaitForSeconds(2);
                Destroy(gameObject);
            }
        }
    }
}
