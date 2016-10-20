using System;
using System.Globalization;
using Xamarin.Forms;

namespace EntryAsPickerExample
{
	public class FocusedEventArgsToFocusedCommand : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				var eventArg = value as FocusEventArgs;
				return eventArg.IsFocused;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new ArgumentException("Sem uso");
		}
	}
}
