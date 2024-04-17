using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingWordGamePage : MonoBehaviour
{
    private GameObject currentActiveCharacterLevel;//当前被激活的字符集关卡
    private GameObject currentActivedSlotLevel;//当前被激活的格子关卡
    private CharacterSlot[] currentSlots;//当前关卡的所有Slot
    private int currentLevelIndex = 0;//当前关卡索引
    [HideInInspector]
    public Vector2 screenSize;//屏幕大小
    [HideInInspector]
    public Canvas parentCanvas;//父对象Canvas
    public Image TipsPanel;//提示页面
    public Button openTipBtn;//打开提示页面按钮
    public RectTransform CharactersTranform;//所有漂浮文字的父类
    public RectTransform CharacterBarsTranform;//字符栏
    public List<string> WinningPhraseList = new List<string>();//获胜汉字集
    public List<GameObject> WinningSlotList = new List<GameObject>();//存放汉字列表
    private void Start()
    {
        //获取屏幕范围
        parentCanvas = GetComponentInParent<Canvas>();
        screenSize = new Vector2(Screen.width - 88, Screen.height - 80);
        SwitchLevel(currentLevelIndex);
        openTipBtn.onClick.AddListener(() =>
        {
            if (!TipsPanel.gameObject.activeSelf)
            {
                TipsPanel.gameObject.SetActive(true);
            }
        });
    }
    /// <summary>
    /// 检查是否达到通关条件
    /// </summary>
    public void CheckWinCondition()
    {
        string currentPhrase = "";//当前字符栏中的字符
        foreach (CharacterSlot slot in currentSlots)
        {
            if (slot.IsOccupied)
            {
                currentPhrase += slot.ChineseText.text;
            }
            else
            {
                currentPhrase += " ";
            }
        }
        if (currentPhrase == WinningPhraseList[currentLevelIndex])
        {
            if (currentLevelIndex < WinningPhraseList.Count - 1)//判断是否最后一关
            {
                currentLevelIndex++;
                currentActiveCharacterLevel.SetActive(false);
                currentActivedSlotLevel.SetActive(false);
                SwitchLevel(currentLevelIndex);
            }
            else
            {
                Debug.Log("通关成功");
                currentLevelIndex = 0;
                currentActiveCharacterLevel.SetActive(false);
                currentActivedSlotLevel.SetActive(false);
            }
        }
    }
    /// <summary>
    /// 切换关卡
    /// </summary>
    /// <param name="levelIndex">关卡索引</param>
    private void SwitchLevel(int levelIndex)
    {
        currentActiveCharacterLevel = CharactersTranform.GetChild(levelIndex).gameObject;
        currentActiveCharacterLevel.SetActive(true);
        currentActivedSlotLevel = CharacterBarsTranform.GetChild(levelIndex).gameObject;
        currentActivedSlotLevel.SetActive(true);
        currentSlots = currentActivedSlotLevel.GetComponentsInChildren<CharacterSlot>();
    }
}
