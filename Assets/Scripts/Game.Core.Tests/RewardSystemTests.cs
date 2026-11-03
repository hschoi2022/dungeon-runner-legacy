using NUnit.Framework;
using Game.Core;

namespace Game.Core.Tests
{
    /// 10주차 실습 A — 특성화 테스트(Characterization Test)
    ///
    /// 규칙: 지금의 동작이 "정답"이다. 코드를 읽고 현재 결과를 그대로 기대값으로 적는다.
    ///       (이상해 보여도 고치지 않는다 — 고치는 것은 실습 B, 테스트가 초록이 된 뒤다)
    ///
    /// [제공] 2개는 작성 예시이며 즉시 통과한다.
    /// [TODO] 6개는 Ignore를 지우고 기대값을 채워 통과시킨다.
    ///        테스트 케이스 선정 근거는 이번 주 이론(동등 분할·경계값 분석)이다.
    public class RewardSystemTests
    {
        // ── [제공 1] 대표값 하나를 고정한다 (동등 분할: 일반 난이도·비이벤트 클래스)
        [Test]
        public void Proc_Coin3_Boss1_Diff1_NoEvent_Time100()
        {
            var sut = new RewardSystem();
            int reward = sut.Proc(t: 100, c: 3, b: 1, isEvent: false, diff: 1);
            Assert.AreEqual(80, reward);        // 3*10 + 1*50
            Assert.AreEqual("B", sut.grade);    // 90 <= 100 < 120
        }

        // ── [제공 2] 경계값 분석: t=59 는 S 등급(보너스 +100)
        [Test]
        public void Proc_TimeBoundary_59_IsGradeS_WithBonus()
        {
            var sut = new RewardSystem();
            int reward = sut.Proc(t: 59, c: 3, b: 0, isEvent: false, diff: 1);
            Assert.AreEqual(130, reward);       // 30 + S 보너스 100
            Assert.AreEqual("S", sut.grade);
        }

        // ── [TODO 1] 경계값: t=60 — 경계의 반대쪽. 등급과 보상액은?
        [Test, Ignore("TODO: 기대값을 채우고 Ignore를 지울 것")]
        public void Proc_TimeBoundary_60()
        {
            var sut = new RewardSystem();
            int reward = sut.Proc(t: 60, c: 1, b: 0, isEvent: false, diff: 1);
            Assert.AreEqual(0 /* TODO */, reward);
            Assert.AreEqual("?" /* TODO */, sut.grade);
        }

        // ── [TODO 2] 동등 분할: 이벤트 배율 — isEvent=true 클래스
        [Test, Ignore("TODO")]
        public void Proc_EventMultiplier()
        {
            var sut = new RewardSystem();
            int reward = sut.Proc(t: 100, c: 4, b: 0, isEvent: true, diff: 1);
            Assert.AreEqual(0 /* TODO */, reward);
        }

        // ── [TODO 3] 동등 분할: 난이도 3 배율
        [Test, Ignore("TODO")]
        public void Proc_Diff3_Multiplier()
        {
            var sut = new RewardSystem();
            int reward = sut.Proc(t: 100, c: 2, b: 1, isEvent: false, diff: 3);
            Assert.AreEqual(0 /* TODO */, reward);
        }

        // ── [TODO 4] 경계값: t=120 — C 등급 경계
        [Test, Ignore("TODO")]
        public void Proc_TimeBoundary_120()
        {
            var sut = new RewardSystem();
            sut.Proc(t: 120, c: 0, b: 0, isEvent: false, diff: 1);
            Assert.AreEqual("?" /* TODO */, sut.grade);
        }

        // ── [TODO 5] Wallet 보유 한도 경계 — 999,990 + 20 은?
        [Test, Ignore("TODO")]
        public void Wallet_GoldCap_Boundary()
        {
            var w = new Wallet { gold = 999990 };
            w.GrantStageReward(20);
            Assert.AreEqual(0 /* TODO */, w.gold);
        }

        // ── [TODO 6] CombatCalc — "slime"과 "boss" 각 한 건 (문자열 분기 고정)
        [Test, Ignore("TODO")]
        public void CombatCalc_Slime_And_Boss()
        {
            var c = new CombatCalc();
            Assert.AreEqual(0 /* TODO */, c.Damage("slime", 5));
            Assert.AreEqual(0 /* TODO */, c.Damage("boss", 10));
        }
    }
}
