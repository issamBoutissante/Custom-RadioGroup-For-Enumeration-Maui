using Syncfusion.Maui.ListView;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Serialization;

namespace Custom_RadioGroup_For_Enumeration.Controls;

public partial class EnumRadioGroup : SfListView
{
    // Enum values as an observable collection
    public ObservableCollection<string> EnumValues { get; private set; } = new ObservableCollection<string>();

    public static readonly BindableProperty EnumTypeProperty =
        BindableProperty.Create(nameof(EnumType), typeof(Type), typeof(EnumRadioGroup), null, propertyChanged: OnEnumTypeChanged);

    public Type EnumType
    {
        get => (Type)GetValue(EnumTypeProperty);
        set => SetValue(EnumTypeProperty, value);
    }

    public EnumRadioGroup()
    {
        InitializeComponent();
        this.ItemsSource = EnumValues;
    }

    private static void OnEnumTypeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (EnumRadioGroup)bindable;
        control.DisplayValues((Type)newValue);
    }
    /*private void DisplayValues(Type enumType)
    {
        if (!enumType.IsEnum)
        {
            throw new ArgumentException("Provided type must be an enumeration.");
        }

        EnumValues.Clear();
        foreach (Enum value in Enum.GetValues(enumType))
        {
            EnumValues.Add(value);
        }
    }*/
    private void DisplayValues(Type enumType)
    {
        if (!enumType.IsEnum)
        {
            throw new ArgumentException("Provided type must be an enumeration.");
        }

        EnumValues.Clear();
        foreach (Enum value in Enum.GetValues(enumType))
        {
            string displayValue = GetDisplayValue(value);
            EnumValues.Add(displayValue);  // Store the enum value, but display the displayValue.
        }
    }

    private string GetDisplayValue(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        EnumMemberAttribute[] attributes =
            (EnumMemberAttribute[])fi.GetCustomAttributes(typeof(EnumMemberAttribute), false);

        if (attributes != null && attributes.Length > 0)
            return attributes[0].Value;
        else
            return value.ToString();
    }

}
