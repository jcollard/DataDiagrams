using System;

namespace DataDiagrams
{
    class MainClass
    {

        public static void Main(string[] args)
        {

            FiveTwoOneOneDecoder decoder = new FiveTwoOneOneDecoder();

            Console.WriteLine(decoder.DecodeColor(0x00));
            Console.WriteLine(decoder.DecodeColor(0x11));
            Console.WriteLine(decoder.DecodeColor(0x22));
            Console.WriteLine(decoder.DecodeColor(0x33));
            Console.WriteLine(decoder.DecodeColor(0x44));

            Console.WriteLine(decoder.DecodeCard(0x01));
            Console.WriteLine(decoder.DecodeCard(0x25));
            Console.WriteLine(decoder.DecodeCard(0x34));
            Console.WriteLine(decoder.DecodeCard(0x16));
            Console.WriteLine(decoder.DecodeCard(0x61));

            byte[] hand = { 0x00, 0x00, 0x00, 0x01, 0x25, 0x34, 0x31, 0x43 };

            Console.WriteLine(decoder.DecodeHand(hand));

            byte[] board = { 0x00, 0x01, 0x00, 0x25, 0x00, 0x00, 0x00, 0x00 };
            Console.WriteLine(decoder.DecodeBoard(board));

            byte[] playerBoard = { 0x00, 0x00, 0x00, 0x01, 0x25, 0x34, 0x31, 0x43,
                                   0x00, 0x01, 0x00, 0x25, 0x00, 0x00, 0x00, 0x00 };

            Console.WriteLine(decoder.DecodePlayer("Player 1", playerBoard));

            byte[] playerBoard2 = Support.ReadBytes("playerBoard.5211", 16);
            Console.WriteLine(decoder.DecodePlayer("Player 1", playerBoard2));

            byte[] playerBoards = Support.ReadBytes("twoPlayerBoard.5211", 32);
            Console.WriteLine(decoder.DecodeTwoPlayer(playerBoards));

        }
    }


}
