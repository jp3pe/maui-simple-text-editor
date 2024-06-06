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
            }
        }
    }
}
