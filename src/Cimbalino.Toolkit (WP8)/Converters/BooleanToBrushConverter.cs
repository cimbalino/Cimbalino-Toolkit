// ****************************************************************************
// <copyright file="BooleanToBrushConverter.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

#if WINDOWS_PHONE
using System.Windows.Data;
using System.Windows.Media;
#else
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
#endif

namespace Cimbalino.Toolkit.Converters
{
    /// <summary>
    /// An <see cref="IValueConverter"/> which converts a <see cref="bool"/> value to a <see cref="Brush"/> value.
    /// </summary>
    public class BooleanToBrushConverter : BooleanToValueConverterBase<Brush>
    {
    }
}