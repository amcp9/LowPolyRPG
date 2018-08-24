﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    
    #region singleton
    public static DialogueSystem Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion


    private List<string> dialogues = new List<string>();
    private string npcName;
    private int index = 0;

    public GameObject dialoguePanel;

    public Button continueBtn;
    public  Text dialogueText, nameText;

    private void Start()
    {
         dialoguePanel.SetActive(false);
         continueBtn.onClick.AddListener(ContinueDialogue);//给btn增加事件调用下一句
    }
    //传入对话
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
    //显示对话
    public void CreatDialogue()
    {
        //将数组索引置为0
        index = 0;
        //将数组的第一号元素写入text
        dialogueText.text = dialogues[index];
        //写入名称
        nameText.text = npcName;
        //UI面板激活
        dialoguePanel.SetActive(true);
        //索引指向下一号元素
        index++;
    }
    public void ContinueDialogue()
    {
        //判断索引是否越界
        if (index < dialogues.Count )
        {
            //更新text
            dialogueText.text = dialogues[index];
            //指向下一号元素
            index++;
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
