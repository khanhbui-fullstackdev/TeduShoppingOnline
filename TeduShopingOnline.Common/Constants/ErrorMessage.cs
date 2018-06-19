namespace TeduShopingOnline.Common.Constants
{
    public static class ErrorMessage
    {
        public const string RequiredField = "This field is required";
        public const string MinLengthField = "This field requires at least 2 characters";
        public const string MaxLengthField = "This field cannot length over 255 characters";

        public const string InvalidEmail = "Your email is invalid";

        public const string MinLengthEmail = "Email requires at least 12 characters";//ab@gmail.com
        public const string MaxLengthEmail = "Email cannot length over 50 characters";

        public const string MaxLengthMessage = "Message cannot length over 500 characters";

        public const string MinLengthPhone = "Phone requires at least 10 characters";
        public const string MaxLengthPhone = "Phone cannot length over 20 characters";

        public const string MinLengthUserName = "User name requires at least 6 characters";
        public const string MaxLengthUserName = "User name cannot length over 30 characters";

        public const string MinLengthPassword = "Password requires at least 10 characters";
        public const string MaxLengthPassword = "Password cannot length over 50 characters";

        public const string MinLengthIdentityNumber = "Identity number requires at least 8 characters";
        public const string MaxLengthIdentityNumber = "Identity number cannot length over 50 characters";

        public const string RequiredBirthday = "Birthday is required";
    }
}
