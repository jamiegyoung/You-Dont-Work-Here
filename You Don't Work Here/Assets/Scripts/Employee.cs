using System.Linq;
using UnityEngine;

[System.Serializable]
public struct EmployeeType
{
    public string[] firstNames;
    public string[] lastNames;
    public SpeechType speechType;
}

[System.Serializable]
public struct FaceType
{
    public Sprite faceSprite;
    public Sprite glassesSprite;
    public Sprite[] hairSprites;
}

[System.Serializable]
public struct SpeechType
{
    public string[] introductionText;
    public string[] takingTimeText;
    public string[] acceptionText;
    public string[] rejectionText;

    public bool Equals(SpeechType other)
    { return SpeechType.Equals(this, other); }

    public static bool Equals(SpeechType a, SpeechType b)
    {
        return a.introductionText.SequenceEqual(b.introductionText) &&
               a.takingTimeText.SequenceEqual(b.takingTimeText) &&
               a.acceptionText.SequenceEqual(b.acceptionText) &&
               a.rejectionText.SequenceEqual(b.rejectionText);
    }
}

[System.Serializable]
public class Employee
{
    public long id;
    public string firstName;
    public string lastName;
    public SpeechType speechType;
    public FaceType face;
    public Color faceColor;
    public Sprite hairSprite;
    public Color hairColor;
    public Sprite eyesSprite;
    public Sprite mouthSprite;
    public bool wearsGlasses;

    public static int Equals(Employee a, Employee b)
    {
        int similarities = new[] {
        a.id == b.id,
        a.firstName == b.firstName,
        a.lastName == b.lastName,
        a.Equals(b.speechType),
        a.face.faceSprite == b.face.faceSprite,
        a.hairSprite == b.hairSprite,
        a.eyesSprite == b.eyesSprite,
        a.mouthSprite == b.mouthSprite,
        a.wearsGlasses == b.wearsGlasses
    }.Count(c => c);
        return similarities;
    }
    public int Equals(Employee other)
    {
        return Equals(this, other);
    }

    public string GetIntroductionSpeech()
    {
        return GetRandomText(speechType.introductionText);
    }

    public string GetTakingTimeSpeech()
    {
        return GetRandomText(speechType.takingTimeText);
    }

    public string GetAcceptionSpeech()
    {
        return GetRandomText(speechType.acceptionText);
    }

    public string GetRejectionSpeech()
    {
        return GetRandomText(speechType.rejectionText);
    }

    private static string GetRandomText(string[] text)
    {
        int randomIndex = Random.Range(0, text.Length);
        return text[randomIndex];
    }

    public Vector4 GetColor()
    {
        int firstNameASCII = 0;
        int lastNameASCII = 0;
        foreach(char c in firstName)
        {
            firstNameASCII += (int)c;
        }
        foreach (char c in lastName)
        {
            lastNameASCII += (int)c;
        }
        firstNameASCII = firstNameASCII % 256;
        lastNameASCII = lastNameASCII % 256;
        int blueVlaue = (firstNameASCII + lastNameASCII) % 256;
        Debug.Log(firstNameASCII + "," + lastNameASCII + "," + blueVlaue);
        return new Vector4 (firstNameASCII, lastNameASCII, blueVlaue, 255);
    }

}