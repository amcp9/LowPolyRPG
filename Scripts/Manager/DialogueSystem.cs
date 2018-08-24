using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 对话系统单例
/// </summary>
public class DialogueSystem : MonoBehaviour
{
    
    #region singleton
    public static DialogueSystem Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion


    private List<string> dialogues = new List<string>();//总对话集合

    private string npcName;                             //对话的NPC姓名
    private int index = 0;                              //索引

    public GameObject dialoguePanel;                    //对话UI面板

    public Button continueBtn;                          //下一句按钮
    public  Text dialogueText, nameText;                //对话文本UI，NPC姓名文本UI

    private void Start()
    {
         dialoguePanel.SetActive(false);
         continueBtn.onClick.AddListener(ContinueDialogue);//给“下一句按钮”注册事件
    }

    /// <summary>
    /// 传入对话
    /// </summary>
    public void AddNewDialogue(string[] lines,string name)
    {
        //将inspector面板中设定好的对话信息传入
        dialogues = new List<string>(lines.Length);
        foreach (string line in lines)
        {
            dialogues.Add(line);
        }
        //将名字传入
        this.npcName = name;
    }

    /// <summary>
    /// 初始显示对话面板
    /// </summary>
    public void CreatDialogue()
    {
        
        index = 0;                              //将数组索引置为0
        dialogueText.text = dialogues[index];   //将数组的第一号元素写入text
        nameText.text = npcName;                //写入名称
        dialoguePanel.SetActive(true);          //UI面板激活
        index++;                                //索引指向下一号元素
    }

    /// <summary>
    /// 显示下一句
    /// </summary>
    public void ContinueDialogue()
    {
        //判断索引是否越界
        if (index < dialogues.Count )
        {
            dialogueText.text = dialogues[index];//更新text
            index++;                             //指向下一号元素
        }
        //所有对话已经显示完毕
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
