namespace wsPLD_8.Models.Shared
{
    public class MenuApp
    {
        public MenuApp()
        {
            this.Items = new List<MenuApp>();
            this.tab = "";
        }

        public string titulo { get; set; }
        public string icon { get; set; }
        public string hRef { get; set; }
        public string tab { get; set; }
        public string target { get; set; }
        public string span { get; set; }
        public List<MenuApp> Items { get; set; }

    }
}
