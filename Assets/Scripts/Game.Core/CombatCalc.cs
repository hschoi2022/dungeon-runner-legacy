namespace Game.Core
{
    /// 전투 데미지 계산 (레거시) — 몬스터 타입 문자열 분기.
    /// 심화 과제: 이 분기를 전략 패턴으로 전환한다(6주차 2.4 다형성 전환).
    public class CombatCalc
    {
        public int Damage(string monsterType, int atk)
        {
            if (monsterType == "slime") return atk - 1;
            else if (monsterType == "boss") return (int)(atk * 0.7f);
            else if (monsterType == "golem") return atk / 2;
            return atk;
        }
    }
}
