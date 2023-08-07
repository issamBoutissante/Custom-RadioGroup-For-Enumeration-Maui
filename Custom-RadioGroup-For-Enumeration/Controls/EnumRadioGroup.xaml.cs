using Syncfusion.Maui.ListView;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Custom_RadioGroup_For_Enumeration.Controls;

public partial class EnumRadioGroup : SfListView
{
    // Enum values as an observable collection
    public ObservableCollection<Enum> EnumValues { get; private set; } = new ObservableCollection<Enum>();

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
    private string GetEnumDescription(Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes?.Length > 0 ? attributes[0].Description : value.ToString();
    }
    private void DisplayValues(Type enumType)
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
    }
}
