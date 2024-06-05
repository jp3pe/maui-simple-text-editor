namespace maui_simple_text_editor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            string filePath = "C:\\Users\\rlawo\\OneDrive\\바탕 화면\\hello.txt";
            string fileContent;

            if (File.Exists(filePath))
            {
                fileContent = File.ReadAllText(filePath);
                TextInput.Text = fileContent; // TextInput Entry에 fileContent의 값을 할당
            }
            else
            {
                // 파일이 존재하지 않는 경우에 대한 처리
            }
        }
    }
}
