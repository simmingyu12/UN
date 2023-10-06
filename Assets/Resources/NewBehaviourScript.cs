using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class MusicPlayer : MonoBehaviour
{
    public TextAsset musicXMLFile; // Unity Resources 폴더에 있는 XML 파일
    private int currentMeasure = 1; // 현재 마디 번호
    private float lastMeasureTime = 0f; // 마지막 마디 변경 시간

    private AudioSource audioSource; // AudioSource 컴포넌트

    // BPM과 박자 단위
    private float bpm = 60f;
    private int beatsPerMeasure = 4; // 4/4 박자

    // 마디의 길이 계산
    private float measureLengthInSeconds;

    void Awake()
    {
        // AudioSource 컴포넌트를 가져오기
        audioSource = GetComponent<AudioSource>();

        // 마디의 길이 계산
        measureLengthInSeconds = 60f / bpm * beatsPerMeasure;

        if (musicXMLFile != null)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(musicXMLFile.text);

            // 여기에서 XML 파싱 로직을 구현하여 악보 데이터 추출
            // 예를 들어, xmlDoc를 사용하여 음표, 마디, 박자 정보를 추출합니다.

            // 음악을 재생
            audioSource.Play();
        }
        else
        {
            Debug.LogError("XML 파일을 찾을 수 없습니다.");
        }
    }

    void Update()
    {
        // 현재 재생 위치를 가져옵니다.
        float currentTime = audioSource.time;

        // 마디 업데이트 로직
        // 마디의 시작 시간과 현재 재생 위치를 비교하여 마디 업데이트
        if (currentTime >= lastMeasureTime + measureLengthInSeconds)
        {
            currentMeasure++;
            lastMeasureTime = currentTime;

            // 다음 마디로 넘어가는 로직을 구현할 수 있습니다.
            // 예를 들어, 마디가 변경되면 다음 마디에 해당하는 악보를 화면에 표시하거나
            // 다음 마디의 음악 재생 등의 작업을 수행합니다.
        }
    }
}