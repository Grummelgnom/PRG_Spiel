using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomColor : MonoBehaviour
{
    [SerializeField] private float changeInterval = 1.0f;
    [SerializeField] private Image image;
    private float localChangeInterval;

    // Start is called before the first frame update
    void Start()
    {
        localChangeInterval = 0f;

        image.color = new Color(Random.value, Random.value, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        localChangeInterval += Time.deltaTime;

        if (localChangeInterval < changeInterval) return;

        localChangeInterval -= changeInterval;
        image.color = new Color(Random.value, Random.value, Random.value) ;
        image.rectTransform.localScale = new Vector3(Random.value, Random.value, Random.value);
    }
}
