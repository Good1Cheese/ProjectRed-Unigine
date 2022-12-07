using Unigine;

namespace ProjectRed.Extensions;

public static class InputExtensions
{
    public const float Positiv = 1;
    public const float Negativ = -1;

    public static float GetAxis(Input.KEY positivKey, Input.KEY negativKey)
    {
        if (Input.IsKeyPressed(positivKey))
        {
            return Positiv;
        }
        else if (Input.IsKeyPressed(negativKey))
        {
            return Negativ;
        }

        return 0;
    }
}
