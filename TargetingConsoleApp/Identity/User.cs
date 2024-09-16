namespace TargetingConsoleApp.Identity
{
    class User
    {
        public string Id { get; set; }

        public IEnumerable<string> Groups { get; set; }
    }
}
