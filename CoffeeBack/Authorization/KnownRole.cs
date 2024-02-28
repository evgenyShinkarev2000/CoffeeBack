namespace CoffeeBack.Authorization
{

    public record struct KnownRoleItem(string Name, int AccessLevel);

    public static class KnownRole
    {
        public static KnownRoleItem Intern { get; } = new KnownRoleItem("Intern", 100);
        public static KnownRoleItem Barista { get; } = new KnownRoleItem("Barista", 200);
        public static KnownRoleItem Manager { get; } = new KnownRoleItem("Manager", 300);
        public static KnownRoleItem Administering { get; } = new KnownRoleItem("Administering", 400);
        public static KnownRoleItem HRManager { get; } = new KnownRoleItem("HRManager", 500);
    }
}
