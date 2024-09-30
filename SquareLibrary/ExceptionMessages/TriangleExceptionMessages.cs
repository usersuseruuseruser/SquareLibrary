using System.ComponentModel;

namespace SquareLibrary.ExceptionMessages;

public static class TriangleExceptionMessages
{
    public static string SidesMustBePositive { get; set; } = "Стороны треугольника должны быть положительными числами";
    public static string TriangleDoesNotExist { get; set; } = "Треугольник с такими сторонами не существует";
    public static string SidesAreTooBig { get; set; } = "Стороны треугольника слишком большие.";
}