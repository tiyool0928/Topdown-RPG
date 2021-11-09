using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //Luna Say
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나..?:2" });
        //Ludo Say
        talkData.Add(2000, new string[] { "너는 누구야..?:0", "나한테 말 걸지 말아줘..:0" });
        //Box
        talkData.Add(200,new string[] { "평범한 나무상자다." });
        //Desk
        talkData.Add(100,new string[] { "누군가 사용한 흔적이 있는 책상이다." });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "너.. 루도를 봤구나..?:0",
                                                "저 친구는 말 걸지 않는편이 좋아:2"});
        talkData.Add(11 + 2000, new string[] { "집에 갈 시간..:0",
                                                "(루도의 집을 따라가보자):0"});
        talkData.Add(20 + 5000, new string[] { "(여기가 루도의 집..?)",
                                                "(음산하다 못해 소름돋는 느낌의 집이다..)"});
        talkData.Add(21 + 1000, new string[] { "너가 왜 여기있어..?:0",
                                               "어떻게 온건진 모르겠지만 어서 돌아가줘.:0"});

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                return GetTalk(id - id % 100, talkIndex); // Get First Talk
            }
           else
            {
                return GetTalk(id - id % 10, talkIndex);   //Get First Quest Talk
            }
            
        }
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];

    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
