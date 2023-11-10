namespace Tarea1._4_AndreaCastro
{
    public partial class App : Application
    {
        static Controllers.DBImagen instancia;

        public static Controllers.DBImagen Instancia
        {
            get
            {
                if (instancia == null)
                {
                    string dbname = "ImagenDB.db3";
                    string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string dbfull = Path.Combine(dbpath, dbname);
                    instancia = new Controllers.DBImagen(dbfull);
                }
                return instancia;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}