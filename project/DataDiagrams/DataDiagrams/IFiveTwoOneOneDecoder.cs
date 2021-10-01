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
        /// by the cardData byte as a hexadecimal string wrapped in parenthesis.
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeColor(0x00));
        /// </code>
        /// <code>
        /// Output:
        /// Yellow
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeColor(0x42));
        /// </code>
        /// <code>
        /// Output:
        /// Black
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeColor(0x53));
        /// </code>
        /// <code>
        /// Output:
        /// Invalid Color (0x57)
        /// </code>
        /// </example>
        /// </para>
        /// 
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
        /// as a hexadecimal string wrapped in paranthesis.
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeValue(0x01));
        /// </code>
        /// <code>
        /// Output:
        /// Rooster
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeValue(0x42));
        /// </code>
        /// <code>
        /// Output:
        /// Two
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeValue(0x30));
        /// </code>
        /// <code>
        /// Output:
        /// Invalid Value (0x30)
        /// </code>
        /// </example>
        /// </para>
        /// 
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
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeCard(0x01));
        /// </code>
        /// <code>
        /// Output:
        /// Yellow Rooster
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeCard(0x42));
        /// </code>
        /// <code>
        /// Output:
        /// Black Two
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeValue(0x30));
        /// </code>
        /// <code>
        /// Output:
        /// Orange Invalid Value (0x30)
        /// </code>
        /// </example>
        /// </para>
        /// </summary>
        /// <param name="cardData">A 5211 card encoded as a byte</param>
        /// <returns>A string representation of the card</returns>
        public String DecodeCard(byte cardData);

        /// <summary>
        /// <para>
        /// Given a byte array containing 8 bytes encoding a 5211 player's hand, this method returns a string containing the
        /// cards in the players hand.
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// byte[] hand = { 0x00, 0x00, 0x00, 0x01, 0x25, 0x34, 0x31, 0x43 };
        /// Console.WriteLine(decoder.DecodeHand(hand));
        /// </code>
        /// <code>
        /// Output:
        /// Yellow Rooster, Blue Five, Orange Four, Orange Rooster, Black Three
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// </summary>
        /// <param name="data">An 8 byte array encoding a 5211 player hand</param>
        /// <returns>A string representation of the player hand</returns>
        public String DecodeHand(byte[] data);

        /// <summary>
        /// Given a 5211 card state encoded as a byte, returns "Face Up", "Face Down", or "Invalid Card State (0x??)".
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeCardState(0x01));
        /// </code>
        /// <code>
        /// Output:
        /// Face Up
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeCard(0x00));
        /// </code>
        /// <code>
        /// Output:
        /// Face Down
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeValue(0x21));
        /// </code>
        /// <code>
        /// Output:
        /// Invalid Card State (0x21)
        /// </code>
        /// </example>
        /// </para>
        /// </summary>
        /// 
        /// <param name="cardState">A 5211 card state encoded byte</param>
        /// <returns>A string representation of the card state</returns>
        public String DecodeCardState(byte cardState);

        /// <summary>
        /// Given a 5211 card state encoded byte and a byte encoding a 5211 card, this method returns a string representation of the card state and card.
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeCardPair(0x01, 0x22));
        /// </code>
        /// <code>
        /// Output:
        /// Face Up Blue Two
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeCardPair(0x00, 0x34));
        /// </code>
        /// <code>
        /// Output:
        /// Face Down Orange Four
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// Console.WriteLine(decoder.DecodeCardPair(0x33, 0x02));
        /// </code>
        /// <code>
        /// Output:
        /// Invalid Card State 0x33 Yellow Two
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// </summary>
        /// <param name="cardState"></param>
        /// <param name="cardData"></param>
        /// <returns></returns>
        public String DecodeCardPair(byte cardState, byte cardData);

        /// <summary>
        /// Given a byte array of 8 bytes encoding a 5211 Player Board, returns a string representation of the board.
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// byte[] board = { 0x00, 0x01, 0x00, 0x25, 0x00, 0x00, 0x00, 0x00 };
        /// Console.WriteLine(decoder.DecodeBoard(board));
        /// </code>
        /// <code>
        /// Output:
        /// Face Down Yellow Rooster, Face Down Blue Five, No Card, No Card
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// byte[] board = { 0x01, 0x01, 0x01, 0x25, 0x00, 0x33, 0x00, 0x00 };
        /// Console.WriteLine(decoder.DecodeBoard(board));
        /// </code>
        /// <code>
        /// Output:
        /// Face Up Yellow Rooster, Face Up Blue Five, Face Down Orange Three, No Card
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// byte[] board = { 0x01, 0x01, 0x01, 0x25, 0x01, 0x33, 0x01, 0x41 };
        /// Console.WriteLine(decoder.DecodeBoard(board));
        /// </code>
        /// <code>
        /// Output:
        /// Face Up Yellow Rooster, Face Up Blue Five, Face Up Orange Three, Face Up Black Rooster
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public String DecodeBoard(byte[] data);

        /// <summary>
        /// Given a string label for a player and a byte array of 16 bytes, return a two line string 
        /// containing a string representation of the player's board and hand. The first line The first line
        /// contiains the player's hand and the second line contains the player's board.
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// byte[] player = {
        ///     0x00, 0x00, 0x00, 0x01, 0x20, 0x33, 0x41, 0x23,
        ///     0x00, 0x01, 0x00, 0x25, 0x00, 0x00, 0x00, 0x00
        /// };
        /// Console.WriteLine(decoder.DecodePlayer("Billy's", player));
        /// </code>
        /// <code>
        /// Output:
        /// Billy's Hand: Yellow Rooster, Blue Invalid Value "0x20", Orange Three, Black Rooster, Blue Three
        /// Billy's Board: Face Down Yellow Rooster, Face Down Blue Five, No Card, No Card
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// byte[] player = {
        ///     0x00, 0x00, 0x00, 0x01, 0x20, 0x12, 0x41, 0x23,
        ///     0x01, 0x01, 0x01, 0x25, 0x00, 0x33, 0x00, 0x00
        /// };
        /// Console.WriteLine(decoder.DecodePlayer("Sally's", player));
        /// </code>
        /// <code>
        /// Output:
        /// Sally's Hand: Yellow Rooster, Blue Invalid Value "0x20", Green Two, Black Rooster, Blue Three
        /// Sally's Board: Face Up Yellow Rooster, Face Up Blue Five, Face Down Orange Three, No Card
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// <para>
        /// <example>
        /// For example,
        /// <code>
        /// byte[] player = {
        ///     0x00, 0x00, 0x00, 0x01, 0x20, 0x12, 0x22, 0x23,
        ///     0x01, 0x01, 0x01, 0x25, 0x01, 0x33, 0x01, 0x41
        /// };
        /// Console.WriteLine(decoder.DecodePlayer("Betty's", player));
        /// </code>
        /// <code>
        /// Output:
        /// Betty's Hand: Yellow Rooster, Blue Invalid Value "0x20", Green Two, Blue Two, Blue Three
        /// Betty's Board: Face Up Yellow Rooster, Face Up Blue Five, Face Up Orange Three, Face Up Black Rooster
        /// </code>
        /// </example>
        /// </para>
        /// 
        /// </summary>
        /// <param name="label">A label to use as the players name</param>
        /// <param name="data">A 16 byte array containing a 5211 encoded player board</param>
        /// <returns>A string representation of the player's board</returns>
        public String DecodePlayer(String label, byte[] data);

        /// <summary>
        /// Given two string labels and an array of 32 bytes encoding 2 5211 player boards, returns a 
        /// string representation of the game state. The first two lines contain the first players board state
        /// and the second two lines contain the second players board state.
        /// <example>
        /// <code>
        /// byte[] player = {
        ///    0x00, 0x00, 0x00, 0x01, 0x23, 0x33, 0x41, 0x23,
        ///    0x01, 0x01, 0x01, 0x05, 0x00, 0x00, 0x00, 0x00,
        ///    0x00, 0x00, 0x00, 0x11, 0x21, 0x34, 0x44, 0x36,
        ///    0x01, 0x01, 0x01, 0x25, 0x00, 0x00, 0x00, 0x00
        /// }; 
        /// Console.WriteLine(decoder.DecodeTwoPlayer("Billy's", "Bobby's", player));
        /// </code>
        /// </example>
        /// <code>
        /// Output:
        /// Billy's Hand: Yellow Rooster, Blue Three, Orange Three, Black Rooster, Blue Three
        /// Billy's Board: Face Up Yellow Rooster, Face Up Yellow Five, No Card, No Card
        /// Bobby's Hand: Green Rooster, Blue Rooster, Orange Four, Black Four, Orange Six
        /// Bobby's Board: Face Up Yellow Rooster, Face Up Blue Five, No Card, No Card
        /// </code>
        /// </summary>
        /// <param name="player1Label">The first player's label</param>
        /// <param name="player2Label">The second player's label</param>
        /// <param name="data">A 32 byte array containing 2 5211 encoded player boards</param>
        /// <returns>A string representation of the player's board</returns>
        public String DecodeTwoPlayer(String player1Label, String player2Label, byte[] data);
    }
}
