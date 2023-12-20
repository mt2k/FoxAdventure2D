using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Showme"+this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length.ToString());
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(DestroyOver());
    }

    //private IEnumerator DestroyOver()
    //{
    //    deathEffectSetup.enabled = false;
    //    yield return new WaitForSeconds(lifeTime);
    //}
}
