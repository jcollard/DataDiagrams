using System;
namespace DataDiagrams
{
    public class FiveTwoOneOneDecoder : IFiveTwoOneOneDecoder
    {

        public String DecodeTwoPlayer(String player1Label, String player2Label, byte[] data)
        {
            String playerOne = DecodePlayer(player1Label, Support.GetBytes(data, 0, 16));
            String playerTwo = DecodePlayer(player2Label, Support.GetBytes(data, 16, 16));
            return $"{playerOne}\n{playerTwo}";
        }

        public String DecodePlayer(String label, byte[] data)
        {
            String hand = DecodeHand(Support.GetBytes(data, 0, 8));
            String board = DecodeBoard(Support.GetBytes(data, 8, 8));
            return $"{label} Hand: {hand}\n{label} Board: {board}";
        }

        public String DecodeHand(byte[] data)
        {
            return $"{DecodeCard(data[3])}, {DecodeCard(data[4])}, {DecodeCard(data[5])}, {DecodeCard(data[6])}, {DecodeCard(data[7])}";
        }

        public String DecodeBoard(byte[] data)
        {
            String first = DecodeCardPair(data[0], data[1]);
            String second = DecodeCardPair(data[2], data[3]);
            String third = DecodeCardPair(data[4], data[5]);
            String fourth = DecodeCardPair(data[6], data[7]);
            return $"{first}, {second}, {third}, {fourth}";
        }

        public String DecodeCardPair(byte cardState, byte cardData)
        {
            if(cardData == 0)
            {
                return "No Card";
            }
            return $"{DecodeCardState(cardState)} {DecodeCard(cardData)}";
        }

        public String DecodeCardState(byte cardState)
        {
            if(cardState == 0)
            {
                return "Face Down";
            }

            if(cardState == 1)
            {
                return "Face Up";
            }

            return $"Invalid Card State {Support.ToHex(cardState)}";
        }

        public String DecodeCard(byte cardData)
        {
            String value = DecodeValue(cardData);
            String color = DecodeColor(cardData);
            return $"{color} {value}";
        }


        public String DecodeColor(byte cardData)
        {
            byte color = Support.GetTopNibble(cardData);
            if(color == 0)
            {
                return "Yellow";
            }

            if(color == 1)
            {
                return "Green";
            }

            if(color == 2)
            {
                return "Blue";
            }

            if(color == 3)
            {
                return "Orange";
            }

            if(color == 4)
            {
                return "Black";
            }

            return $"Invalid Color ({Support.ToHex(cardData)})";

        }

        public String DecodeValue(byte cardData)
        {
            byte value = Support.GetBottomNibble(cardData);
            if (value == 1)
            {
                return "Rooster";
            }

            if (value == 2)
            {
                return "Two";
            }

            if (value == 3)
            {
                return "Three";
            }

            if (value == 4)
            {
                return "Four";
            }

            if (value == 5)
            {
                return "Five";
            }

            if (value == 6)
            {
                return "Six";
            }

            return $"Invalid Value \"{Support.ToHex(cardData)}\"";
        }
    }
}
