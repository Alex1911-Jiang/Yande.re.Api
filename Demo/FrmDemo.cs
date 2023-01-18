using System.Net;
using System.Reflection.Metadata;
using Yande.re.Api;

namespace Demo
{
    public partial class FrmDemo : Form
    {
        private YandeClient? _yandeApi;
        public FrmDemo()
        {
            InitializeComponent();
        }

        private async void BtnInit_Click(object sender, EventArgs e)
        {
            await Init();
        }

        private async Task Init()
        {
            try
            {
                _yandeApi = await YandeClient.CreateNew(false, false, txbTagFilter.Text);
                txbTagFilter.Enabled = false;
                btnRandomHPicture.Enabled = btnItemList.Enabled = true;
                txbItems.AppendText("初始化成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "初始化失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRandomHPicture_Click(object sender, EventArgs e)
        {
            if (_yandeApi is null)
                await Init();

            txbItems.Clear();
            YandeItem? item = await _yandeApi!.GetRandom(Rating.Safe);
            if (item is null)
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
                $"    Tags={(item.Tags is null ? "(无)" : string.Join(',', item.Tags))},\r\n" +
            "}"
                );

            using HttpClient httpClient = new();
            var response = await httpClient.GetAsync(item.BigImgUrl);
            picRandomPicture.Image = Image.FromStream(await response.Content.ReadAsStreamAsync());
        }

        private async void BtnItemList_Click(object sender, EventArgs e)
        {
            if (_yandeApi is null)
                await Init();

            txbItems.Clear();
            if (_yandeApi!.PictureList.Count == 0)
            {
                MessageBox.Show("当前页面为空页");
                txbTagFilter.Enabled = true;
                btnRandomHPicture.Enabled = btnItemList.Enabled = false;
                return;
            }
            for (int i = 0; i < _yandeApi.PictureList.Count; i++)
            {
                string tags = "(无)";
                if (_yandeApi.PictureList[i] is not null && _yandeApi.PictureList[i].Tags is not null)
                    tags = string.Join(',', _yandeApi.PictureList[i].Tags!);

                txbItems.AppendText(
                "{\r\n" +
                $"    ThuImgUrl={_yandeApi.PictureList[i].ThuImgUrl},\r\n" +
                $"    ShowPageUrl={_yandeApi.PictureList[i].ShowPageUrl},\r\n" +
                $"    Rating={_yandeApi.PictureList[i].Rating},\r\n" +
                $"    Tags={tags},\r\n" +
                "},\r\n"
                );
            }
        }
    }
}