using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using BattleCity.Models;

namespace BattleCity.Utils.Converters;

public class DirectionToMatrixConverter : IValueConverter
{
    public static DirectionToMatrixConverter Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var direction = (FacingEnum)value;
        var matrix = Matrix.Identity;
        if (direction == FacingEnum.South) matrix = Matrix.CreateScale(1, -1);
        if (direction == FacingEnum.East) matrix = Matrix.CreateRotation(1.5708);
        if (direction == FacingEnum.West) matrix = Matrix.CreateRotation(1.5708) * Matrix.CreateScale(-1, 1);
        return new MatrixTransform(matrix);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}