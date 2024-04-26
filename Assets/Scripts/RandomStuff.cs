using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStuff : MonoBehaviour
{
    [SerializeField] GameObject[] stuffPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StuffSpawn());
    }

    IEnumerator StuffSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(stuffPrefab[Random.Range(0, stuffPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 10f);
        }
    }
}
