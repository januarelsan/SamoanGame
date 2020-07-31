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
    [Header("Sprites")]
    [SerializeField] private Sprite[] alphabetSprites; //0
    [SerializeField] private Sprite[] animalSprites; //0
    [SerializeField] private Sprite[] bodySprites; //2
    [SerializeField] private Sprite[] colorSprites; //1
    [SerializeField] private Sprite[] clothSprites; //1
    [SerializeField] private Sprite[] daySprites; //3
    [SerializeField] private Sprite[] emoticonSprites; //4
    [SerializeField] private Sprite[] familySprites; //5    
    [SerializeField] private Sprite[] fruitSprites; //6
    [SerializeField] private Sprite[] monthSprites; //7
    [SerializeField] private Sprite[] numberSprites; //8
    [SerializeField] private Sprite[] objectSprites; //9    
    [SerializeField] private Sprite[] vegetableSprites; //10
    [SerializeField] private Sprite[] weatherSprites; //11
    
    // ========== End Sprite Categories ========== 

    // ========== Start Clip Categories ==========  
    [Header("Clips")]
    [SerializeField] private AudioClip[] alphabetClips;
    [SerializeField] private AudioClip[] animalClips;
    [SerializeField] private AudioClip[] bodyClips;
    [SerializeField] private AudioClip[] colorClips;
    [SerializeField] private AudioClip[] clothClips;
    [SerializeField] private AudioClip[] dayClips;
    [SerializeField] private AudioClip[] emoticonClips;
    [SerializeField] private AudioClip[] familyClips;
    [SerializeField] private AudioClip[] fruitClips;
    [SerializeField] private AudioClip[] monthClips;
    [SerializeField] private AudioClip[] numberClips;
    [SerializeField] private AudioClip[] objectClips;
    [SerializeField] private AudioClip[] vegetableClips;
    [SerializeField] private AudioClip[] weatherClips;
    
    // ========== End Clip Categories ========== 
    
    //
    [SerializeField] private GameObject card;
    [SerializeField] private Transform cardSlide;
    
    private List<GameObject> cardList = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {

        
        selectedCategory = GameData.Instance.FlashCardCategory;

        //Alphabets
        categorySpriteList.Add(alphabetSprites);
        categoryClipList.Add(alphabetClips);

        //Number
        categorySpriteList.Add(numberSprites);
        categoryClipList.Add(numberClips);

        //Colors
        categorySpriteList.Add(colorSprites);
        categoryClipList.Add(colorClips);

        //Days
        categorySpriteList.Add(daySprites);
        categoryClipList.Add(dayClips);

        //Month
        categorySpriteList.Add(monthSprites);
        categoryClipList.Add(monthClips);

        //Animals
        categorySpriteList.Add(animalSprites);
        categoryClipList.Add(animalClips);

        //Bodys
        categorySpriteList.Add(bodySprites);
        categoryClipList.Add(bodyClips);            

        //Emoticons
        categorySpriteList.Add(emoticonSprites);
        categoryClipList.Add(emoticonClips);

        //Cloths
        categorySpriteList.Add(clothSprites);
        categoryClipList.Add(clothClips);

        //Families
        categorySpriteList.Add(familySprites);
        categoryClipList.Add(familyClips);

        //Fruits
        categorySpriteList.Add(fruitSprites);
        categoryClipList.Add(fruitClips);                

        //Object
        categorySpriteList.Add(objectSprites);
        categoryClipList.Add(objectClips);

        //Vegetable
        categorySpriteList.Add(vegetableSprites);
        categoryClipList.Add(vegetableClips);

        //Weather
        categorySpriteList.Add(weatherSprites);
        categoryClipList.Add(weatherClips);

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
