using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;//ins拖入引用
    public string NPC_name;//ins拖入引用

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue,NPC_name);//npc响应点击
        DialogueSystem.Instance.CreatDialogue();//完成传入信息后显示对话
    }
}
