namespace PrismDemo.Core.Model
{
    public class Person
    {
        public const string FirstNameByDefault = nameof(Person) + nameof(FirstNameByDefault);

        public const string LastNameByDefault = nameof(Person) + nameof(LastNameByDefault);

        public const int AgeByDefault = default;

        public static readonly Person PersonByDefault = new();

        public string FirstName { get; set; } = FirstNameByDefault;

        public string LastName { get; set; } = LastNameByDefault;

        public int Age { get; set; } = AgeByDefault;
    }
}
