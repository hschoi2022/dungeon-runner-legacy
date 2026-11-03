namespace Game.Core
{
    /// 던전 러너 — 스테이지 보상 정산 (레거시)
    /// 이 클래스에는 9주차에서 배운 코드 스멜이 의도적으로 심어져 있다.
    /// 10주차: 이 파일을 "고치기 전에" 현재 동작을 테스트로 고정한다(특성화 테스트).
    public class RewardSystem
    {
        public string grade;   // 최근 판정 등급 ("S"/"A"/"B"/"C")
        public int lastR;      // 최근 보상액

        // t: 클리어 시간(초), c: 코인 수, b: 보스 처치 수, diff: 난이도(1~3)
        public int Proc(int t, int c, int b, bool isEvent, int diff)
        {
            // --- 보상 계산 ---
            int r = c * 10 + b * 50;
            if (diff == 2) r = (int)(r * 1.2f);
            if (diff == 3) r = (int)(r * 1.5f);
            if (isEvent) r = (int)(r * 1.5f);

            // --- 등급 판정 ---
            if (t < 60) grade = "S";
            else if (t < 90) grade = "A";
            else if (t < 120) grade = "B";
            else grade = "C";
            if (grade == "S") r += 100;

            // --- 기록 ---
            lastR = r;
            return r;

            // int oldR = c * 8;   // 예전 공식 (혹시 몰라 남겨 둠)
            // if (isEvent) oldR = oldR * 2;
        }
    }
}
