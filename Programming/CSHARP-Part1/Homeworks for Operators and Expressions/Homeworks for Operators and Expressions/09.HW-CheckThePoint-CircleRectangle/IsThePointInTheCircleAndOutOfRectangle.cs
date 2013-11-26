/* Write an expression that checks for given point (x, y)
 * if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).*/
using System;

class IsThePointInTheCircleAndOutOfRectangle
{
    static void Main()
    {
        int circleX = 1;
        int circleY = 1;
        int radius = 3;
        int rectTop = 1;
        int rectLeft = -1;
        int rectWidth = 6;
        int rectHeight = 2;

        Console.Write("Enter X of the point: ");
        double pointX = double.Parse(Console.ReadLine());
        Console.Write("Enter Y of the point: ");
        double pointY = double.Parse(Console.ReadLine());

        double distanceCentreCircle=(pointX-circleX)*(pointX-circleX)+(pointY-circleY)*(pointY-circleY);
        bool inCircle = (distanceCentreCircle<radius*radius);
        Console.WriteLine("The point within the circle ? {0}",inCircle);
        bool inRectangle = (pointX >= rectLeft && pointX<=(rectWidth+rectLeft) && pointY>=rectTop && pointY<=(rectTop+rectHeight));
        Console.WriteLine("The point within the rectangle ? {0}", inRectangle);
        Console.WriteLine(inCircle == true && inRectangle == false ? "The point is within the circle and out of the rectangle" : "The point is anywhere !");
    }
}

