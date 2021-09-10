using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using Character;

public class charview : MonoBehaviour
{
    public GameObject charPanel;
    public GameObject charInformation;
    public GameObject charAttrPanel;
    public GameObject charDropdown;
    public GameObject charButtonText;
    public GameObject charReturnButton;
    public character root;
    public int charstate;
    public int charpick;
    public CurrentCharacter cc;
    public GameObject speedAttr;
    public GameObject mightAttr;
    public GameObject sanityAttr;
    public GameObject knowledgeAttr;
    void Start()
    {
        string jsonString = Resources.Load<TextAsset>("data").text;
        root = JsonConvert.DeserializeObject<character>(jsonString);

        charButtonText = GameObject.Find("charButtonText");
        charReturnButton = GameObject.Find("charReturnButton");
        charPanel = GameObject.Find("charPanel");
        charInformation = GameObject.Find("charInformation");
        charDropdown = GameObject.Find("charDropdown");
        charAttrPanel = GameObject.Find("charAttrPanel");
        speedAttr = GameObject.Find("speedAttr");
        mightAttr = GameObject.Find("mightAttr");
        sanityAttr = GameObject.Find("sanityAttr");
        knowledgeAttr = GameObject.Find("knowledgeAttr");

        charPanel.SetActive(false);
        charAttrPanel.SetActive(false);
        charReturnButton.SetActive(false);
        ScrollListGenerator();

        charButtonText.GetComponent<Text>().text = "Pick Your Character";
        charInformation.GetComponent<Text>().text = "";
        charstate = 0;

        GetValue();
    }
    public void PickClick()
    {
        if(charstate == 0)
        {
            charPanel.SetActive(true);
            charReturnButton.SetActive(true);
            charButtonText.GetComponent<Text>().text = "Pick";
            charstate = 1;
        }
        else if(charstate == 1)
        {
            UpdateAttr();
            charPanel.SetActive(false);
            charReturnButton.SetActive(false);
            charButtonText.GetComponent<Text>().text = "View Your Character";
            charstate = 2;
        }
        else if(charstate == 2)
        {
            charAttrPanel.SetActive(true);
            charReturnButton.SetActive(true);
            charButtonText.GetComponent<Text>().text = "Restart Game";
            charstate = 3;
        }
        else if (charstate == 3)
        {
            charpick = charDropdown.GetComponent<Dropdown>().value;
            cc = CharactersItem.ToCurrentCharacter(root.characters[charpick]);
            charAttrPanel.SetActive(false);
            charReturnButton.SetActive(false);
            charButtonText.GetComponent<Text>().text = "Pick Your Character";
            charstate = 0;
        }
    }

    public void ReturnClick()
    {
        charPanel.SetActive(false);
        charAttrPanel.SetActive(false);
        charReturnButton.SetActive(false);
        if (charstate == 1)
        {
            charButtonText.GetComponent<Text>().text = "Pick Your Character";
            charstate = 0;
        }
        else if (charstate == 3)
        {
            charButtonText.GetComponent<Text>().text = "View Your Character";
            charstate = 2;
        }
    }

    void ScrollListGenerator()
    {
        charDropdown.GetComponent<Dropdown>().options.Clear();
        for(int i = 0; i < root.characters.Count; i++)
        {
            Dropdown.OptionData temp = new Dropdown.OptionData();
            temp.text = root.characters[i].name;
            charDropdown.GetComponent<Dropdown>().options.Add(temp);
        }
        charDropdown.GetComponent<Dropdown>().captionText.text = "Pick from listed";
    }

    public void GetValue()
    {
        charpick = charDropdown.GetComponent<Dropdown>().value;
        cc = CharactersItem.ToCurrentCharacter(root.characters[charpick]);
        charInformation.GetComponent<Text>().text =
            "Name: " + cc.name + "\r\n" +
            "Age: " + cc.age + "\r\n" +
            "Height: " + cc.height + "\r\n" +
            "Weight: " + cc.weight + "\r\n" +
            "Hobbies: " + string.Join(", ", cc.hobbies) + "\r\n" +
            "Birthday: " + cc.birthday + "\r\n" +
            "Bio:" + cc.bio + "\r\n" + cc.bio2 + "\r\n" +
            "Speed: " + string.Join(",", cc.speed[0].array) + "\r\n" +
            "Might: " + string.Join(",", cc.might[0].array) + "\r\n" +
            "Sanity: " + string.Join(",", cc.sanity[0].array) + "\r\n" +
            "Knowledge: " + string.Join(",", cc.knowledge[0].array);
    }

    void UpdateAttr()
    {
        speedAttr.GetComponent<Text>().text = "Speed: " + cc.speed[0].array[cc.speedindex].ToString() + "; Level: " + cc.speedindex.ToString() + "\r\n" + string.Join(",", cc.speed[0].array);
        mightAttr.GetComponent<Text>().text = "Might: " + cc.might[0].array[cc.mightindex].ToString() + "; Level: " + cc.mightindex.ToString() + "\r\n" + string.Join(",", cc.might[0].array);
        sanityAttr.GetComponent<Text>().text = "Sanity: " + cc.sanity[0].array[cc.sanityindex].ToString() + "; Level: " + cc.sanityindex.ToString() + "\r\n" + string.Join(",", cc.sanity[0].array);
        knowledgeAttr.GetComponent<Text>().text = "Knowledge: " + cc.knowledge[0].array[cc.knowledgeindex].ToString() + "; Level: " + cc.knowledgeindex.ToString() + "\r\n" + string.Join(",", cc.knowledge[0].array);
    }

    public void SpeedGainClick()
    {
        if(cc.speedindex < 8)
        {
            cc.speedindex++;
            UpdateAttr();
        }
    }
    public void MightGainClick()
    {
        if (cc.mightindex < 8)
        {
            cc.mightindex++;
            UpdateAttr();
        }
    }
    public void SanityGainClick()
    {
        if (cc.sanityindex < 8)
        {
            cc.sanityindex++;
            UpdateAttr();
        }
    }
    public void KnowledgeGainClick()
    {
        if (cc.knowledgeindex < 8)
        {
            cc.knowledgeindex++;
            UpdateAttr();
        }
    }
    public void SpeedLossClick()
    {
        if (cc.speedindex > 0)
        {
            cc.speedindex--;
            UpdateAttr();
        }
    }
    public void MightLossClick()
    {
        if (cc.mightindex > 0)
        {
            cc.mightindex--;
            UpdateAttr();
        }
    }
    public void SanityLossClick()
    {
        if (cc.sanityindex > 0)
        {
            cc.sanityindex--;
            UpdateAttr();
        }
    }
    public void KnowledgeLossClick()
    {
        if (cc.knowledgeindex > 0)
        {
            cc.knowledgeindex--;
            UpdateAttr();
        }
    }
}