using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace Game_Caro
{
    public class CustomMessageBox : Form
    {
        public CustomMessageBox(string message, Color textColor)
        {
            // Đặt thuộc tính Text để hiển thị thông điệp
            Text = "Message";

            // Đặt thuộc tính Size để điều chỉnh kích thước của cửa sổ
            Size = new Size(400, 150);

            // Đặt thuộc tính StartPosition để đặt vị trí xuất hiện của cửa sổ
            StartPosition = FormStartPosition.CenterScreen;

            // Đặt thuộc tính ControlBox là false để ẩn các nút điều khiển cửa sổ (như nút đóng)
            ControlBox = true;

            // Tạo một Label để hiển thị thông điệp
            Label label = new Label();
            label.Text = message;
            label.ForeColor = textColor;
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = new Font("Mulish", 18, FontStyle.Bold);

            // Thêm Label vào Controls của cửa sổ
            Controls.Add(label);
        }
    }
}
