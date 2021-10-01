using System;
namespace DataDiagrams
{
    public interface IFiveTwoOneOneDecoder
    {

        /// <summary>
        /// <para>
        /// Given a 5211 card encoded as a byte, this method decodes the top 4 bits as a color.
        /// Colors are enumerated:</para>
        /// <list type="bullet">
        /// <item>Yellow</item>
        /// <item>Green</item>
        /// <item>Blue</item>
        /// <item>Orange</item>
        /// <item>Black</item>
        /// </list>
        /// <para>
        /// If a Color code is out of bounds, returns "Invalid Color" followed
        /// by the cardData byte as a hexadecimal string.
        /// </para>
        /// </summary>
        /// <param name="cardData">A 5211 card encoded as a byte.</param>
        /// <returns>A string representation of the cards color</returns>
        public String DecodeColor(byte cardData);

        /// <summary>
        /// <para>
        /// Given a 5211 card encoded as a byte, this method decodes the bottom 4 bits as a value.
        /// Values are enumerated:
        /// </para>
        /// <list type="bullet">
        /// <item>Rooster</item>
        /// <item>Two</item>
        /// <item>Three</item>
        /// <item>Four</item>
        /// <item>Five</item>
        /// <item>Six</item>
        /// </list>
        /// <para>
        /// If the Value code is out of bounds, returns "Invalid Value" followed by the cardData byte
        /// as a hexadecimal string.
        /// </para>
        /// </summary>
        /// <param name="cardData">A 5211 card encoded as a byte.</param>
        /// <returns>A string representation of the cards value.</returns>
        public String DecodeValue(byte cardData);

        /// <summary>
        /// <para>
        /// Given a byte containing an encoded 5211 card, this method returns a string containing the
        /// cards color and value.
        /// </para>
        ///
        /// <para>
        /// <example>
        /// For example, <c>DecodeCard(0x11)</c> returns "Green Rooster"
        /// </example>
        /// </para>
        ///
        /// <para>
        /// <example>
        /// For example, <c>DecodeCard(0x32)</c> returns "Orange Two"
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example, <c>DecodeCard(0x52)</c> returns "Invalid Color 0x52 Two"
        /// </example>
        /// </para>
        /// </summary>
        /// <param name="cardData">A 5211 card encoded as a byte</param>
        /// <returns>A string representation of the card</returns>
        public String DecodeCard(byte cardData);

        public String DecodeHand(byte[] data);

        public String DecodeCardState(byte cardState);

        public String DecodePair(byte cardState, byte cardData);

        public String DecodeBoard(byte[] data);

        public String DecodePlayer(String label, byte[] data);

        public String DecodeTwoPlayer(byte[] data);
        
        
        
        
        
        

    }
}
