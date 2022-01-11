using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class emoticonMenu : MonoBehaviour
{
    public GameObject menu;
    public List<MenuButton> buttons = new List<MenuButton> ();
    public List<Image> emoticonImage = new List<Image> ();
    private Vector2 Mouseposition;
    private Vector2 fromVector2M = new Vector2(0.5f, 1.0f);
    private Vector2 centercircle = new Vector2(0.5f,0.5f);
    private Vector2 toVector2M;
    public int menuItems;
    public int CurMenuItem;
    public Text CurMenuText;
    private int OldMenuItem;
    public float emoShowTime = 2f;
    public Transform character;
    
    // 선택시 이모티콘 2초간 활성화
    IEnumerator EmoticonShow(){
        yield return new WaitForSecondsRealtime(emoShowTime);
        emoticonImage[CurMenuItem].gameObject.SetActive(false);
    }

    // 
    void Start()
    {
        menu.SetActive(false);
        menuItems = buttons.Count;
        foreach(Image emoticon in emoticonImage){
            emoticon.gameObject.SetActive(false);
        }
        CurMenuItem=0;
        OldMenuItem=0;
        
    }

    // Update is called once per frame
    void Update()
    {
        // T를 눌르고 있을 때 메뉴를 활성화 후 선택 가능하게
        if(Input.GetKey(KeyCode.T)){
            menu.SetActive(true);
            GetCurrentMenuItem();
        }
        // T키를 뗐을 때 메뉴표시를 끄고 선택완료
        if(Input.GetKeyUp(KeyCode.T)){
            menu.SetActive(false);
            ButtonAction();
        }
        
    }

    // 메뉴 선택, 전체 프레임에서 마우스포인터의 위치를 받아서 각도에 따라 선택하도록 했다.
    public void GetCurrentMenuItem(){
        Mouseposition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        toVector2M = new Vector2(Mouseposition.x/Screen.width, Mouseposition.y/Screen.height);
        float angle = (Mathf.Atan2(fromVector2M.y-centercircle.y,fromVector2M.x-centercircle.x) - Mathf.Atan2(toVector2M.y-centercircle.y,toVector2M.x-centercircle.x) * Mathf.Rad2Deg);
        if(angle<0){
            angle += 360;
        }
        CurMenuItem = (int)(angle / (360/menuItems));
        CurMenuText.text = buttons[CurMenuItem].name;
        if(CurMenuItem != OldMenuItem){
            buttons[OldMenuItem].sceneImage.color = buttons[OldMenuItem].NormalColor;
            OldMenuItem = CurMenuItem;
            buttons[CurMenuItem].sceneImage.color = buttons[CurMenuItem].HighlightedColor;
        }
    }

    // 일정 범위 이상 움직인 경우 선택
    public void ButtonAction(){
        if((toVector2M.x<=0.45f || toVector2M.x>=0.55f) && (toVector2M.y<=0.45f || toVector2M.y>=0.55f)){
            buttons[CurMenuItem].sceneImage.color = buttons[CurMenuItem].PressedColor;
            Debug.Log(CurMenuItem);
            emoticonImage[CurMenuItem].gameObject.SetActive(true);
            StartCoroutine(EmoticonShow());
        }
    }
}

[System.Serializable]
public class MenuButton{
    public string name;
    public Image sceneImage;
    public Image emoImage;
    public Color NormalColor = Color.white;
    public Color HighlightedColor = Color.grey;
    public Color PressedColor = Color.gray;

}