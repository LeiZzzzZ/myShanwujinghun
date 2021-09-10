using UnityEngine;
using UnityEngine.UI;

public class toss : MonoBehaviour
{
    public GameObject tossButtonText;
    public GameObject numInput;
    public GameObject numPrint;
    public GameObject dice;
    public string numPrintText;
    public int statecheck;
    public int num;
    void Start()
    {
        tossButtonText = GameObject.Find("tossButtonText");
        numInput = GameObject.Find("numInput");
        numPrint = GameObject.Find("numPrint");
        dice = GameObject.Find("dice");
        tossButtonText.GetComponent<Text>().text = "Toss";

        numPrint.SetActive(false);
        dice.SetActive(false);

        statecheck = 0;
        numPrintText = "";
        num = 0;
    }
    public void TossClick()
    {
        if (statecheck == 0)
        {
            numPrintText = numInput.GetComponent<InputField>().text;
            if (IsNumeric(numPrintText))
            {
                num = int.Parse(numPrintText);
            }
            if (num > 0 && num < 9)
            {
                numInput.SetActive(false);
                numPrint.SetActive(true);
                Toss(num);
                statecheck = 1;
                tossButtonText.GetComponent<Text>().text = "Retoss";
                numPrint.GetComponent<Text>().text = "Current number of dices: " + numPrintText;
            }
        }
        else if (statecheck == 1)
        {
            tossButtonText.GetComponent<Text>().text = "Toss";
            numInput.SetActive(true);
            numPrint.SetActive(false);
            DestroyDices(num);
            statecheck = 0;
        }
    }

    protected bool IsNumeric(string message)
    {
        System.Text.RegularExpressions.Regex rex = new System.Text.RegularExpressions.Regex(@"^\d+$");
        if (rex.IsMatch(message))
            return true;
        else
            return false;
    }

    public float[] PosGenerator(int n)
    {
        System.Random rd = new System.Random();
        float[] positions = new float[3 * n];
        float x_1 = 29.26f;
        float y_1 = 35f;
        float z_1 = -16.67f;
        float x_2 = 21.65f;
        float z_2 = -19.25f;

        for (int i = 0; i < n; i++)
        {
            positions[3 * i] = (0.2f + 0.6f * (float)rd.NextDouble() + i) * (x_1 - x_2) / n + x_2;
            positions[3 * i + 1] = y_1;
            positions[3 * i + 2] = (float)rd.NextDouble() * (z_1 - z_2) + z_2;
        }
        return positions;
    }

    public void Toss(int n)
    {
        System.Random rd = new System.Random();
        float[] pos = PosGenerator(n);
        for (int i = 0; i < n; i++)
        {
            GameObject d = Instantiate(dice, new Vector3(pos[3 * i], pos[3 * i + 1], pos[3 * i + 2]), new Quaternion((float)(2 * rd.NextDouble() - 1), (float)(2 * rd.NextDouble() - 1), (float)(2 * rd.NextDouble() - 1), 1));
            d.SetActive(true);
            d.name = dice.name + i.ToString();
        }
    }

    public void DestroyDices(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Destroy(GameObject.Find(dice.name + i.ToString()));
        }
    }
}
