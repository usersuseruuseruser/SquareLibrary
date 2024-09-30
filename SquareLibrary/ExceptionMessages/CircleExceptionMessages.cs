using System.ComponentModel;

namespace SquareLibrary.ExceptionMessages;

public static class CircleExceptionMessages
{
    public static string RadiusIsTooBig { get; set; } = "Радиус круга слишком большой.";
    public static string RadiusMustBeGreaterThanZero { get; set; } = "Радиус круга должен быть больше нуля.";
}