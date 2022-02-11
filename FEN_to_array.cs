public class FENHandler
{

    //Convert the board state portion of the FEN to an 8x8 array
    private char[,] FENToArray(string board_state_str)
    {

        //initialize our 8x8 array to return
        char[,] result = new char[8, 8];

        //this keeps track of where we will be placing piece characters in the 8x8 array
        int arrayIndex = 0;

        //iterate through the entire board_state_str
        for (int i = 0; i < board_state_str.Length; i++)
        {
            //convert our position in the board_state_str into an 8x8 array readable form
            int arrayRow = arrayIndex % 8;
            int arrayCol = (int)Math.Floor((double)(arrayIndex / 8));

            //if we encounter a letter, assign it to the appropriate spot in the array and increment the arrayIndex
            if (Char.IsLetter(board_state_str[i]))
            {
                result[arrayCol, arrayRow] = board_state_str[i];
                arrayIndex++;
            }
            //if we encounter a slash do nothing. Here for completeness sake
            else if (board_state_str[i] == '/') { }
            //if we encounter a number, iterate the arrayIndex by that many times
            else if (Char.IsNumber(board_state_str[i]))
            {
                //what a load of bullshit, python would never hurt me like this
                arrayIndex += (int)board_state_str[i] - '0';
            }

        }

        return result;

    }

    public static void Main()
    {
        FENHandler testClass = new FENHandler();

        string FEN1 = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        string[] FEN1_split = FEN1.Split(" ");

        char[,] FEN1Array = testClass.FENToArray(FEN1_split[0]);

        for (int i = 0; i < FEN1Array.GetLength(0); i++)
        {
            for (int j = 0; j < FEN1Array.GetLength(1); j++)
            {
                if (j == FEN1Array.GetLength(1) - 1)
                {
                    Console.Write(FEN1Array[i, j]);
                }
                else
                {
                    Console.Write(FEN1Array[i, j] + ", ");
                }
            }
            Console.WriteLine();
        }
    }

}
