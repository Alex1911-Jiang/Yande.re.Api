using Yande.re.Api;

namespace Demo
{
    public partial class FrmDemo : Form
    {
        private YandeApi _yandeApi;
        public FrmDemo()
        {
            InitializeComponent();
        }

        private async void btnInit_Click(object sender, EventArgs e)
        {
            _yandeApi = await YandeApi.CreateNew(false, false, txbTagFilter.Text);
            txbTagFilter.Enabled = false;
            btnRandomHPicture.Enabled = btnItemList.Enabled = true;
        }
        private async void btnRandomHPicture_Click(object sender, EventArgs e)
        {
            txbItems.Clear();
            YandeItem item = await _yandeApi.GetRandom();
            if (item == null)
            {
                MessageBox.Show("全部结果已经迭代完毕");
                txbTagFilter.Enabled = true;
                btnRandomHPicture.Enabled = btnItemList.Enabled = false;
                return;
            }
            txbItems.AppendText(
                "{\r\n" +
                $"    ThuImgUrl={item.ThuImgUrl},\r\n" +
                $"    ShowPageUrl={item.ShowPageUrl},\r\n" +
                $"    BigImgUrl={item.BigImgUrl},\r\n" +
                $"    Rating={item.Rating},\r\n" +
                $"    Tags={string.Join(',', item.Tags)},\r\n" +
                "}"
                );
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(item.BigImgUrl);
            picRandomPicture.Image = Image.FromStream(await response.Content.ReadAsStreamAsync());
        }

        private void btnItemList_Click(object sender, EventArgs e)
        {
            txbItems.Clear();
            if (_yandeApi.PictureList.Count == 0)
            {
                MessageBox.Show("当前页面为空页");
                txbTagFilter.Enabled = true;
                btnRandomHPicture.Enabled = btnItemList.Enabled = false;
                return;
            }
            for (int i = 0; i < _yandeApi.PictureList.Count; i++)
            {
                txbItems.AppendText(
                "{\r\n" +
                $"    ThuImgUrl={_yandeApi.PictureList[i].ThuImgUrl},\r\n" +
                $"    ShowPageUrl={_yandeApi.PictureList[i].ShowPageUrl},\r\n" +
                $"    Rating={_yandeApi.PictureList[i].Rating},\r\n" +
                $"    Tags={string.Join(',', _yandeApi.PictureList[i].Tags)},\r\n" +
                "},\r\n"
                );
            }
        }
    }
}