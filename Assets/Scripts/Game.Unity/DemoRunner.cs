using UnityEngine;
using Game.Core;

namespace Game.Unity
{
    /// 데모 씬용 실행기 — 빈 씬의 아무 오브젝트에 부착하면 동작한다.
    /// (씬 파일은 저장소에 포함하지 않는다: 새 씬 > 빈 오브젝트 > 이 스크립트 부착 > 재생)
    /// Game.Core가 엔진 없이도, 엔진 안에서도 같은 결과를 낸다는 것을 보여 주는 최소 데모.
    public class DemoRunner : MonoBehaviour
    {
        int t = 100, c = 3, b = 1;
        bool isEvent;
        readonly RewardSystem reward = new RewardSystem();

        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10, 10, 340, 260), GUI.skin.box);
            GUILayout.Label("던전 러너 레거시 — 보상 정산 데모");
            GUILayout.Label($"클리어 시간 t = {t}s");
            t = (int)GUILayout.HorizontalSlider(t, 0, 180);
            GUILayout.Label($"코인 c = {c}");
            c = (int)GUILayout.HorizontalSlider(c, 0, 20);
            GUILayout.Label($"보스 b = {b}");
            b = (int)GUILayout.HorizontalSlider(b, 0, 3);
            isEvent = GUILayout.Toggle(isEvent, " 이벤트 기간");
            if (GUILayout.Button("정산 (Proc)"))
            {
                int r = reward.Proc(t, c, b, isEvent, diff: 1);
                Debug.Log($"보상 {r}, 등급 {reward.grade}");
            }
            GUILayout.Label($"최근: {reward.lastR} / 등급 {reward.grade}");
            GUILayout.EndArea();
        }
    }
}
