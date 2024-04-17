using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingCharacter : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [HideInInspector]
    public bool isDragging = false;
    public TextMeshProUGUI ChineseText;
    private FloatingWordGamePage parent;
    private RectTransform rectTransform;
    private Vector2 screenSize;//屏幕大小
    private Vector2 offset;//拖拽偏移量
    private Vector2 moveDirection;//移动方向
    private bool isTweening;//当前对象是否正在播放Tween动画
    private void Start()
    {
        parent = FindObjectOfType<FloatingWordGamePage>();
        screenSize = parent.screenSize;
        rectTransform = GetComponent<RectTransform>();
        InitializeCharacter();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetFloatingCharactersRandomPos();
    }
    private void Update()
    {
        if (!isDragging) // 当不处于拖拽状态时才执行漂浮功能
        {
            UpdateFloatingPosition();
        }
    }
    private void InitializeCharacter()
    {
        GetFloatingCharactersRandomPos();
        // 随机初始化移动方向
        moveDirection = Random.insideUnitCircle.normalized;
    }
    private void UpdateFloatingPosition()
    {
        // 获取当前位置
        Vector2 pos = rectTransform.anchoredPosition;
        // 如果漂浮对象超出父类边界，改变漂浮方向
        if (pos.x < -(screenSize.x / 2) || pos.x > (screenSize.x / 2) || pos.y < -(screenSize.y / 2 / 2) || pos.y > (screenSize.y / 2))
        {
            ChangeMoveDirection();
        }
        // 更新位置
        pos += 50f * Time.deltaTime * moveDirection; // 根据速度调整位置
        rectTransform.anchoredPosition = pos;
    }
    private void ChangeMoveDirection()
    {
        // 在碰到屏幕边界时，随机改变移动方向
        moveDirection = Random.insideUnitCircle.normalized;
    }
    public void GetFloatingCharactersRandomPos()
    {
        if (isTweening || isDragging)
            return;
        float randomX = Random.Range(-(screenSize.x / 2), screenSize.x / 2);
        float randomY = Random.Range(-(screenSize.y / 2 / 2), screenSize.y / 2);
        Vector2 randomVector2 = new Vector2(randomX, randomY);
        RectTransform floatingCharacterPos = GetComponent<RectTransform>();
        floatingCharacterPos.DOAnchorPos(randomVector2, 0.1f)
            .OnPlay(() =>
            {
                isTweening = true;
            })
            .OnComplete(() =>
            {
                isTweening = false;
            });
    }
    //开始拖拽
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isTweening)
            return;
        isDragging = true;
        //计算点击点与漂浮对象左下角的偏移
        offset = rectTransform.anchoredPosition - eventData.position;
    }
    //拖拽中
    public void OnDrag(PointerEventData eventData)
    {
        if (isTweening)
            return;
        //更新漂浮对象位置
        Vector2 pos = eventData.position + offset;
        pos.x = Mathf.Clamp(pos.x, -(screenSize.x / 2), screenSize.x / 2);
        pos.y = Mathf.Clamp(pos.y, -(screenSize.y / 2), screenSize.y / 2);
        rectTransform.anchoredPosition = pos;
    }
    //拖拽结束
    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        if (rectTransform.anchoredPosition.y < -(screenSize.y / 2 / 2))
        {
            GetFloatingCharactersRandomPos();
        }
    }
}
