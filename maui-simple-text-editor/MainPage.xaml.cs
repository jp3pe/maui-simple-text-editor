namespace maui_simple_text_editor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            PickAndShow();
        }

        async void PickAndShow()
        {
            try
            {
                var result = await FilePicker.PickAsync();
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    using (var reader = new StreamReader(stream))
                    {
                        var fileContent = await reader.ReadToEndAsync();
                        TextInput.Text = fileContent;
                    }
                }
            }
            catch (Exception ex)
            {
                // 파일 선택 중에 오류가 발생한 경우에 대한 처리
                Console.WriteLine(ex.Message);
            }
        }

        private void FileOpenButton_Clicked(object sender, EventArgs e)
        {
            PickAndShow();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            MyScrollView.HeightRequest = height * 0.8;
            TextInput.HeightRequest = MyScrollView.Height * 0.8;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            var height = mainDisplayInfo.Height;

            TextInput.HeightRequest = height * 0.8;
        }
    }
}
