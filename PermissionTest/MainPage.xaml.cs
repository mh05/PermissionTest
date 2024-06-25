namespace PermissionTest
{
    public partial class MainPage : ContentPage
    {
        private string permission;
        private string _currentPermission;

        public string Permission
        {
            get => permission;
            set
            {
                permission = value;
                OnPropertyChanged();
            }
        }

        public string CurrentPermission
        {
            get => _currentPermission;
            set
            {
                _currentPermission = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            Permission = string.Empty;
            CurrentPermission = string.Empty;

            var checkedPermission = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>(); // always returns denied if users selected approximate location
            var selectedPermission = await Permissions.RequestAsync<Permissions.LocationWhenInUse>(); // Returns correct value on apprixomate its restricted and granded on precise

            Permission = selectedPermission.ToString();
            CurrentPermission = checkedPermission.ToString();
        }
    }

}
