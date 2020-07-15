using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashCardManager : Singleton<FlashCardManager>
{
    private int selectedCategory;
    private Sprite[] mainSpriteCategory;
    private AudioClip[] mainClipCategory;

    private List<Sprite[]> categorySpriteList = new List<Sprite[]>();
    private List<AudioClip[]> categoryClipList = new List<AudioClip[]>();

    // ========== Start Sprite Categories ==========  
    [SerializeField] private Sprite[] animalSprites; //0
    [SerializeField] private Sprite[] bodySprites; //2
    [SerializeField] private Sprite[] colorSprites; //1
    [SerializeField] private Sprite[] daySprites; //3
    
    // ========== End Sprite Categories ========== 

    // ========== Start Clip Categories ==========  
    [SerializeField] private AudioClip[] animalClips;
    [SerializeField] private AudioClip[] bodyClips;
    [SerializeField] private AudioClip[] colorClips;
    [SerializeField] private AudioClip[] dayClips;
    
    // ========== End Clip Categories ========== 
    
    //
    [SerializeField] private GameObject card;
    [SerializeField] private Transform cardSlide;
    
    private List<GameObject> cardList = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        selectedCategory = GameData.Instance.FlashCardCategory;
        //Animals
        categorySpriteList.Add(animalSprites);
        categoryClipList.Add(animalClips);

        //Bodys
        categorySpriteList.Add(bodySprites);
        categoryClipList.Add(bodyClips);

        //Colors
        categorySpriteList.Add(colorSprites);
        categoryClipList.Add(colorClips);

        //Days
        categorySpriteList.Add(daySprites);
        categoryClipList.Add(dayClips);
        


        mainSpriteCategory = categorySpriteList[selectedCategory];
        mainClipCategory = categoryClipList[selectedCategory];


        SetupCards();
    }

    void SetupCards(){

        for (int i = 0; i < mainSpriteCategory.Length; i++)
        {            
            GameObject Card = Instantiate(card, cardSlide);
            card.transform.GetChild(0).GetComponent<Image>().sprite = mainSpriteCategory[i];
            // card.transform.GetChild(1).GetComponent<Text>().text = mainSpriteCategory[i].name.ToUpper();
            card.transform.GetChild(1).GetComponent<Text>().text = mainSpriteCategory[i].name;
            card.GetComponent<AudioSource>().clip = mainClipCategory[i];
            
            
            
            card.name = i + "_" + mainSpriteCategory[i].name;
            
            cardList.Add(Card);            
        }

        Destroy(cardList[0]);
        cardList.RemoveAt(0);

        // int ii = 0;
        // foreach (var card in cardList)
        // {
        //     Debug.Log("Index: " + ii + " ---- Name: " + card.name);
        //     ii++;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> GetCardList(){
        return cardList;
    }
}
