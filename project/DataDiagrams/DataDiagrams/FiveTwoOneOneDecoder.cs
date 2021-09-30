using System;
namespace DataDiagrams
{
    public class FiveTwoOneOneDecoder
    {

        private readonly ByteReader reader;
        private String decodedValue = null;

        public FiveTwoOneOneDecoder(ByteReader reader)
        {
            
        }

        public String GetDecoded()
        {
            return decodedValue;
        }

        public String Decode(byte[] data)
        {
            return null;
        }

        public String DecodeHand(byte[] data)
        {
            return null;
        }

        public String DecodeBoardState(byte[] data)
        {
            return null;
        }

        public String CardState(byte cardState)
        {
            if(cardState == 0)
            {
                return "Face Down";
            }

            if(cardState == 1)
            {
                return "Face Up";
            }

            throw new ArgumentException($"Illegal Card State {cardState}");
        }

        public String DecodeCard(byte cardData)
        {
            byte value = (byte)((cardData & 0b0000_1111));
            return $"{GetColor(cardData)} {value}";
        }


        public String GetColor(byte cardData)
        {
            byte color = (byte)((cardData & 0b1111_0000) >> 4);
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

            throw new ArgumentException($"Illegal Color value {cardData}");

        }


    }
}
