using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPopUpAnimator : MonoBehaviour
{

    public GameObject[] objects;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        StartCoroutine("PopUpObject");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PopUpObject(){
		foreach (GameObject obj in objects)
		{
			yield return new WaitForSeconds(delay);
			obj.SetActive(true);			
            for (int i = 0; i < obj.transform.childCount; ++i)
            {
                obj.transform.GetChild(i).gameObject.SetActive(true);
            }		
		}
	}
}
