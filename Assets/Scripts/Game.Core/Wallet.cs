namespace Game.Core
{
    /// 재화 지갑 (레거시) — 보유 한도 로직이 두 메서드에 복제되어 있다.
    public class Wallet
    {
        public int gold;

        public bool TrySpend(int price)
        {
            if (gold >= price) { gold -= price; return true; }
            return false;
        }

        public void GrantStageReward(int amount)
        {
            gold += amount;
            if (gold > 999999) gold = 999999;
        }

        public void GrantShopRefund(int amount)
        {
            gold += amount;
            if (gold > 999999) gold = 999999;
        }
    }
}
