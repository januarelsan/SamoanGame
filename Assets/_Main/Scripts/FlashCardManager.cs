using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashCardManager : Singleton<FlashCardManager>
{
    private int selectedCategory = 4;
    private Sprite[] mainCategory;

    private List<Sprite[]> categoryList = new List<Sprite[]>();

    // ========== Start Categories ==========  
    [SerializeField] private Sprite[] animalCategory;
    [SerializeField] private Sprite[] dayCategory;
    [SerializeField] private Sprite[] familyCategory;
    [SerializeField] private Sprite[] emoticonCategory;
    [SerializeField] private Sprite[] numberCategory;

    // ========== End Categories ========== 
    
    //
    [SerializeField] private GameObject card;
    [SerializeField] private Transform cardSlide;
    
    private List<GameObject> cardList = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        
        categoryList.Add(animalCategory);
        categoryList.Add(dayCategory);
        categoryList.Add(familyCategory);
        categoryList.Add(emoticonCategory);
        categoryList.Add(numberCategory);

        mainCategory = categoryList[selectedCategory];

        SetupCards();
    }

    void SetupCards(){

        for (int i = 0; i < mainCategory.Length; i++)
        {            
            GameObject Card = Instantiate(card, cardSlide);
            card.transform.GetChild(0).GetComponent<Image>().sprite = mainCategory[i];
            
            cardList.Add(Card);            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> GetCardList(){
        return cardList;
    }
}
