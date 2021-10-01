using System;

namespace DataDiagrams
{
    class MainClass
    {

        public static void Main(string[] args)
        {

            FiveTwoOneOneDecoder decoder = new FiveTwoOneOneDecoder();



            //Console.WriteLine(decoder.DecodeColor(0x00));
            //Console.WriteLine(decoder.DecodeColor(0x11));
            //Console.WriteLine(decoder.DecodeColor(0x22));
            //Console.WriteLine(decoder.DecodeColor(0x33));
            //Console.WriteLine(decoder.DecodeColor(0x44));

            //Console.WriteLine(decoder.DecodeCard(0x01));
            //Console.WriteLine(decoder.DecodeCard(0x25));
            //Console.WriteLine(decoder.DecodeCard(0x34));
            //Console.WriteLine(decoder.DecodeCard(0x16));
            //Console.WriteLine(decoder.DecodeCard(0x61));

            //byte[] hand = { 0x00, 0x00, 0x00, 0x01, 0x25, 0x34, 0x31, 0x43 };
            //Console.WriteLine(decoder.DecodeHand(hand));

            {
                //Billy's Hand: Yellow Rooster, Blue Three, Orange Three, Black Rooster, Blue Three
                //Billy's Board: Face Up Yellow Rooster, Face Up Yellow Five, No Card, No Card
                //Bobby's Hand: Green Rooster, Blue Rooster, Orange Four, Black Four, Orange Six
                //Bobby's Board: Face Up Yellow Rooster, Face Up Blue Five, No Card, No Card
                byte[] player = {
                    0x00, 0x00, 0x00, 0x01, 0x23, 0x33, 0x41, 0x23,
                    0x01, 0x01, 0x01, 0x05, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x11, 0x21, 0x34, 0x44, 0x36,
                    0x01, 0x01, 0x01, 0x25, 0x00, 0x00, 0x00, 0x00
                };
                Console.WriteLine(decoder.DecodeTwoPlayer("Billy's", "Bobby's", player));
            }

            //byte[] playerBoard = { 0x00, 0x00, 0x00, 0x01, 0x25, 0x34, 0x31, 0x43,
            //                       0x00, 0x01, 0x00, 0x25, 0x00, 0x00, 0x00, 0x00 };

            //Console.WriteLine(decoder.DecodePlayer("Player 1", playerBoard));

            //byte[] playerBoard2 = Support.ReadBytes("playerBoard.5211", 16);
            //Console.WriteLine(decoder.DecodePlayer("Player 1", playerBoard2));

            //byte[] playerBoards = Support.ReadBytes("twoPlayerBoard.5211", 32);
            //Console.WriteLine(decoder.DecodeTwoPlayer(playerBoards));

        }
    }


}
