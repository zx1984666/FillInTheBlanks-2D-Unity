using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour, IDropHandler
{
    public TextMeshProUGUI ChineseText;//汉字字符
    [HideInInspector]
    public bool IsOccupied = false;//当前格子是否被占领
    public bool IsFixedSlot;//手动设定,当前格子是否是固定文字格子
    private FloatingWordGamePage parentPage;
    private FloatingCharacter currentCharacter;
    private Button thisBtn;
    private void Awake()
    {
        if (!IsFixedSlot)
        {
            thisBtn = GetComponent<Button>();
            thisBtn.onClick.AddListener(SlotOnClickEvent);
        }
        if (IsFixedSlot)
        {
            IsOccupied = true;
        }
        parentPage = GetComponentInParent<FloatingWordGamePage>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (currentCharacter != null || IsFixedSlot)
            return;
        //在字符栏中放置汉字对象
        currentCharacter = eventData.pointerDrag.GetComponent<FloatingCharacter>();
        if (currentCharacter != null && !IsOccupied)
        {
            //放置汉字对象到字符栏中
            ChineseText.text = currentCharacter.ChineseText.text;
            IsOccupied = true;
            //隐藏拖拽过来的汉字
            currentCharacter.gameObject.SetActive(false);
            parentPage.CheckWinCondition();
        }
    }
    private void SlotOnClickEvent()
    {
        if (currentCharacter != null)
        {
            ChineseText.text = "";
            currentCharacter.gameObject.SetActive(true);
            currentCharacter.isDragging = false;
            currentCharacter.GetFloatingCharactersRandomPos();
            IsOccupied = false;
            currentCharacter = null;
        }
    }
}