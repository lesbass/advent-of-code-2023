namespace advent_of_code_2022;

public static class Day07
{
    public const string TestFileName = "Day07_test";
    public const string ProductionFileName = "Day07";

    public static int Part1(List<string> input)
    {
        var hands = input.Select(it => new Hand(it)).OrderBy(it => it).ToList();

        return hands.OrderBy(it => it).Select((hand, i) => hand.Bet * (i + 1)).Sum();
    }

    public static int Part2(List<string> input)
    {
        var hands = input.Select(it => new Hand(it, true)).ToList();

        return hands.OrderBy(it => it).Select((hand, i) => hand.Bet * (i + 1)).Sum();
    }

    public class Hand : IComparable<Hand>
    {
        public Hand(string raw, bool useJoker = false)
        {
            var rawSplit = raw.Split(' ');
            Bet = int.Parse(rawSplit[1]);
            Cards = rawSplit[0].Select(it => new Card(it, useJoker && it == 'J')).ToList();
        }


        public int Bet { get; }
        private List<Card> Cards { get; }

        private bool IsFiveOfKind => CompareUsingJoker(5);
        private bool IsFourOfKind => CompareUsingJoker(4);

        private bool IsFullHouse => TwoOfKind && GroupedCard.Count(it => !it.Key.IsJoker) == 2;

        private bool ThreeOfKind => CompareUsingJoker(3);

        private bool TwoOfKind => GroupedCard.Any(it => !it.Key.IsJoker && it.Value == 2);
        private bool TwoPairs => GroupedCard.Count(it => !it.Key.IsJoker && it.Value == 2) == 2;

        private bool OnePair => GroupedCard.Count(it => !it.Key.IsJoker && it.Value == 2) == 1 || CountJokers == 1;
        private int CountJokers => Cards.Count(it => it.IsJoker);

        private int HandValue
        {
            get
            {
                if (IsFiveOfKind) return 10;
                if (IsFourOfKind) return 9;
                if (IsFullHouse) return 8;
                if (ThreeOfKind) return 7;
                if (TwoPairs) return 6;
                if (OnePair) return 5;
                return 1;
            }
        }

        private Dictionary<Card, int> GroupedCard =>
            Cards.GroupBy(it => it)
                .ToDictionary(it => it.Key, it => it.Count());

        public int CompareTo(Hand? other)
        {
            if (other is null) return 1;
            if (HandValue == other.HandValue)
                for (var i = 0; i < Cards.Count; i++)
                {
                    var card = Cards[i];
                    var otherCard = other.Cards[i];
                    if (card.Value != otherCard.Value)
                        return card.SortValue > otherCard.SortValue ? 1 : -1;
                }

            return HandValue > other.HandValue ? 1 : -1;
        }

        private bool CompareUsingJoker(int match)
        {
            var start = GroupedCard.Count == 1
                ? GroupedCard.First().Value
                : GroupedCard.Where(it => !it.Key.IsJoker).ToList().Max(it => it.Value);

            for (var i = start; i <= start + CountJokers; i++)
                if (i == match)
                    return true;

            return false;
        }

        private record Card(char Value, bool IsJoker)
        {
            public int SortValue
            {
                get
                {
                    if (char.IsNumber(Value)) return int.Parse(Value.ToString());
                    var values = new Dictionary<char, int>
                    {
                        { 'T', 10 },
                        { 'J', IsJoker ? 0 : 11 },
                        { 'Q', 12 },
                        { 'K', 13 },
                        { 'A', 14 }
                    };
                    return values[Value];
                }
            }
        }
    }
}