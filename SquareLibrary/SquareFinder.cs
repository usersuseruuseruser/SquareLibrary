using System.Numerics;
using SquareLibrary.ExceptionMessages;

namespace SquareLibrary;

public static class SquareFinder
{
    // фигуру нельзя определить всегда однозначно используя только аргументы, которые приходят извне
    // допустим, 2 аргумента могут определить как прямоугольник, так и эллипс. учитывая, что мы пишем библиотеку для
    // внешних клиентов, мы не можем заставить их создавать объекты классов с методами типа
    // virtual FindSquare(в чем тогда смысл от нашей библиотеки?). поэтому мы просто делаем статические методы, где клиент
    // сам выбирает площадь какой фигуры он хочет найти
    public static double FindSquareOfTriangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            throw new ArgumentException(TriangleExceptionMessages.SidesMustBePositive);
        }
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            throw new ArgumentException(TriangleExceptionMessages.TriangleDoesNotExist);
        }
        
        // проверка на прямоугольность треугольника. тут я задумался о переполнении double в a * a + c * c , но
        // double это 1.7 * 10^308, то есть оно произойдет только если гипотенуза будет примерно равна стороне a,
        // а сторона б будет мизерно маленькой. даже в таком случае гипотенуза и сторона должны быть равны минимум
        // примерно 0,85 * 10^154, что совершенно невозможно в реальной жизни(во вселенной 10^80 частиц) и мы просто выбрасываем исключение
        var firstTrySides = a * a + b * b;
        var secondTrySides = a * a + c * c;
        var thirdTrySides = b * b + c * c;
        if (Double.IsInfinity(firstTrySides) || Double.IsInfinity(secondTrySides) || Double.IsInfinity(thirdTrySides))
        {
            throw new ArgumentException(TriangleExceptionMessages.SidesAreTooBig);
        }
        
        if (Math.Abs(firstTrySides - c * c) < double.Epsilon ||
            Math.Abs(secondTrySides - b * b) < double.Epsilon ||
            Math.Abs(thirdTrySides - a * a) < double.Epsilon)
        {
            return a * b / 2;
        }
        
        // тут тоже может быть переполнение, но в данном случае в отличие от прямоугольного треугольника сторона должна
        // быть примерно равна 10^75(a = b = c) что тоже невозможно в реальной жизни, тоже выбрасываем исключение
        double p = (a + b + c) / 2;
        double preSquare = p * (p - a) * (p - b) * (p - c);
        if (Double.IsInfinity(preSquare))
        {
            throw new ArgumentException(TriangleExceptionMessages.SidesAreTooBig);
        }

        return Math.Sqrt(preSquare);
    }
    
    public static double FindSquareOfCircle(double r)
    {
        if (r <= 0)
        {
            throw new ArgumentException(CircleExceptionMessages.RadiusMustBeGreaterThanZero);
        }
        
        var square = Math.PI * r * r;
        if (Double.IsInfinity(square))
        {
            throw new ArgumentException(CircleExceptionMessages.RadiusIsTooBig);
        }
        
        return square;
    }
    // Не совсем понял часть задания про незнание фигуры в compile time. Мы создаем внешнюю библиотеку и мы совершенно
    // никак не может знать о фигуре которая приходит нам в compile time. Я уже описал эту проблему в начале файла
    // клиенты должны сами решить что обозначают их числа(a, b - это стороны прямоугольника или полуоси эллипса) и уже
    // потом с этой информацией обратиться к нам. это бизнес логика, которую мы не можем знать поэтому делать не буду
    // и именно поэтому же добавление новых фигур будет означать добавление нового метода в этот класс
    // (да, не по солиду, но это оправданно. мы не можем перекидывать вычисление площади фигуры клиенту)
}