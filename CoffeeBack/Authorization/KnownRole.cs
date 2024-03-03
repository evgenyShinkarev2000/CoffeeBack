namespace CoffeeBack.Authorization
{


    public static class KnownRoleName
    {
        public const string Intern = "Intern";
        public const string Barista = "Barista";
        public const string Manager = "Manager";
        public const string Administering = "Administering";
        public const string HRManager = "HRManager";
    }

    public static class KnowRoleAccessLevel
    {
        public const int Intern = 100;
        public const int Barista = 200;
        public const int Manager = 300;
        public const int Administering = 400;
        public const int HRManager = 500;
    }
}
