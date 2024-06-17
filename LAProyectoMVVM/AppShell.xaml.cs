namespace LAProyectoMVVM
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.LANotePage), typeof(Views.LANotePage));
        }
    }
}
