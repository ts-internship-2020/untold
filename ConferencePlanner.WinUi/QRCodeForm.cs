using QRCoder;
using System;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;

namespace ConferencePlanner.WinUi
{
    public partial class QRCodeForm : Form
    {
        private string QRCode;
        public QRCodeForm()
        {
            InitializeComponent();
        }
        
        private void QRCodeForm_Load(object sender, EventArgs e)
        {
            string qrCode = Program.qrCode;
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(qrCode, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            label1.Text = "This is your QR Code.You'll need it to join the conference. You want to send it on e-mail? Else, you can " +
                "connect to the conference with this code: " + Program.qrCode;
            pictureBox1.Image = code.GetGraphic(11);
            pictureBox1.Image.Save("../../../Resources/qrCode.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        public void popUpMethod(String titleText, String contentText)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = titleText;
            popup.ContentText = contentText;
            popup.Popup();

        }

        private void button1_Click(object sender, EventArgs e)
        {
                using (MailMessage mail = new MailMessage())
                {
                    mail.Attachments.Add(new Attachment("../../../Resources/qrCode.jpeg"));
                    mail.From = new MailAddress("testare.aplicatie.ts@gmail.com");
                    mail.To.Add(Program.EnteredEmailAddress);
                    mail.Subject = "QR Code for conference authentification";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("testare.aplicatie.ts@gmail.com", "testing1.");
                        smtp.EnableSsl = true;
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        Task t = Task.Run(() => { 
                            popUpMethod("Error", "Invalid Email Address"); });
                        t.Wait();
                        this.Close();
                    }
                    
                    }
                }
                
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
