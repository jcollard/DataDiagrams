using System;
namespace DataDiagrams
{
    public class FiveTwoOneOneDecoder
    {

        public byte[] GetBytes(byte[] data, int startIx, int length)
        {
            byte[] subarray = new byte[length];
            for(int ix = 0; ix < length; ix++)
            {
                subarray[ix] = data[ix + startIx];
            }
            return subarray;
        }

        public byte GetTopNibble(byte data)
        {
            return (byte)(data >> 4);
        }

        public byte GetBottomNibble(byte data)
        {
            return (byte)(data & 0xF0);
        }

        public String ToHex(byte data)
        {
            return "0x" + data.ToString("X2");
        }

        public String DecodeTwoPlayer(byte[] data)
        {
            String playerOne = DecodePlayer("Player 1", GetBytes(data, 0, 16));
            String playerTwo = DecodePlayer("Player 2", GetBytes(data, 16, 16));
            return $"{playerOne}\n{playerTwo}";
        }

        public String DecodePlayer(String label, byte[] data)
        {
            String hand = DecodeHand(GetBytes(data, 0, 8));
            String board = DecodeBoard(GetBytes(data, 8, 8));
            return $"{label} Hand: {hand}\n{label} Board: {board}";
        }

        public String DecodeHand(byte[] data)
        {
            return $"{DecodeCard(data[3])}, {DecodeCard(data[4])}, {DecodeCard(data[5])}, {DecodeCard(data[6])}, {DecodeCard(data[7])}";
        }

        public String DecodeBoard(byte[] data)
        {
            String first = DecodePair(data[0], data[1]);
            String second = DecodePair(data[2], data[3]);
            String third = DecodePair(data[4], data[5]);
            String fourth = DecodePair(data[6], data[7]);
            return $"{first}, {second}, {third}, {fourth}";
        }

        public String DecodePair(byte cardState, byte cardData)
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

            return $"Invalid Card State {ToHex(cardState)}";
        }

        public String DecodeCard(byte cardData)
        {
            byte value = (byte)((cardData & 0b0000_1111));
            if (value < 1 || value > 6)
            {
                return $"Invalid Card Value {ToHex(value)}";
            }
            return $"{DecodeColor(cardData)} {value}";
        }


        public String DecodeColor(byte cardData)
        {
            byte color = GetTopNibble(cardData);
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

            return $"Invalid Color \"{ToHex(cardData)}\"";

        }


    }
}
