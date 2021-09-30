using System;

namespace DataDiagrams
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            //String rootDir = "/d/git/ap-compsci-2021-2022/project_ideas/DataDiagrams/project/DataDiagrams/";
            String rootDir = @"D:\git\ap-compsci-2021-2022\project_ideas\DataDiagrams\project\test_data\";
            //CharacterGuessingGame();
            

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

            byte[] playerBoard = { 0x00, 0x00, 0x00, 0x01, 0x25, 0x34, 0x31, 0x43, 0x00, 0x01, 0x00, 0x25, 0x00, 0x00, 0x00, 0x00 };

            Console.WriteLine(decoder.DecodePlayer("Player 1", playerBoard));

            ByteReader br = new ByteReader(rootDir + "playerBoard.5211");

            byte[] playerBoard2 = br.ReadBytes(16);
            Console.WriteLine(decoder.DecodePlayer("Player 1", playerBoard2));

            br = new ByteReader(rootDir + "twoPlayerBoard.5211");
            byte[] playerBoards = br.ReadBytes(32);
            Console.WriteLine(decoder.DecodeTwoPlayer(playerBoards));

        }
    }


}
